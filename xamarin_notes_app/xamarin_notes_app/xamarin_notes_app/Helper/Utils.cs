using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using xamarin_notes_app.Models;

namespace xamarin_notes_app.Helper
{
    public sealed class Utils
    {
        private static Utils instance = null;
        private static readonly object _lock = new object();
        private static List<TaskData> _Tasks = null;
        /*   public static List<TaskData> Tasks
           {
               get =>  _Tasks;
               set => _Tasks = value;
           }*/

        public static Utils GetInstance
        {
            get
            {
                if (instance == null)
                {
                    lock (_lock)
                    {
                        if (instance == null)
                        {
                            instance = new Utils();
                        }
                    }
                }
                return instance;
            }
        }
        public  List<TaskData> GetAllTask() => _Tasks;

        public  void SetAllTask(List<TaskData> list)
        {
            _Tasks = list;
        }
    }
}
