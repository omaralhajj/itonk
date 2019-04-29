using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using StockBroker.Models;

namespace StockBroker.Controllers
{
    public class StockBrokerController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient shareControlClient;
        private readonly HttpClient traderControlClient;
        private readonly HttpClient transactionControlClient;

        public StockBrokerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            shareControlClient = _clientFactory.CreateClient("shareControl");
            traderControlClient = _clientFactory.CreateClient("traderControl");
            transactionControlClient = _clientFactory.CreateClient("transactionControl");
        }
        
        [HttpPut("traders/{buyerId}/shares/buy")]
        public async Task<IActionResult> BuyShare([FromRoute] Guid buyerId, [FromBody] IEnumerable<Share> shares)
        {
            try
            {
                // if (shares.Any(x => x.TraderID == buyerId))
                // {
                //     throw new StockBrokerException(HttpErrorCode.BadRequest,
                //         $"One or more of the provided shares already belongs to trader '{buyerId}'.");
                // }

                var buyer = await GetTrader(buyerId);

                var totalShareValue = shares.Select(x => x.Value).Sum();

                // if (buyer.Credit < totalShareValue)
                // {
                //     throw new StockBrokerException(HttpErrorCode.BadRequest,
                //         $"Trader '{buyer.Id}' does not have enough credit to buy the provided shares. " +
                //         $"Total value of shares is {totalShareValue} - trader's credit is {buyer.Credit}.");
                // }

                var transactions = PrepareTransactions(shares, buyer);

                var updatedShares = await UpdateShares(shares, buyer.ID);

                buyer.Credit -= totalShareValue;
                var updatedBuyer = await UpdateBuyer(buyer);
                var updatedSellers = await UpdateSellers(shares);

                var newTransactions = await RegisterTransactions(transactions);

                return Ok(updatedShares);
            }

            // catch (StockBrokerException e)
            // {
            //     return StatusCode((int)e.HttpErrorCode, e.Message);
            // }

            catch (Exception e)
            {
                //return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                return StatusCode(500);
            }
        }

        [HttpPut("traders/{sellerId}/shares/{shareId}/sell")]
        public async Task<IActionResult> SellShare([FromRoute] Guid sellerId, [FromRoute] Guid shareId,
            [FromBody] Share share)
        {
            try
            {
                // if (share.TraderId != sellerId)
                // {
                //     throw new StockBrokerException(HttpErrorCode.BadRequest,
                //         $"Share '{shareId}' does not belong to trader '{sellerId}'.");
                // }

                share.SharesForSale = true;

                var updatedShare = await UpdateShare(share, shareId);

                return Ok(updatedShare);
            }

            // catch (StockBrokerException e)
            // {
            //     return StatusCode((int)e.HttpErrorCode, e.Message);
            // }

            catch (Exception e)
            {
               // return StatusCode((int)HttpStatusCode.InternalServerError, e.Message);
                return StatusCode(500);
            }
        }

        private IEnumerable<Transaction> PrepareTransactions(IEnumerable<Share> shares, Trader buyer)
        {
            return shares.Select(share => new Transaction
                {
                    ShareID = share.ID,
                    BuyerID = buyer.ID,
                    SellerID = share.TraderID,
                    TransferValue = share.Value
                })
                .ToList();
        }

        private async Task<IEnumerable<Share>> UpdateShares(IEnumerable<Share> shares, Guid traderId)
        {
            var result = new List<Share>();

            /* if (shares.Any(x => !x.ForSale))
            {
                throw new StockBrokerException(HttpErrorCode.BadRequest,
                    "One or more of the given shares are not for sale.");
            } */

            foreach (var share in shares)
            {
                var request = new Share
                {
                    ID = share.ID,
                    TraderID = traderId,
                    Value = share.Value,
                    SharesForSale = share.SharesForSale
                };
                
                var httpContent = JsonConvert.SerializeObject(request);
                var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));

                using (var response = await shareControlClient.PutAsync($"/api/v1/shares/{share.ID}", byteContent))
                {
                   /*  if (!response.IsSuccessStatusCode)
                    {
                        throw new StockBrokerException((HttpErrorCode)response.StatusCode, response.ReasonPhrase);
                    } */

                    result.Add(JsonConvert.DeserializeObject<Share>(
                        await response.Content.ReadAsStringAsync())
                    );
                }
            }
            return result;
        }

        private async Task<Trader> UpdateBuyer(Trader trader)
        {
            var result = new Trader();
            var httpContent = JsonConvert.SerializeObject(trader);
            var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));

            using (var response = await traderControlClient.PutAsync($"/api/v1/traders/{trader.ID}", byteContent))
            {
                /* if (!response.IsSuccessStatusCode)
                {
                    throw new StockBrokerException((HttpErrorCode)response.StatusCode, response.ReasonPhrase);
                } */

                result = JsonConvert.DeserializeObject<Trader>(
                    await response.Content.ReadAsStringAsync()
                );
            }

            return result;
        }

        private async Task<IEnumerable<Trader>> UpdateSellers(IEnumerable<Share> shares)
        {
            var result = new List<Trader>();
            foreach (var share in shares)
            {
                var trader = await GetTrader(share.TraderID);
                trader.Credit += share.Value;

                var httpContent = JsonConvert.SerializeObject(trader);
                var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));

                using (var response = await traderControlClient.PutAsync($"/api/v1/traders/{trader.ID}", byteContent))
                {
                    /* if (!response.IsSuccessStatusCode)
                    {
                        throw new StockBrokerException((HttpErrorCode)response.StatusCode, response.ReasonPhrase);
                    } */

                    if (!result.Select(x => x.ID).Contains(trader.ID))
                    {
                        result.Add(JsonConvert.DeserializeObject<Trader>(
                            await response.Content.ReadAsStringAsync())
                        );
                    }
                }
            }
            

            return result;
        }

        private async Task<IEnumerable<Transaction>> RegisterTransactions(IEnumerable<Transaction> transactions)
        {
            var result = new List<Transaction>();
            foreach (var transaction in transactions)
            {
                var httpContent = JsonConvert.SerializeObject(transaction);
                var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));

                using (var response = await transactionControlClient.PostAsync("/api/v1/transactions", byteContent))
                {
                    /* if (!response.IsSuccessStatusCode)
                    {
                        throw new StockBrokerException((HttpErrorCode)response.StatusCode, response.ReasonPhrase);
                    } */

                    result.Add(JsonConvert.DeserializeObject<Transaction>(
                        await response.Content.ReadAsStringAsync())
                    );
                }
            }
            return result;
        }

        private async Task<Trader> GetTrader(Guid traderId)
        {
            var result = new Trader();
     
                using (var response = await traderControlClient.GetAsync($"/api/v1/traders/{traderId}"))
                {
                    result = JsonConvert.DeserializeObject<Trader>(await response.Content.ReadAsStringAsync());
                }

            return result;
        }

        private async Task<Share> UpdateShare(Share share, Guid shareId)
        {
            var result = new Share();
            var httpContent = JsonConvert.SerializeObject(share);
            var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));

            using (var response = await shareControlClient.PutAsync($"/api/v1/shares/{shareId}", byteContent))
            {
                result = JsonConvert.DeserializeObject<Share>(
                    await response.Content.ReadAsStringAsync()
                );
            }
            return result;
        }
    }
}
