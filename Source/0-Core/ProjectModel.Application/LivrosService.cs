using bs2.comp.SysLog.Interfaces;
using ProjectModel.Domain.Adapters;
using ProjectModel.Domain.Models;
using ProjectModel.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.Application
{
    public class LivrosService : ILivrosService
    {
        private readonly IGoogleBooksReadOnlyAdapter googleBooksReadOnlyAdapter;
        private readonly ApplicationConfiguration configuration;
        private readonly ISysLog _log;
        private string CorrelationID;

        public LivrosService(IGoogleBooksReadOnlyAdapter googleBooksReadOnlyAdapter, 
            ApplicationConfiguration configuration, ISysLog log)
        {
            this.googleBooksReadOnlyAdapter = googleBooksReadOnlyAdapter ?? throw new ArgumentNullException(nameof(googleBooksReadOnlyAdapter));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this._log = log ?? throw new ArgumentException(nameof(log));
        }

        public async Task SetCorrelationId(string value)
        {
            this.CorrelationID = value;
        }

        public async Task<IEnumerable<Livro>> ObterLivroPorTituloAsync(string titulo)
        {
            _log.INFO(CorrelationID, ("Iniciando metodo ObterLivroPorTituloAsync."));

            if (string.IsNullOrEmpty(titulo))
                throw new ArgumentNullException(nameof(titulo));

            IEnumerable<Livro> resultado = await googleBooksReadOnlyAdapter.GetLivroPorTituloAsync(titulo);

            _log.INFO(CorrelationID, ("Metodo ObterLivroPorTituloAsync concluido com sucesso!"));
            return resultado;
        }
    }
}
