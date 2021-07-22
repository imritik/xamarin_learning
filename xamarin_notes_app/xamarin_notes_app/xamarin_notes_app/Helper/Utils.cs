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
        private static List<TaskData> _Tasks { get; set; }
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
        public async Task<List<TaskData>> GetAllTasksAsync()
        {
            try
            {
                return _Tasks ;
            }
            catch
            {
                return null; 
            }
        }

        public async void SetAllTaskAsync(List<TaskData> list)
        {
            _Tasks = list;
        }
    }
}
