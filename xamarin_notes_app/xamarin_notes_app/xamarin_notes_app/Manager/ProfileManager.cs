using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Models;
using xamarin_notes_app.Store;

namespace xamarin_notes_app.Manager
{
   class ProfileManager
    {
        public static async Task<ProfileModel> GetProfileDataAsync()
        {
            var data = await ProfileStore.GetProfileFromDBAsync();
                return data;  
        }
    }
}
