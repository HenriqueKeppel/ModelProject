using AutoMapper;
using ProjectModel.ConsoleApp.Dto;
using ProjectModel.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectModel.ConsoleApp
{
    public class ConsoleMapperProfile : Profile
    {
        public ConsoleMapperProfile()
        {
            CreateMap<Livro, LivroDto>();
        }        
    }
}
