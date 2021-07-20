using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_notes_app.Models
{
    class ProfileModel:BaseModel
    {
        public string name { get; set; }
        public int taskCount { get; set; }

        public string imageURL { get; set; }

        public ProfileModel(string Name,int count,string url)
        {
            name = Name;
            taskCount = count;
            imageURL = url;

        }
    }
}
