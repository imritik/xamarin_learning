using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Helper;
using xamarin_notes_app.Models;
using xamarin_notes_app.Store;

namespace xamarin_notes_app.Manager
{
    class TaskListManager
    {
        public static async Task<List<TaskData>> GetTasksAsync()
        {
            var data = await TaskListStore.GetTaskAsync(Constants.getTaskUrl);
            return data;
        }

        public static async Task<List<TaskData>> AddTaskAsync(TaskList tasks)
        {
            var data = await TaskListStore.AddTaskAsync(Constants.postTaskUrl,tasks);
            return data;
        }
    }
}
