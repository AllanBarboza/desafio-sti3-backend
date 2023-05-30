using AgendaTelefonica.DTOs;
using AgendaTelefonica.Models;
using AutoMapper;

namespace AgendaTelefonica.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}