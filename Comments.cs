using System;
using System.Collections.Generic;
using System.Text;

namespace QUETE_RESTful_WebServices
{
    public class Comments
    {

        public int userId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }
    }
}
