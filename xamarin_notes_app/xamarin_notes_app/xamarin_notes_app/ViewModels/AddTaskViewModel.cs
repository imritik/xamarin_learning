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
    class AddTaskViewModel:BaseViewModel
    {
        public TaskData addTaskData;
        public Command AddTask { get; }
        string title;
        string description;

        public TaskList taskList;
        public List<TaskData> allTasks;

        public string Title
        {
            get => title;
            set
            {
                if (title == null) { return; }
                title = value;
                OnPropertyChanged(nameof(title));
            }
        }

        public string Description
        {
            get => description;
            set
            {
                if (description == null) { return; }
                description = value;
                OnPropertyChanged(nameof(description));
            }
        }
        public AddTaskViewModel()
        {
            AddTask = new Command(async () => await AddTaskAsync());

        }

         async Task AddTaskAsync()
        {
            Console.WriteLine("In add task commmand");
            IsLoading = true;
    
            try
            {
                if (!string.IsNullOrEmpty(Title) && !string.IsNullOrEmpty(Description))
                {
                    addTaskData.title = Title;
                    addTaskData.description = Description;
                    addTaskData.date = DateTime.Now.ToString();

                    Console.WriteLine("To Add Data" + addTaskData);
                    allTasks=await Utils.GetInstance.GetAllTasksAsync();

                    if (allTasks != null)
                    {
                        allTasks.Add(addTaskData);
                        taskList.tasks = allTasks;
                    }
                    else
                    {
                        taskList.tasks.Add(addTaskData);
                    }

                    Console.WriteLine("task list from utils" + taskList.ToString());

                    var newList = await TaskListManager.AddTaskAsync(taskList);
                    if (newList != null)
                    {
                        allTasks = newList;
                        Utils.GetInstance.SetAllTaskAsync(allTasks);

                    }

                    await Application.Current.MainPage.DisplayAlert(Strings.taskAddSuccess, addTaskData.title, "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(Strings.taskAddFailure, "Please fill all the fields", "Ok");
                }
                

            }
            catch
            {
                Console.WriteLine("AddTAsk View model: Failed to get credentials");
                
            }

            IsLoading = false;
        }
    }
}
