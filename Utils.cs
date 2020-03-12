using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KadevjoAPI
{
    public class APIResp {
        public string message { get; set; }
        public string subtitle { get; set; }
    }
    public static class Utils
    {
        private static string baseUrl = "https://foaas.com/";
        
        public static async Task<string> getNewSubtitleAsync(string subtitle = "", string from = "Alex") {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage HttpResponseMessageRes = await client.GetAsync($"look/{subtitle}/{from}");
                if (HttpResponseMessageRes.IsSuccessStatusCode) {
                    var res = HttpResponseMessageRes.Content.ReadAsStringAsync().Result;
                    subtitle = JsonConvert.DeserializeObject<APIResp>(res).message;
                }
            }
            return subtitle;
        }

    }
}
