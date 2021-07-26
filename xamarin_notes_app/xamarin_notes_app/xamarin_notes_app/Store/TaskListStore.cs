using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Helper;
using xamarin_notes_app.Models;
using xamarin_notes_app.Services;

namespace xamarin_notes_app.Store
{
    class TaskListStore
    {
        public static async Task<ActionResult> GetTaskAsync(string url)
        {
            var response = await RestServices.GetDataAsync(url);

            if (response.Data != null)
            {
                try
                {
                    var taskList = JsonConvert.DeserializeObject<TaskList>(response.Data);
                    return new ActionResult(taskList.tasks, null);

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new ActionResult(null, e.Message);
                }
            }
            else
            {
                return new ActionResult(null, response.Error);
            }
        }


        public static async Task<ActionResult> AddTaskAsync(string url, TaskList tasks)

        {
            var response = await RestServices.PutDataAsync(url, tasks);
            if (response.Data != null)
            {
                try
                {
                    var taskList = JsonConvert.DeserializeObject<TaskList>(response.Data);
                    return new ActionResult(taskList.tasks, null);
                }


                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    return new ActionResult(null, e.Message);
                }
            }
            else
            {
                Console.WriteLine("Task Store:Failed to get tasks");
                return new ActionResult(null, response.Error);
            }
        }
    }
}
