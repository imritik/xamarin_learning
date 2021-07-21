using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Models;
using xamarin_notes_app.Services;

namespace xamarin_notes_app.Store
{
    class TaskListStore
    {
        public static async Task<List<TaskData>> GetTaskAsync(string url)
        {
            try
            {
                string response = await RestServices.GetDataAsync(url);
                if (response != null)
                {
                    var taskList = JsonConvert.DeserializeObject<TaskList>(response);

                    return taskList.tasks;
                }
                else
                {
                    Console.WriteLine("Task Store:Failed to get tasks");
                    return null;
                }
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }

        }
    }
}
