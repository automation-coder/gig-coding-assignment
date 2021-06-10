using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GigCodingAssignment.com.gig.assignment.dto
{
    class RegisterUserRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}
