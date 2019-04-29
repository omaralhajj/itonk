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
        public HttpClient HttpClient { get; }

        [HttpPut()]
        public async Task<Share> UpdateShare(Guid TraderID, Guid ShareID)
        {
            var tid = TraderID;
            var sid = ShareID;

            var result = new Share();

            foreach (var partition in partitions)
            {
             
       
                var httpContent = JsonConvert.SerializeObject(share);
                var byteContent = new ByteArrayContent(System.Text.Encoding.UTF8.GetBytes(httpContent));
                byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                using (var response = await HttpClient.PutAsync(proxyUrl, byteContent))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        throw new StockBrokerException((HttpErrorCode) response.StatusCode, response.ReasonPhrase);
                    }

                    result = JsonConvert.DeserializeObject<Share>(
                        await response.Content.ReadAsStringAsync()
                    );
                }
            }
            return result;
        }
    }
}
