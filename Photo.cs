using System;
using System.Collections.Generic;
using System.Text;

namespace QUETE_RESTful_WebServices
{
    public class Photo
    {
        public int AlbumID { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ThumbnailUrl { get; set; }
    }
}
