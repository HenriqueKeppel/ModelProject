using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectModel.GoogleBooksApiAdapter.Clients
{
    public class VolumeInfo
    {
        public string title { get; set; }
        public IEnumerable<string> authors { get; set; }
        public string publisher { get; set; }
        public string publishedDate { get; set; }
        public string description { get; set; }
        public IEnumerable<IndustryIdentifiers> industryIdentifiers { get; set; }
    }
}
