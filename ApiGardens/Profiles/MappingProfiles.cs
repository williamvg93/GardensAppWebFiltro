using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGardens.Dtos.Cliente;
using AutoMapper;
using Domain.Entities;
using Domain.Entities.Query;

namespace ApiGardens.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Cliente, ClientePedidoDto>()
        .ReverseMap();

        CreateMap<ClienteGamaProducto, ClienteGamaProductoDto>()
        .ReverseMap();
    }
}