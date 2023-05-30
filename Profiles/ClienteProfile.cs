using AgendaTelefonica.DTOs;
using AgendaTelefonica.Models;
using AutoMapper;

namespace AgendaTelefonica.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<UpdateClienteDto, Cliente>();
            CreateMap<Cliente, GetClienteDto>();
        }
    }
}