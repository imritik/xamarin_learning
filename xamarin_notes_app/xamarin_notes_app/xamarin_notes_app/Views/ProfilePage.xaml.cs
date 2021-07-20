using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_notes_app.ViewModels;

namespace xamarin_notes_app.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProfilePage : ContentPage
    {
        public ProfilePage()
        {
            InitializeComponent();
            BindingContext = new ProfileViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ProfileViewModel profileViewModel = (ProfileViewModel)BindingContext;
            profileViewModel.getProfileData();
        }
    }
}