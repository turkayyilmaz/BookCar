using CarBook.Dto.AboutDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook.WebUI.ViewComponents.AboutViewComponents
{
	public class _AboutUsComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;
        public _AboutUsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7161/api/About");
            if (responseMessage.IsSuccessStatusCode) //200 kodu dönerse şayet
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync(); //gelen datayı string yap
                var values = JsonConvert.DeserializeObject < List<ResultAboutDto>>(jsonData); //apiyi text yapıyoruz
                return View(values);
            }
            return View();
		}
	}
}
