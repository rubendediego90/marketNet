using AutoMapper;
using Core.Entities;

namespace WebApi.Dto
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<ProductoEntity, ProductoDto>()
                .ForMember(p=>p.CategoriaNombre, x=>x.MapFrom(a=>a.Categoria.NombreCategoria))
                .ForMember(p=>p.MarcaNombre, x=>x.MapFrom(a=>a.Marca.NombreMarca))
                ;
        }
    }
}
