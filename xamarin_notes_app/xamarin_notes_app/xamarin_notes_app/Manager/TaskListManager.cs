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

        public static async Task<ActionResult> GetTasksAsync()
        {
            /*Check in shared instance ->
             * Check in local db ->
             * Rest Service*/

            ///instance
            Utils utils = Utils.GetInstance;
            var source = utils.GetAllTask();
            if (source == null)
            {
                //local db
                /*  source = await TaskListStore.GetTasksFromDBAsync();
                  if (source == null)
                  {*/
                //get data from rest service
                var response = await TaskListStore.GetTaskAsync(Constants.getTaskUrl);
                if (response.Data != null)
                {
                    source = response.Data;
                    utils.SetAllTask(response.Data);
                    /*TaskListStore.InsertTasksToDBAsync(response.Data);*/
                }
                else
                {
                    return new ActionResult(null, response.Error);
                }
                /*}*/
            }
            return new ActionResult(source, null);
        }




        /* public static async Task<ActionResult> GetTasksAsync()
         {
             *//*1-Check in shared instance -> Check in local db -> Rest Service*//*

             var response = await TaskListStore.GetTaskAsync(Constants.getTaskUrl);
             if (response.Data != null)
             {
                 return new ActionResult(response.Data, null);
             }
             else
             {
                 return new ActionResult(null, response.Error);
             }
         }*/

        public static async Task<ActionResult> AddTaskAsync(TaskList tasks)
        {
            var response = await TaskListStore.AddTaskAsync(Constants.postTaskUrl, tasks);
            if (response.Data != null)
            {
                return new ActionResult(response.Data, null);
            }
            else
            {
                return new ActionResult(null, response.Error);
            }
        }
    }
}
