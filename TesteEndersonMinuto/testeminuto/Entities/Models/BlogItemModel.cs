using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Entities.Models
{
    public class BlogItemModel
    {
        public string title { get; set; }
        public string link { get; set; }
        public string comments { get; set; }
        public string pubDate { get; set; }
        public string creator { get; set; }
        public string category { get; set; }
        public string guid { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string slash { get; set; }
    }
}