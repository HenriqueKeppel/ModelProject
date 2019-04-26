using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ProjectModel.Application;
using ProjectModel.WebApi.Dtos;
using ProjectModel.Domain.Services;
using ProjectModel.Domain.Models;
using AutoMapper;

namespace ProjectModel.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase   
    {
        private readonly ILivrosService livrosService;

        public BooksController(ILivrosService livrosService)
        {
            this.livrosService = livrosService ?? throw new ArgumentNullException(nameof(livrosService));
        }

        [HttpGet]
        [ProducesResponseType(typeof(LivroDto), 200)]        
        public async Task<IEnumerable<LivroDto>> Get(string titulo)        
        {
            await livrosService.SetCorrelationId(this.Cid());

            IEnumerable<Livro> livrosResult = await livrosService.ObterLivroPorTituloAsync(titulo);
            
            var livros = Mapper.Map<IEnumerable<Livro>, IEnumerable<LivroDto>>(livrosResult);

            return livros;
        }
    }
}