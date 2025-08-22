using ApiProjeKampi.WebArayuz.Dtos.ServiceDtost;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampi.WebArayuz.ViewComponents
{
    public class _ServiceDefaultCompanentPartial:ViewComponent 

    {

        public readonly IHttpClientFactory _HttpClientFactory;

        public _ServiceDefaultCompanentPartial(IHttpClientFactory httpClientFactory)
        {
            _HttpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();
            var responsMessage = await client.GetAsync("https://localhost:7234/api/Services");
            if (responsMessage.IsSuccessStatusCode)
            {
                var jsonData = await responsMessage.Content.ReadAsStringAsync();
                var values=JsonConvert.DeserializeObject<List<ResultServiceDto>>(jsonData);
                return View (values);
            }
            return View();
        }
    }
}
