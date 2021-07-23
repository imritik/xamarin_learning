using System;
using System.Collections.Generic;
using System.Text;

namespace xamarin_notes_app.Helper
{
    public class ApiExceptions
    {
        public string GetErrorMessage(int statusCode)
        {
            switch (statusCode)
            {
                case 400:
                    return "Bad Request";
                case 404:
                    return "Not Found";
                case 403:
                    return "Forbidden";
                default:
                    return "Error";
            }
        }
    }
}
