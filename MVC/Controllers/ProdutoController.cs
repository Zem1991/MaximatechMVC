using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MVC.Models;

namespace MVC.Controllers
{
    public class ProdutoController : MaximatechCoreController
    {
        public static string UrlBase { get; } = UrlBase = $"https://localhost:7210/api/Product";

        public ProdutoController() : base() { }

        // GET: Produto
        public async Task<IActionResult> Index()
        {
            string fullUrl = $"{UrlBase}";
            HttpResponseMessage response = await HttpGetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                List<Produto> contents = response.Content.ReadAsAsync<List<Produto>>().Result;
                await FillViewBagDepartamentos();
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
                await FillViewBagDepartamentos(content.IdDepartamento);
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
            await FillViewBagDepartamentos();
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Produto produto)
        {
            string fullUrl = $"{UrlBase}";
            HttpResponseMessage response = await PostAsJsonAsync(fullUrl, produto);
            if (response.IsSuccessStatusCode)
            {
                //string redirectTo = $"{nameof(Details)}/{produto.Id}";
                //return RedirectToAction(redirectTo);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string message = response.Content.ReadAsStringAsync().Result;
                return BadRequest(message);
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
                await FillViewBagDepartamentos(content.IdDepartamento);
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
        public async Task<IActionResult> Edit(int id, Produto produto)
        {
            //string fullUrl = $"{UrlBase}/{id}";
            string fullUrl = $"{UrlBase}";
            HttpResponseMessage response = await PutAsJsonAsync(fullUrl, produto);
            if (response.IsSuccessStatusCode)
            {
                //string redirectTo = $"{nameof(Details)}/{produto.Id}";
                //return RedirectToAction(redirectTo);
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string message = response.Content.ReadAsStringAsync().Result;
                return BadRequest(message);
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
                await FillViewBagDepartamentos(content.IdDepartamento);
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
        public async Task<IActionResult> Delete(int id, Produto produto)
        {
            string fullUrl = $"{UrlBase}/{id}";
            HttpResponseMessage response = await HttpDeleteAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                string message = response.Content.ReadAsStringAsync().Result;
                return BadRequest(message);
            }
        }

        private async Task FillViewBagDepartamentos(int selectedValueIndex = 0)
        {
            string fullUrl = $"{DepartamentoController.UrlBase}";
            HttpResponseMessage response = await HttpGetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                List<Departamento> departamentos = response.Content.ReadAsAsync<List<Departamento>>().Result;
                List<SelectListItem> dropdownItems = new();
                foreach (var item in departamentos)
                {
                    bool selected = item.Id == selectedValueIndex;
                    string text = $"{item.Codigo} | {item.Descricao}";
                    SelectListItem slItem = new()
                    {
                        Selected = selected,
                        Text = text,
                        Value = $"{item.Id}"
                    };
                    dropdownItems.Add(slItem);
                    if (selected)
                    {
                        ViewBag.TextDepartamento = text;
                    }
                }
                SelectList listItems = new(dropdownItems, "Value", "Text", selectedValueIndex);
                ViewBag.Departamentos = listItems;
            }
            //else
            //{
            //    string message = response.Content.ReadAsStringAsync().Result;
            //    BadRequest(message);
            //}
        }
    }
}
