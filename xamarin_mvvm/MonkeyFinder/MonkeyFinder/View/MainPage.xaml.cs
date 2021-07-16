using MonkeyFinder.Model;
using MonkeyFinder.ViewModel;
using System.Linq;
using Xamarin.Forms;

namespace MonkeyFinder.View
{
    public partial class MainPage : ContentPage
    {
        MonkeysViewModel model;
        public MainPage()
        {
            InitializeComponent();
            model = new MonkeysViewModel();
            /*BindingContext = new MonkeysViewModel();*/
            BindingContext = model;


        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            model.GetMonkeysCommand.Execute(null);

        }

        private async void CollectionView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var monkey = e.CurrentSelection.FirstOrDefault() as Monkey;
            if (monkey == null)
                return;

            await Navigation.PushAsync(new DetailsPage(monkey));

            ((CollectionView)sender).SelectedItem = null;
        }
    }
}
