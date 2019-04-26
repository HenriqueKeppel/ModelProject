using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectModel.GoogleBooksApiAdapter.Clients
{
    public class BookResponseGet
    {
        public string kind { get; set; }
        public int totalItens { get; set; }
        public IEnumerable<Book> items { get; set; }
    }
}
