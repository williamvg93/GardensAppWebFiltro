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

public class GamaProductRepo : GenericRepository<GamaProducto>, IGamaProducto
{
    private readonly ApiGardensContext _context;

    public GamaProductRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<ClienteGamaProducto>> GetClientesGamasProducto()
    {
        return await (
            from cli in _context.Clientes
            join ped in _context.Pedidos
            on cli.CodigoCliente equals ped.CodigoCliente
            join detp in _context.DetallePedidos
            on ped.CodigoPedido equals detp.CodigoPedido
            join pro in _context.Productos
            on detp.CodigoProducto equals pro.CodigoProducto
            join gamp in _context.GamaProductos
            on pro.Gama equals gamp.Gama
            group gamp by new { gamp.Gama, cli.NombreCliente } into gamaPro
            select new ClienteGamaProducto
            {
                NombreCliente = gamaPro.Key.NombreCliente,
                NombreGama = gamaPro.Key.Gama
            }
        ).ToListAsync();
    }
}