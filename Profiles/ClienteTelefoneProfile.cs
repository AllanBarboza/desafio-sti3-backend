using System;
using AgendaTelefonica.DTOs;
using AgendaTelefonica.Models;
using AutoMapper;

namespace AgendaTelefonica.Profiles
{
    public class ClienteTelefoneProfile : Profile
    {
        public ClienteTelefoneProfile()
        {
            CreateMap<CreateTelefoneDto, ClienteTelefone>();
            CreateMap<UpdateTelefoneDto, ClienteTelefone>();
            CreateMap<ClienteTelefone, GetTelefoneDto>()
                           .ForMember(c => c.Descricao, op => op.MapFrom(g => Enum.GetName(typeof(TelefoneEnum), g.Descricao)));
        }
    }
}