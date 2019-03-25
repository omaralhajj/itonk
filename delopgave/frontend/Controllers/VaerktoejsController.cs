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
    public class VaerktoejsController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient client;
        public VaerktoejsController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient("backend");
        }

        // GET: Vaerktoejss
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync(
            "api/vaerktoejs");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<IEnumerable<Vaerktoej>>();
            return View(result.ToList());
        }

        // GET: Vaerktoejss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync(
            "api/vaerktoejs/" + id);

            response.EnsureSuccessStatusCode();

            var Vaerktoejs = await response.Content
                .ReadAsAsync<Vaerktoej>();

            if (Vaerktoejs == null)
            {
                return NotFound();
            }

            return View(Vaerktoejs);
        }

        // GET: Vaerktoejss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Vaerktoejss/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LiggerIvkt,VtAnskaffet,VtFabrikat,VtId,VtModel,VtSerienr,VtType")] Vaerktoej Vaerktoej)
        {
            if (ModelState.IsValid)
            {
                var response = await client.PostAsJsonAsync("api/vaerktoejs", Vaerktoej);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(Vaerktoej);
        }

        // GET: Vaerktoejss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync(
            "api/vaerktoejs/" + id);

            response.EnsureSuccessStatusCode();

            var Vaerktoejs = await response.Content
                .ReadAsAsync<Vaerktoej>();

            if (Vaerktoejs == null)
            {
                return NotFound();
            }
            return View(Vaerktoejs);
        }

        // POST: Vaerktoejss/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("LiggerIvkt,VtAnskaffet,VtFabrikat,VtId,VtModel,VtSerienr,VtType")] Vaerktoej Vaerktoej)
        {
            if (id != Vaerktoej.VtId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                var response = await client.PutAsJsonAsync("api/vaerktoejs/" + id, Vaerktoej);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(Vaerktoej);


        }

        // GET: Vaerktoejs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync("api/vaerktoejs/" + id);

            response.EnsureSuccessStatusCode();

            var Vaerktoejs = await response.Content
                .ReadAsAsync<Vaerktoej>();

            if (Vaerktoejs == null)
            {
                return NotFound();
            }

            return View(Vaerktoejs);
        }

        // POST: Vaerktoejss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await client.DeleteAsync("api/vaerktoejs/" + id);
            response.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }
    }
}
