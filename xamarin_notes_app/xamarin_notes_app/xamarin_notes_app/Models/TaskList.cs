using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_notes_app.Models
{
    class TaskList
    {
        public List<TaskData> tasks { get; set; }

        public TaskList(List<TaskData> list)
        {
            tasks = list;
        }
    }
}
