using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigCodingAssignment.com.gig.assignment.util
{
    class RestActions
    {
        private static RestClient client = null;
        private static RestRequest request;
        
        public static void Initialize(String baseUrl)
        {
            if (client == null)
            {
                client = new RestClient(baseUrl);
            }
        }

        public static IRestResponse Post(Object body)
        {
            request = new RestRequest("register", Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddJsonBody(body);
            return client.Execute(request);
        }

        public static IRestResponse Get(String endpoint)
        {
            request = new RestRequest(endpoint, Method.GET);
            return client.Execute(request);
        }

    }
}
