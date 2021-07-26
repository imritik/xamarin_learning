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
        static ApiExceptions apiExceptions = new ApiExceptions();

        public static async Task<ActionResult> GetDataAsync(string url)
        {
            try
            {
                HttpResponseMessage response = await _client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();

                    return new ActionResult(data, null);
                }
                else
                {
                    var errorMessage = apiExceptions.GetErrorMessage((int)response.StatusCode);
                    return new ActionResult(null, errorMessage);
                }
            }
            catch (Exception e)
            {

                /*return null;*/
                return new ActionResult(null, e.Message);
            }
        }

        public static async Task<ActionResult> PutDataAsync(string url, dynamic content)
        {
            try
            {
                var data = JsonConvert.SerializeObject(content);
                var reqObj = new StringContent(data, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await _client.PutAsync(url, reqObj);
                if (response.IsSuccessStatusCode)
                {
                    var dataList= await response.Content.ReadAsStringAsync();
                    return new ActionResult(dataList, null);
                }
                else
                {
                    var errorMessage = apiExceptions.GetErrorMessage((int)response.StatusCode);
                    return new ActionResult(null, errorMessage);
                }
            }
            catch (Exception e)
            {
                return new ActionResult(null, e.Message);
            }

        }
    }
}
