using AutoMapper;
using ProjectModel.WebApi.Dtos;
using ProjectModel.Domain.Models;

namespace ProjectModel.MapperProfiles
{
    public class WebApiMapperProfile : Profile
    {
        public WebApiMapperProfile()
        {
            CreateMap<Livro, LivroDto>();
        }
    }
}