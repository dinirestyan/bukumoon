using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace BukuMoonUI.UI.Helper
{
    public class WebService
    {
        public async Task<string> PostLilu(string url, string request)
        {
            string rest;
            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.Timeout = TimeSpan.FromSeconds(30);
                StringContent mayu1 = new StringContent(request, Encoding.UTF8, "application/json");
                var result = await client.PostAsync(url, mayu1);
                rest = await result.Content.ReadAsStringAsync();
            }
            return rest;

        }
    }
}
