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
        CreateMap<Pedido, ClientePedidoDto>()
        .ReverseMap();

        CreateMap<Cliente, ClienteNombreDto>()
        .ReverseMap();

        CreateMap<ClienteGamaProducto, ClienteGamaProductoDto>()
        .ReverseMap();

        CreateMap<ClienteCantidadPedidos, ClienteCantidadPedidosDto>()
        .ReverseMap();
    }
}