using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class DepartamentoController : MaximatechCoreController
    {
        public static string UrlBase { get; } = $"https://localhost:7210/api/Department";

        public DepartamentoController() : base() { }

        // GET: Departamento
        public async Task<IActionResult> Index()
        {
            //TODO: I copypasted this into ProdutoController - some sort of code reuse could be arranged later
            string fullUrl = $"{UrlBase}";
            HttpResponseMessage response = await HttpGetAsync(fullUrl);
            if (response.IsSuccessStatusCode)
            {
                List<Departamento> contents = response.Content.ReadAsAsync<List<Departamento>>().Result;
                return View(contents);
            }
            else
            {
                return NotFound();
            }
        }
    }
}
