using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectModel.GoogleBooksApiAdapter.Clients
{
    public class Book
    {
        public string kind { get; set; }
        public string id { get; set; }
        public string etag { get; set; }
        public string selfLink { get; set; }
        public VolumeInfo volumeInfo { get; set; }
    }
}
