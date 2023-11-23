using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGardens.Dtos.Cliente;
using AutoMapper;
using Domain.Entities;

namespace ApiGardens.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Cliente, ClientePedidoDto>()
        .ReverseMap();
        /* CreateMap<CInventory, InventoryPDto>()
        .ReverseMap(); */
    }
}