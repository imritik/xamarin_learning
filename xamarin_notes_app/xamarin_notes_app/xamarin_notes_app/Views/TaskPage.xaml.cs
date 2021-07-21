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
    public partial class TaskPage : ContentPage
    {
        public TaskPage()
        {
            InitializeComponent();
            BindingContext = new TaskListViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            TaskListViewModel taskListViewModel = (TaskListViewModel)BindingContext;
            taskListViewModel.GetAllTask();
        }
    }
}