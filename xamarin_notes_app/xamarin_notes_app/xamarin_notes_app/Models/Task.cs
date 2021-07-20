using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_notes_app.Models
{
    public class Task:BaseModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
