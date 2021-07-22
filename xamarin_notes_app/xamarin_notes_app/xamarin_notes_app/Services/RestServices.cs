using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarin_notes_app.Helper;
using Newtonsoft.Json;

namespace xamarin_notes_app.Services
{
    static class RestServices
    {
        private static HttpClient _client = new HttpClient();

        public static async Task<string> GetDataAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return data;
                }
                else
                {
                   
                    return null;
                }
            }
            catch(Exception e)
            {
               
                return null;
            }
        }

        public static async Task<string> PutDataAsync(string url,dynamic content)
        {
            try
            {
                var data = JsonConvert.SerializeObject(content);
                var reqObj = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(url, reqObj);
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsStringAsync();
                }
                else
                {
                    return null;
                }
            }
            catch(Exception e)
            {
               
                return null;
            }

        }

    }
}
