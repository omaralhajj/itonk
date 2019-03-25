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
    public class HaandvaerkersController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient client;
        public HaandvaerkersController(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
            client = _clientFactory.CreateClient("backend");
        }

        // GET: Haandvaerkers
        public async Task<IActionResult> Index()
        {
            var response = await client.GetAsync(
            "api/haandvaerkers");

            response.EnsureSuccessStatusCode();

            var result = await response.Content
                .ReadAsAsync<IEnumerable<Haandvaerker>>();
            return View(result.ToList());
        }

        // GET: Haandvaerkers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync(
            "api/haandvaerkers/" + id);

            response.EnsureSuccessStatusCode();

            var haandvaerker = await response.Content
                .ReadAsAsync<Haandvaerker>();

            if (haandvaerker == null)
            {
                return NotFound();
            }

            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Haandvaerkers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("HvAnsaettelsedatao,HvEfternavn,HvFagomraade,HvFornavn,HaandvaerkerId")] Haandvaerker haandvaerker)
        {
            if (ModelState.IsValid)
            {
                var response = await client.PostAsJsonAsync("api/haandvaerkers", haandvaerker);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(haandvaerker);
        }

        // GET: Haandvaerkers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync(
            "api/haandvaerkers/" + id);

            response.EnsureSuccessStatusCode();

            var haandvaerker = await response.Content
                .ReadAsAsync<Haandvaerker>();

            if (haandvaerker == null)
            {
                return NotFound();
            }
            return View(haandvaerker);
        }

        // POST: Haandvaerkers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("HvAnsaettelsedatao,HvEfternavn,HvFagomraade,HvFornavn,HaandvaerkerId")] Haandvaerker haandvaerker)
        {
            if (id != haandvaerker.HaandvaerkerId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {

                var response = await client.PutAsJsonAsync("api/haandvaerkers/" + id, haandvaerker);
                response.EnsureSuccessStatusCode();
                return RedirectToAction(nameof(Index));
            }
            return View(haandvaerker);


        }

        // GET: Haandvaerkers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var response = await client.GetAsync("api/haandvaerkers/" + id);

            response.EnsureSuccessStatusCode();

            var haandvaerker = await response.Content
                .ReadAsAsync<Haandvaerker>();

            if (haandvaerker == null)
            {
                return NotFound();
            }

            return View(haandvaerker);
        }

        // POST: Haandvaerkers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await client.DeleteAsync("api/haandvaerkers/" + id);
            response.EnsureSuccessStatusCode();
            return RedirectToAction(nameof(Index));
        }
    }
}
