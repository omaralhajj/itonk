using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using frontend.Models;
using System.Net.Http;

namespace frontend.Controllers
{
    public class VaerktoejskassesController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient client;
        public VaerktoejskassesController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient("backend");
        }

        // GET: Vaerktoejskasses
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync(
            "api/Vaerktoejskasses");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<IEnumerable<Vaerktoejskasse>>();
            return View(result.ToList());
        }

        // GET: Vaerktoejskasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync(
            "api/Vaerktoejskasses/" + id);

            response.EnsureSuccessStatusCode();

            var Vaerktoejskasse = await response.Content
                .ReadAsAsync<Vaerktoejskasse>();

            if (Vaerktoejskasse == null)
            {
                return NotFound();
            }

            return View(Vaerktoejskasse);
        }

        // GET: Vaerktoejskasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaerktoejskasses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HvAnsaettelsedatao,HvEfternavn,HvFagomraade,HvFornavn,VaerktoejskasseId")] Vaerktoejskasse Vaerktoejskasse)
        {
            if (ModelState.IsValid)
            {
                var response = await client.PostAsJsonAsync("api/Vaerktoejskasse", Vaerktoejskasse);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(Vaerktoejskasse);
        }

        // GET: Vaerktoejskasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync(
            "api/Vaerktoejskasses/" + id);

            response.EnsureSuccessStatusCode();

            var Vaerktoejskasse = await response.Content
                .ReadAsAsync<Vaerktoejskasse>();

            if (Vaerktoejskasse == null)
            {
                return NotFound();
            }
            return View(Vaerktoejskasse);
        }

        // POST: Vaerktoejskasses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HvAnsaettelsedatao,HvEfternavn,HvFagomraade,HvFornavn,VaerktoejskasseId")] Vaerktoejskasse Vaerktoejskasse)
        {
            if (id != Vaerktoejskasse.VtkId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                var response = await client.PutAsJsonAsync("api/Vaerktoejskasse/" + id, Vaerktoejskasse);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(Vaerktoejskasse);


        }

        // GET: Vaerktoejskasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync("api/Vaerktoejskasse/" + id);

            response.EnsureSuccessStatusCode();

            var Vaerktoejskasse = await response.Content
                .ReadAsAsync<Vaerktoejskasse>();

            if (Vaerktoejskasse == null)
            {
                return NotFound();
            }

            return View(Vaerktoejskasse);
        }

        // POST: Vaerktoejskasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await client.DeleteAsync("api/Vaerktoejskasse/" + id);
            response.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }
    }
}
