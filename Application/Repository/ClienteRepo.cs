using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Query;
using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace Application.Repository;

public class ClienteRepo : GenericRepository<Cliente>, ICliente
{
    private readonly ApiGardensContext _context;

    public ClienteRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Cliente>> GetClientesPedidoRetrasado()
    {
        return await (

            from ped in _context.Pedidos
            where ped.FechaEntrega.Year > ped.FechaEsperada.Year && ped.FechaEntrega.Month > ped.FechaEsperada.Month && ped.FechaEntrega.Day > ped.FechaEsperada.Day
            join cli in _context.Clientes
            on ped.CodigoCliente equals cli.CodigoCliente
            /* group cli by cli.NombreCliente into pedCli */
            select new Cliente
            {
                NombreCliente = cli.NombreCliente
            }

        ).ToListAsync();
    }

    public async Task<IEnumerable<ClienteCantidadPedidos>> GetCantidadPedidosCliente()
    {
        return await (
            from cli in _context.Clientes
            join ped in _context.Pedidos
            on cli.CodigoCliente equals ped.CodigoCliente
            group cli by new { cli.NombreCliente } into pedCli
            /* group pedCli by pedCli.Key.NombreCliente into NomCli  */
            select new ClienteCantidadPedidos
            {
                NombreCliente = pedCli.Key.NombreCliente,
                CantidadPedidos = pedCli.Count()
            }
        ).ToListAsync();
    }
}