using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectModel.Domain.Models
{
    public class Livro
    {
        public string Isbn_13 { get; set; }
        public string Isbn_10 { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public IEnumerable<string> Autores { get; set; }
    }
}
