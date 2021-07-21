using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Models;
using xamarin_notes_app.Services;

namespace xamarin_notes_app.Store
{
    class ProfileStore
    {
        public static async Task<ProfileModel> GetProfileDataAsync(string url)
        {
            try
            {
                string response = await RestServices.GetDataAsync(url);
                if (response != null)
                {
                        var profile = JsonConvert.DeserializeObject<ProfileModel>(response);
                        return profile;

                }
                else
                {
                    Console.WriteLine("Profile Store:Failed to get profile");
                    return null;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
