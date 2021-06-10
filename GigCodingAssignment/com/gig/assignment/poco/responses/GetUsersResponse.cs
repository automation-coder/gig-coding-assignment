using System;
using System.Collections.Generic;
using System.Text;

namespace GigCodingAssignment.com.gig.assignment.dto
{
    class GetUsersResponse
    {
        public long page { get; set; }
        public long per_page { get; set; }
        public long total { get; set; }
        public long total_pages { get; set; }
        public List<Data> data { get; set; }
    }

    public partial class Data
    {
        public long id { get; set; }
        public string email { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public Uri avatar { get; set; }
    }
}
