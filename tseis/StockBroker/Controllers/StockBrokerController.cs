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
        private readonly HttpClient shareControlClient;
        private readonly HttpClient traderControlClient;
        private readonly HttpClient transactionControlClient;

        public StockBrokerController(IHttpClientFactory clientFactory)
        {
            shareControlClient = clientFactory.CreateClient("shareControl");
            traderControlClient = clientFactory.CreateClient("traderControl");
            transactionControlClient = clientFactory.CreateClient("transactionControl");
        }
        
        [HttpPost("traders/{buyerId}/shares/buy")]
        public async Task<IActionResult> BuyShare([FromRoute] int buyerId, [FromBody] IEnumerable<Share> shares)
        {
            var buyer = await GetTrader(buyerId);
            var totalShareValue = shares.Select(x => x.Value).Sum();
            var transactions = PrepareTransactions(shares, buyer);
            var updatedShares = await UpdateShares(shares, buyerId);
            buyer.Credit -= totalShareValue;
            var updatedBuyer = await UpdateBuyer(buyer);
            var updatedSellers = await UpdateSellers(shares);
            var newTransactions = await RegisterTransactions(transactions);

            return Ok(updatedShares);
        }

        [HttpPost("traders/{sellerId}/shares/{shareId}/sell")]
        public async Task<IActionResult> SellShare([FromRoute] int shareId, [FromBody] Share share)
        {
            share.SharesForSale = true;

            var updatedShare = await UpdateShare(share, shareId);

            return Ok(updatedShare);
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

        private async Task<IEnumerable<Share>> UpdateShares(IEnumerable<Share> shares, int traderId)
        {
            var result = new List<Share>();
            foreach (var share in shares)
            {
                var request = new Share
                {
                    ID = share.ID,
                    TraderID = traderId,
                    Value = share.Value,
                    SharesForSale = share.SharesForSale
                };

                var json = JsonConvert.SerializeObject(request);
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                using (var response = await shareControlClient.PutAsync($"/api/v1/shares/{share.ID}", httpContent))
                {

                    result.Add(JsonConvert.DeserializeObject<Share>(
                        await response.Content.ReadAsStringAsync())
                    );
                }
            }
            return result;
        }

        private async Task<ActionResult> UpdateBuyer(Trader trader)
        {
            var json = JsonConvert.SerializeObject(trader);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using (var response = await traderControlClient.PutAsync($"/api/v1/traders/{trader.ID}", httpContent))
            {
                await response.Content.ReadAsStringAsync();
            }

            return NoContent();
        }

        private async Task<IEnumerable<Trader>> UpdateSellers(IEnumerable<Share> shares)
        {
            var result = new List<Trader>();
            foreach (var share in shares)
            {
                var trader = await GetTrader(share.TraderID);
                trader.Credit += share.Value;

                var json = JsonConvert.SerializeObject(trader);
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                using (var response = await traderControlClient.PutAsync($"/api/v1/traders/{trader.ID}", httpContent))
                {
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
                var json = JsonConvert.SerializeObject(transaction);
                var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                using (var response = await transactionControlClient.PostAsync("/api/v1/transactions", httpContent))
                {
                    result.Add(JsonConvert.DeserializeObject<Transaction>(
                        await response.Content.ReadAsStringAsync())
                    );
                }
            }
            return result;
        }

        private async Task<Trader> GetTrader(int traderId)
        {
            var result = new Trader();
     
                using (var response = await traderControlClient.GetAsync($"/api/v1/traders/{traderId}"))
                {
                    result = JsonConvert.DeserializeObject<Trader>(await response.Content.ReadAsStringAsync());
                }

            return result;
        }

        private async Task<ActionResult> UpdateShare(Share share, int shareId)
        {
            var json = JsonConvert.SerializeObject(share);
            var httpContent = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

            using (var response = await shareControlClient.PutAsync($"/api/v1/shares/{shareId}", httpContent))
            {
                await response.Content.ReadAsStringAsync();             
            };

            return NoContent();
        }
    }
}
