using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;
using System.Collections.Generic;

namespace MVC.Controllers
{
    public class ProdutoController : MaximatechCoreController
    {
        private string UrlBase { get; }

        public ProdutoController() : base()
        {
            UrlBase = $"https://localhost:7210/api/Product";
        }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            string fullUrl = $"{UrlBase}";
            HttpResponseMessage response = await HttpGetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                List<Produto> contents = response.Content.ReadAsAsync<List<Produto>>().Result;
                return View(contents);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Produto/Details/5
        public async Task<IActionResult> Details(int id)
        {
            string fullUrl = $"{UrlBase}/{id}";
            HttpResponseMessage response = await HttpGetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                Produto content = response.Content.ReadAsAsync<Produto>().Result;
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // GET: Produto/Create
        public async Task<IActionResult> Create()
        {
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Codigo,Descricao,Preco,Status")] Produto produto)
        {
            string fullUrl = $"{UrlBase}";
            HttpResponseMessage response = await PostAsJsonAsync(fullUrl, produto);
            if (response.IsSuccessStatusCode)
            {
                Produto content = response.Content.ReadAsAsync<Produto>().Result;
                string redirectTo = $"{nameof(Details)}/{produto.Id}";
                return RedirectToAction(redirectTo);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: Produto/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            string fullUrl = $"{UrlBase}/{id}";
            HttpResponseMessage response = await HttpGetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                Produto content = response.Content.ReadAsAsync<Produto>().Result;
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Codigo,Descricao,Preco,Status")] Produto produto)
        {
            //string fullUrl = $"{UrlBase}/{id}";
            string fullUrl = $"{UrlBase}";
            HttpResponseMessage response = await PutAsJsonAsync(fullUrl, produto);
            if (response.IsSuccessStatusCode)
            {
                Produto content = response.Content.ReadAsAsync<Produto>().Result;
                string redirectTo = $"{nameof(Details)}/{produto.Id}";
                return RedirectToAction(redirectTo);
            }
            else
            {
                return BadRequest();
            }
        }

        // GET: Produto/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            string fullUrl = $"{UrlBase}/{id}";
            HttpResponseMessage response = await HttpGetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                Produto content = response.Content.ReadAsAsync<Produto>().Result;
                return View(content);
            }
            else
            {
                return NotFound();
            }
        }

        // POST: Produto/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string fullUrl = $"{UrlBase}/{id}";
            HttpResponseMessage response = await HttpDeleteAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
