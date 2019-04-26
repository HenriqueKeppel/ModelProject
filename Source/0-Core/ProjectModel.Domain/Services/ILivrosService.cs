using ProjectModel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Domain.Services
{
    public interface ILivrosService
    {
        Task SetCorrelationId(string value);
        Task<IEnumerable<Livro>> ObterLivroPorTituloAsync(string titulo);
    }
}
