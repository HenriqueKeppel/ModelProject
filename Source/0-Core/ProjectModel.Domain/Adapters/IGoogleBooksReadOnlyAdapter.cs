using ProjectModel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Domain.Adapters
{
    public interface IGoogleBooksReadOnlyAdapter
    {
        Task<IEnumerable<Livro>> GetLivroPorTituloAsync(string titulo);
    }
}
