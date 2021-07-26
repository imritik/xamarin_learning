using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Helper;
using xamarin_notes_app.Models;
using xamarin_notes_app.Store;

namespace xamarin_notes_app.Manager
{
   class ProfileManager
    {
      public static async Task<ActionResult> GetProfileDataAsync()
        {
            var response = await ProfileStore.GetProfileDataAsync(Constants.getProfileUrl);
            if (response.Data != null)
            {
                return new ActionResult(response.Data, null);
            }
            else
            {
                return new ActionResult(null, response.Error);
            }
        }
    }
}
