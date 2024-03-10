using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    public class DepartamentoController : MaximatechCoreController
    {
        private string UrlBase { get; }

        public DepartamentoController() : base()
        {
            UrlBase = $"https://localhost:7210/api/Department";
        }

        // GET: Departamento
        public async Task<IActionResult> Index()
        {
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
