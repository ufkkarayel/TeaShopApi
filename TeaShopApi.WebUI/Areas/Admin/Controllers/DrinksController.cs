using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DrinksController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

        public DrinksController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7263/api/Drinks");
			if (responseMessage != null)
			{

			}
			return View();
		}
	}
}
