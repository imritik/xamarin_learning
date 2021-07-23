using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_notes_app.Helper
{
    public class ActionResult
    {
        public dynamic Data { get; set; }
        public string Error { get; set; }

        public ActionResult(dynamic data,string error)
        {
            Data = data;
            Error = error;
        }

    }
}
