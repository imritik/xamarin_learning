using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_notes_app.Models
{
    public class TaskData:BaseModel
    {
        public string title { get; set; }
        public string description { get; set; }
        public string date { get; set; }

        public TaskData(string Title,string Description,string Date)
        {
            title = Title;
            description = Description;
            date = Date;
        }
    }
}
