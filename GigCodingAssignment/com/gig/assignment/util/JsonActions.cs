using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace GigCodingAssignment.com.gig.assignment.util
{
    class JsonActions
    {
        public static T GetObjectFromResponse<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content);
        }

        public static string GetJsonStringFromObject(Object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
