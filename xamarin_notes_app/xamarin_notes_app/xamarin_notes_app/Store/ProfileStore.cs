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

               /* string json = null;
                var a = System.Reflection.Assembly.GetExecutingAssembly();
                using (var resFilestream = a.GetManifestResourceStream("xamarin_notes_app.profileData.json"))
                {
                    using (var reader = new System.IO.StreamReader(resFilestream))
                        json = await reader.ReadToEndAsync();
                }*/

                string response = await RestServices.GetDataAsync(url);
                if (response != null)
                {
                    try
                    {
                        var profile = JsonConvert.DeserializeObject<ProfileModel>(response);
                        return profile;
                    }
                    catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                        return null;
                    }
                }
                else
                {
                    Console.WriteLine("Profile Store:Failed to get tasks");
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
