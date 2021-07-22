using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using Xamarin.Forms;
using xamarin_notes_app.Manager;
using xamarin_notes_app.Models;

namespace xamarin_notes_app.ViewModels
{
    public class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public List<TaskData> source;

        public ObservableCollection<TaskData> AllTask { get; private set; }
        public BaseViewModel()
        {

        }

        bool isLoading;

        public bool IsLoading
        {
            get => isLoading;
            set
            {
                isLoading = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(isLoading));
            }
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
                /*source = null;*/
                IsLoading = false;
            }
        }

        public void OnPropertyChanged([CallerMemberName] string name = null) =>
           PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

    }
}
