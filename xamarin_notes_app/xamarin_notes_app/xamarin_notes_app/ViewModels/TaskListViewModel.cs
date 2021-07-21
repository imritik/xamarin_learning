using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using xamarin_notes_app.Models;
using xamarin_notes_app.Manager;
using Xamarin.Forms;
using System.Linq;

namespace xamarin_notes_app.ViewModels
{
    class TaskListViewModel : BaseViewModel
    {
        List<TaskData> source;

        public ObservableCollection<TaskData> AllTask { get; private set; }

        public TaskListViewModel()
        {

        }

        public async void GetAllTask()
        {
            IsLoading = true;

            try
            {
                source = await TaskListManager.GetTasksAsync();

            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert("Error!", e.Message, "OK");
            }
            if (source != null)
            {
                AllTask = new ObservableCollection<TaskData>(source);
                OnPropertyChanged(nameof(AllTask));
                source = null;
                IsLoading = false;
            }
        }
    }
}
