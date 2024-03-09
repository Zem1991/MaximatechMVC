using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace MVC.Controllers
{
    public class MaximatechCoreController : Controller
    {
        protected HttpClient HttpClient { get; }

        public MaximatechCoreController()
        {
            HttpClient = new();
        }

        protected async Task<HttpResponseMessage> HttpGetAsync(string fullUrl)
        {
            HttpResponseMessage responseMessage = await HttpClient.GetAsync(fullUrl);
            return responseMessage;
            //ActionResult result
            //string url = $"{_activeCorpColetaUrl}CamposPersonalizados?cdEmpresa={cdEmpresa}&cdFilEmp={cdFilEmp}";
            //HttpResponseMessage responseMessage = await _httpClient.GetAsync(url);
            //return await ResponseResult(responseMessage);
            //return View();
        }

        protected async Task<HttpResponseMessage> PostAsJsonAsync(string fullUrl, object? body)
        {
            HttpResponseMessage responseMessage = await HttpClient.PostAsJsonAsync(fullUrl, body);
            return responseMessage;
        }

        protected async Task<HttpResponseMessage> PutAsJsonAsync(string fullUrl, object? body)
        {
            HttpResponseMessage responseMessage = await HttpClient.PutAsJsonAsync(fullUrl, body);
            return responseMessage;
        }

        protected async Task<HttpResponseMessage> HttpDeleteAsync(string fullUrl)
        {
            HttpResponseMessage responseMessage = await HttpClient.DeleteAsync(fullUrl);
            return responseMessage;
        }
    }
}
