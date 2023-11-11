using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace dotNetLibrary
{
    public static class APIcomms
    {
        private static HttpClient _httpClient;

        public const string TEMP_URL_BASE = "https://www.themealdb.com/api/json/v1/1/";
        public const string TEMP_URL_CATAGORIES = "categories.php";
        public static void InitializeClient(string URL_base)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(URL_base);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<CategoryModelList> LoadCategories()
        {
            using(HttpResponseMessage message = await _httpClient.GetAsync(TEMP_URL_CATAGORIES))
            {
                if (!message.IsSuccessStatusCode) throw new Exception(message.ReasonPhrase);
                string result = await message.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<CategoryModelList>(result);
            }
        }
    }
}
