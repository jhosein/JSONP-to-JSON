using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace RCPscraper
{
    public static class RCP
    {
        /// <summary>
        /// Pull data from RCP regardless of schema.
        /// </summary>
        /// <param name="url">RCP URL</param>
        /// <returns>Raw poll data from RCP</returns>
        public static dynamic GetPollData(string url)
        { 
            var client = new RestClient();
            var request = new RestRequest(Method.GET);

            //We should fetch this from DB eventually
            client.BaseUrl = new Uri("https://www.realclearpolitics.com");
            request.Resource = "epolls/json/6730_historical.js?1574573033066&callback=return_json";

            var response = client.Execute(request);
            var serializedJSON = JsonExtensions.CleanJSONP(response.Content);
            var pollData = JsonConvert.DeserializeObject<dynamic>(serializedJSON);
            return pollData;
        }
    }
}
