using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamarin_notes_app.Helper;
using xamarin_notes_app.Manager;
using xamarin_notes_app.Models;

namespace xamarin_notes_app.ViewModels
{
    class AddTaskViewModel : BaseViewModel
    {
        public TaskData addTaskData;
        public Command AddTask { get; }
        private string title;
        private string description;
        public List<TaskData> allTasks;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(Title));
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(Description));
                OnPropertyChanged(nameof(IsEnabled));
            }
        }

        public bool IsEnabled => !string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description);

        public AddTaskViewModel()
        {
            AddTask = new Command(async () => await AddTaskAsync());
        }

        async Task AddTaskAsync()
        {
            IsLoading = true;
            try
            {
                addTaskData = new TaskData(title, description, DateTime.Now.ToString("dd/MM/yyyy"));
                if(Utils.GetInstance.GetAllTask().Count>0)
                {
                    source = Utils.GetInstance.GetAllTask();
                }
                else
                {
                    GetAllTask();
                }
                allTasks = source;
                allTasks.Add(addTaskData);
                var newTaskList = new TaskList(allTasks);

                var newListResponse = await TaskListManager.AddTaskAsync(newTaskList);
                if (newListResponse.Data != null)
                {
                    allTasks = newListResponse.Data;
                    await Application.Current.MainPage.DisplayAlert(Strings.taskAddSuccess, addTaskData.title, "Ok");
                    Title = "";
                    Description = "";
                    GetAllTask();
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(Strings.taskAddFailure, newListResponse.Error, "Ok");
                }
            }
            catch (Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(Strings.taskAddFailure, e.Message, "Ok");
                Console.WriteLine("AddTAsk View model: " + e.Message);
            }


            IsLoading = false;

        }
    }
}
