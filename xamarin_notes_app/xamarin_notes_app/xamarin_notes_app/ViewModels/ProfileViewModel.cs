using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using xamarin_notes_app.Models;
using xamarin_notes_app.Manager;
using xamarin_notes_app.Helper;

namespace xamarin_notes_app.ViewModels
{
    class ProfileViewModel : BaseViewModel
    {
        public ProfileModel profileData;

        public ProfileModel ProfileData { get; set; }
        

        public ProfileViewModel()
        {
          
        }

        /*   public async void getProfileData()
            {
                IsLoading = true;

                try
                {
                    profileData = await ProfileManager.GetProfileDataAsync();
                }
                catch (Exception e)
                {
                  await  Application.Current.MainPage.DisplayAlert("Error!", e.Message, "OK");
                }
                if (profileData == null)
                {
                    profileData = new ProfileModel("Username", "https://images.unsplash.com/photo-1626631048881-bcf878e6d575?ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxMnx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60");

                }
                ProfileData = profileData;
                OnPropertyChanged(nameof(ProfileData));
                 IsLoading = false;
            }*/

        public async void getProfileData()
        {
            IsLoading = true;
            try
            {
                var response = await ProfileManager.GetProfileDataAsync();
                if (response.Data != null)
                {
                    profileData = response.Data;
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert("Error!", response.Error, "OK");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", e.Message, "OK");
            }
            if (profileData == null)
            {
                profileData = new ProfileModel("Username", "https://images.unsplash.com/photo-1626631048881-bcf878e6d575?ixid=MnwxMjA3fDB8MHxlZGl0b3JpYWwtZmVlZHwxMnx8fGVufDB8fHx8&ixlib=rb-1.2.1&auto=format&fit=crop&w=500&q=60");

            }
            ProfileData = profileData;
            OnPropertyChanged(nameof(ProfileData));
            IsLoading = false;
        }
    }
}
