using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using xamarin_notes_app.Views;

namespace xamarin_notes_app
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new TabBarPage());
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
