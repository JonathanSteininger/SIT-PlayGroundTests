using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http;

namespace WebAPILibrary
{
    public static class APIComms
    {
        private static HttpClient _client;
        public static HttpClient InitialiseClient()
        {
            
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json")
                );
            _client = client;
            return client;
        }


        public async static Task<YesNoModel> LoadYesNo() => await LoadYesNo(_client, "https://yesno.wtf/api");
        public async static Task<YesNoModel> LoadYesNo(HttpClient client, string URL)
        {
            using(HttpResponseMessage message = await _client.GetAsync(URL))
            {
                if (!message.IsSuccessStatusCode) throw new Exception(message.ReasonPhrase);
                string result = await message.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<YesNoModel>(result);
            }
        }
    }
    public class YesNoModel
    {
        public string Answre { get; set;  }
        public string Image { get; set; }
    }


}
