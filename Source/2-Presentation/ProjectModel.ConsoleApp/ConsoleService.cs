using AutoMapper;
using ProjectModel.ConsoleApp.Dto;
using ProjectModel.Domain.Models;
using ProjectModel.Domain.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ProjectModel.ConsoleApp
{
    public class ConsoleService : IDisposable
    {
        private readonly ILivrosService livroService;

        public ConsoleService (ILivrosService livroService)
        {
            this.livroService = livroService ?? throw new ArgumentNullException(nameof(livroService));
        }

        public async Task<IEnumerable<LivroDto>> obterLivrosPorTitulo(string titulo)
        {
            var livros = await livroService.ObterLivroPorTituloAsync(titulo);

            IEnumerable<LivroDto> retorno = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroDto>>(livros);

            return retorno;
        }

        public void Dispose()
        { }
    }
}
