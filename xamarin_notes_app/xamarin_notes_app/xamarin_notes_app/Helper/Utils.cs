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
        public static List<TaskData> Tasks = null;

        public static Utils GetInstance
        {
            get
            {
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
