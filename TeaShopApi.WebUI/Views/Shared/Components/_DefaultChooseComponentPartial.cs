using Microsoft.AspNetCore.Mvc;

namespace TeaShopApi.WebUI.Views.Shared.Components
{
    public class _DefaultChooseComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultChooseComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
