using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.ServiceFabric.Data;
using Microsoft.ServiceFabric.Data.Collections;
using Models;
using Models.Exceptions;
using Models.Exceptions.Base;
using Utils.ControllerConfig;
using Utils.Extensions;

namespace Traders.Controllers
{
    [Route("api/v1")]
    public class TradersController : Controller
    {
        public const string GetById = "GetById";

        public IReliableStateManager StateManager { get; }

        public TradersController(IReliableStateManager stateManager)
        {
            StateManager = stateManager;
        }

        [HttpGet("traders/{id}", Name = GetById)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            var traderDictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, Trader>>("traders");

            using (var transaction = StateManager.CreateTransaction())
            {
                var list = await traderDictionary.CreateEnumerableAsync(transaction);
                var result = new Trader();

                using (var enumerator = list.GetAsyncEnumerator())
                {
                    var cancellationToken = new CancellationToken();

                    while (await enumerator.MoveNextAsync(cancellationToken))
                    {
                        if (enumerator.Current.Value.Id == id)
                        {
                            result = enumerator.Current.Value;
                            break;
                        }
                    }
                }

                return new OkObjectResult(result);
            }
        }

        [HttpGet("traders")]
        public async Task<IActionResult> GetAllTraders()
        {
            var traderDictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, Trader>>("traders");

            using (var transaction = StateManager.CreateTransaction())
            {
                var list = await traderDictionary.CreateEnumerableAsync(transaction);
                var result = new List<Trader>();

                using (var enumerator = list.GetAsyncEnumerator())
                {
                    var cancellationToken = new CancellationToken();

                    while (await enumerator.MoveNextAsync(cancellationToken))
                    {
                        result.Add(enumerator.Current.Value);
                    }
                }

                return new OkObjectResult(result);
            }
        }

        [HttpPost("traders")]
        public async Task<IActionResult> CreateTrader([FromBody] [Required] Trader trader)
        {
            try
            {
                var traderDictionary = await StateManager.GetOrAddAsync<IReliableDictionary<Guid, Trader>>("traders");

                trader.Id = Guid.NewGuid();

                using (var transaction = StateManager.CreateTransaction())
                {
                    await traderDictionary.AddAsync(transaction, trader.Id, trader);
                    await transaction.CommitAsync();
                }

                return new CreatedAtRouteResult(GetById, new { id = trader.Id }, trader);
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }

        [HttpPut("traders/{id}")]
        public async Task<IActionResult> UpdateTraderCredit([FromRoute] Guid id, [FromBody] [Required] Trader trader)
        {
            if (id != trader.Id)
            {
                throw new TradersException(
                    HttpErrorCode.BadRequest,
                    $"The ID of the provided trader '{trader.Id}' " +
                    $"does not correspond to the ID of the route '{id}'.");
            }

            if (!await StateManager.TryUpdate("traders", id, trader))
            {
                throw new TradersException(HttpErrorCode.NotFound, $"Trader '{id}' not found.");
            }

            return Ok(trader);
        }

    }

}