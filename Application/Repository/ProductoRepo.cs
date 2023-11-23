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

public class ProductoRepo : GenericRepository<Producto>, IProducto
{
    private readonly ApiGardensContext _context;

    public ProductoRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }

    /*     public async Task<ProductUnidades> GetProductsMasVendidos()
        {
            return await (
                from detpe in _context.DetallePedidos
                join pro in _context.Productos
                on detpe.CodigoProducto equals pro.CodigoProducto
                group detpe by new { detpe.Cantidad, pro.Nombre } into cantUni
                select new ProductUnidades
                {
                    Nombre = cantUni.Key.Nombre,
                    Unidades = cantUni.Key.Cantidad.
                }
            ).FirstOrDefault();
        } */

    public async Task<IEnumerable<Producto>> GetProductsNoPedidos()
    {
        return await (
            from pro in _context.Productos
            join detpe in _context.DetallePedidos
            on pro.CodigoProducto equals detpe.CodigoProducto
            where pro.CodigoProducto != detpe.CodigoProducto
            group pro by new { pro.Nombre, pro.CodigoProducto } into products
            select new Producto
            {
                CodigoProducto = products.Key.CodigoProducto,
                Nombre = products.Key.Nombre
            }
        ).ToListAsync();
    }

    /*     public async Task<ProductUnidades> GetProductsMasVendidos()
        {
            return await (
                from detpe in _context.DetallePedidos
                join pro in _context.Productos
                on detpe.CodigoProducto equals pro.CodigoProducto
                group detpe by new { detpe.Cantidad, pro.Nombre } into cantUni
                select new ProductUnidades {
                    N
                }

            ).FirstOrDefault();
        } */
}