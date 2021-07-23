using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Helper;
using xamarin_notes_app.Models;
using xamarin_notes_app.Services;

namespace xamarin_notes_app.Store
{
    class ProfileStore
    {
        /*    public static async Task<ProfileModel> GetProfileDataAsync(string url)
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
        }*/

        public static async Task<ActionResult> GetProfileDataAsync(string url)
        {
            var response = await RestServices.GetDataAsync(url);
            if (response.Data != null)
            {
                try
                {
                    var profile = JsonConvert.DeserializeObject<ProfileModel>(response.Data);
                    return new ActionResult(profile, null);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new ActionResult(null,e.Message);
                }
            }
            else
            {
                Console.WriteLine("Profile Store:Failed to get profile");
                return new ActionResult(null, response.Error);
            }
        }
    }
}
