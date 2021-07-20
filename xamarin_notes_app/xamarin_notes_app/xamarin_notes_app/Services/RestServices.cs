﻿using System;
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
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
                return null;
            }
        }

        public static async Task<string> PostDataAsync(string url,dynamic content)
        {
            try
            {
                var data = JsonConvert.SerializeObject(content);
                HttpResponseMessage response = await _client.PostAsync(url,data);
                if (response.IsSuccessStatusCode)
                {
                    return Strings.taskAddSuccess;
                }
                else
                {
                    return Strings.taskAddFailure;
                }
            }
            catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error", e.Message, "Ok");
                return null;
            }

        }

    }
}
