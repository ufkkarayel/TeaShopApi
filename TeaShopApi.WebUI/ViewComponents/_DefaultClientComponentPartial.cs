using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using TeaShopApi.WebUI.Dtos.DrinkDto;
using TeaShopApi.WebUI.Dtos.TestimonialDtos;

namespace TeaShopApi.WebUI.ViewComponents
{
    public class _DefaultClientComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultClientComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7263/api/Testimonial");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}


//public async Task<IViewComponentResult> InvokeAsync()
//{
//    var client = _httpClientFactory.CreateClient();
//    var responseMessage = await client.GetAsync("https://localhost:7263/api/Drinks/");
//    if (responseMessage.IsSuccessStatusCode)
//    {
//        var jsonData = await responseMessage.Content.ReadAsStringAsync();
//        var values = JsonConvert.DeserializeObject<List<ResultDrinkDto>>(jsonData);
//        return View(values);
//    }
//    return View();
//}