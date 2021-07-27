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
            /*Check in shared instance ->
            * Check in local db ->
            * Rest Service*/

            //instance
            Utils utils = Utils.GetInstance;
            var source = utils.GetProfile();
            if (source == null)
            {
                //local db
                /*source = await ProfileStore.GetProfileFromDBAsync();
                if (source == null)
                {*/
                //rest api
                var response = await ProfileStore.GetProfileDataAsync(Constants.getProfileUrl);
                if (response.Data != null)
                {
                    source = response.Data;
                    utils.SetProfileData(response.Data);
                    /*ProfileStore.InsertProfileToDBAsync(response.Data);*/
                }
                else
                {
                    return new ActionResult(null, response.Error);
                }
                /* }*/
            }
            return new ActionResult(source, null);
        }



        /*  public static async Task<ActionResult> GetProfileDataAsync()
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
          }*/
    }
}
