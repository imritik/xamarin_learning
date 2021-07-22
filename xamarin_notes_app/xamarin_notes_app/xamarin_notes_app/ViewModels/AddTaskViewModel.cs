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
        private string title;
        private string description;

        public TaskList taskList;
        public List<TaskData> allTasks;

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged(nameof(title));
            }
        }

        public string Description
        {
            get => description;
            set
            {
                description = value;
                OnPropertyChanged(nameof(description));
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
                if (!string.IsNullOrEmpty(title) && !string.IsNullOrEmpty(description))
                {
                    addTaskData = new TaskData(title, description, DateTime.Now.ToString());

                    /* allTasks =  Utils.GetInstance.GetAllTask();
                     Console.WriteLine(" ## All tasks ##" + allTasks.Count.ToString());

                     if (allTasks != null && allTasks.Count > 0)
                     {
                         allTasks.Add(addTaskData);
                         taskList.tasks = allTasks;
                     }
                     else
                     {
                         taskList.tasks.Add(addTaskData);
                     }
 */
                     GetAllTask();
                    allTasks = source;
                    allTasks.Add(addTaskData);

                    Console.WriteLine(allTasks);
                    var newTaskList = new TaskList(allTasks);

                    var newListResponse = await TaskListManager.AddTaskAsync(newTaskList);
                    if (newListResponse != null)
                    {
                        allTasks = newListResponse;
                        /*Utils.GetInstance.SetAllTask(allTasks);*/

                    }

                    await Application.Current.MainPage.DisplayAlert(Strings.taskAddSuccess, addTaskData.title, "Ok");
                }
                else
                {
                    await Application.Current.MainPage.DisplayAlert(Strings.taskAddFailure, Strings.fillFields, "Ok");
                }
                

            }
            catch(Exception e)
            {
                await Application.Current.MainPage.DisplayAlert(Strings.taskAddFailure, e.Message, "Ok");
                Console.WriteLine("AddTAsk View model: Failed to get credentials" +e.Message);
                
            }

            IsLoading = false;
        }
    }
}
