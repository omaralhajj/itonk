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
        private readonly HttpClient client;

        public StockBrokerController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient("stockbroker");
        }



    }
}
