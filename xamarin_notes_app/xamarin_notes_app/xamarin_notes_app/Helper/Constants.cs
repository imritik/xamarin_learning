using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace xamarin_notes_app.Helper
{
   public class Constants
    {
        public const string getTaskUrl = "https://jsonblob.com/api/jsonBlob/83c59a88-e8a7-11eb-9694-d9993de9aaa1";
        public const string getProfileUrl = "https://jsonblob.com/api/f3a1f489-e943-11eb-9e75-3151bfa1137a";
        public const string postTaskUrl = "https://jsonblob.com/api/jsonBlob/83c59a88-e8a7-11eb-9694-d9993de9aaa1";


        public const string DatabaseFileName = "TaskApp.db3";

        public const SQLite.SQLiteOpenFlags Flags = 
            SQLite.SQLiteOpenFlags.ReadWrite |
            SQLite.SQLiteOpenFlags.Create | 
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFileName);
            }
        }
    }
}
