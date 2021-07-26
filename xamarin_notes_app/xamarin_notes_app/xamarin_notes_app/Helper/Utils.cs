using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Models;

namespace xamarin_notes_app.Helper
{
    public sealed class Utils
    {
        private Utils()
        {

        }
        public static Utils instance = new Utils();
        /*       private static readonly object _lock = new object();*/
        public static List<TaskData> Tasks = null;

        public static Utils GetInstance
        {
            get
            {
                /*   if (instance == null)
                   {
                       lock (_lock)
                       {
                           if (instance == null)
                           {
                               instance = new Utils();
                           }
                       }
                   }*/
                return instance;
            }
        }
        public List<TaskData> GetAllTask() => Tasks;

        public void SetAllTask(List<TaskData> list)
        {
            Tasks = list;
        }
    }
}
