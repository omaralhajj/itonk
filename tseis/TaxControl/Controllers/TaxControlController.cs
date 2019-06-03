using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaxControl.Models;
using Newtonsoft.Json;

namespace TaxControl.Controllers
{
    [Route("api/v1")]
    public class TaxControlController : Controller
    {
        private readonly HttpClient httpClient;
        private readonly HttpClient bankClient;

        public TaxControlController(HttpClient httpClient, IHttpClientFactory clientFactory)
        {
            this.httpClient = httpClient;
            bankClient = clientFactory.CreateClient("bank");
        }

        [HttpPost("tax")]
        public async Task<IActionResult> DepositTaxPayment([FromBody] Models.Transaction transaction)
        {
            Trader trader = new Trader();
            var tax = transaction.TransferValue * (decimal)0.01;
            trader.Credit = trader.Credit - tax;

            var httpContent = JsonConvert.SerializeObject(trader);
            var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));

            using (var response = await bankClient.PostAsync($"api/v1/bank/{transaction.SellerID}", byteContent))
            {
                await response.Content.ReadAsStringAsync();
            }
            return Ok();
        }
    }
}