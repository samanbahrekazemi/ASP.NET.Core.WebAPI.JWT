using Application.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Presentation.Models;

namespace Web.Controllers
{
    public class ProductsController : Controller
    {

        private readonly WebApiConfig _webApiConfig;
        private readonly HttpClient _httpClient;
        public ProductsController(IOptions<WebApiConfig> webApiConfig, HttpClient httpClient)
        {
            _webApiConfig = webApiConfig.Value;
            _httpClient = httpClient;
            _httpClient.BaseAddress = new Uri(_webApiConfig.BaseUrl);
        }

        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync("api/products");
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var data =  JsonConvert.DeserializeObject<List<ProductDTO>>(content);
                return View(data);
            }

            return View(new List<ProductDTO>());
        }
    }
}
