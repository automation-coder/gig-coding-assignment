using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigCodingAssignment.com.gig.assignment.util
{
    class JsonActions
    {
        public static T getObjectFromResponse<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
