using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Models;

namespace xamarin_notes_app.Store
{
    class ProfileStore
    {
        public static async Task<ProfileModel> GetProfileFromDBAsync()
        {
            try
            {

                string json = null;
                var a = System.Reflection.Assembly.GetExecutingAssembly();
                using (var resFilestream = a.GetManifestResourceStream("xamarin_notes_app.profileData.json"))
                {
                    using (var reader = new System.IO.StreamReader(resFilestream))
                        json = await reader.ReadToEndAsync();
                }

                var profile = JsonConvert.DeserializeObject<ProfileModel>(json);
                return profile;

            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
