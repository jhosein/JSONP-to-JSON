using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace RCPscraper
{
    public static class JsonExtensions
    {/// <summary>
     /// Strips callback function away from JSONP string.
     /// </summary>
     /// <param name="s"></param>
     /// <returns>Returns serialized JSON string</returns>
        public static string CleanJSONP(string s)
        {
            string expression = "(^[^{]*)|([^}]*$)";
            Regex r = new Regex(expression);
            string jsonString = r.Replace(s, "");

            return jsonString;
        }
    }


}
