using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace KadevjoAPI
{
    public static class Utils
    {
        private static string baseUrl = "https://foaas.com/";
        //https://foaas.com/look/the%20subtitle/alex
        
        public static async Task<string> getNewSubtitleAsync(string subtitle = "", string from = "Alex") {
            using (var client = new HttpClient()) {
                client.BaseAddress = new Uri(baseUrl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync($"look/{subtitle}/{from}");
                if (Res.IsSuccessStatusCode)
                {
                    subtitle = Res.Content.ReadAsStringAsync().Result;
                }
            }
            return subtitle;
        }

    }
}
