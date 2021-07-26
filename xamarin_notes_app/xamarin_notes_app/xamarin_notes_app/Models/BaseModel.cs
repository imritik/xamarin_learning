using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_notes_app.Models
{
   public class BaseModel
    {
       
        [PrimaryKey,AutoIncrement]
        public int Id { set; get; }
    }
}
