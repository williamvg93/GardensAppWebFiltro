using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Repository;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.UnitOfWork;

public class UnitOfWork : IUnitOfWork, IDisposable
{
    private readonly ApiGardensContext _context;
    private ICliente _clientes;
    private IDetallePedido _detallePedis;
    private IEmpleado _empleados;
    private IGamaProducto _gamaProductos;
    private IOficina _oficinas;
    private IPago _pagos;
    private IPedido _pedidos;
    private IProducto _productos;

    public UnitOfWork(ApiGardensContext context)
    {
        _context = context;
    }

    public ICliente Clientes
    {
        get
        {
            if (_clientes == null)
            {
                _clientes = new ClienteRepo(_context);
            }
            return _clientes;
        }
    }

    public IDetallePedido DetallePedidos
    {
        get
        {
            if (_detallePedis == null)
            {
                _detallePedis = new DetallePedidoRepo(_context);
            }
            return _detallePedis;
        }
    }

    public IEmpleado Empleados
    {
        get
        {
            if (_empleados == null)
            {
                _empleados = new EmpleadoRepo(_context);
            }
            return _empleados;
        }
    }

    public IGamaProducto GamaProductos
    {
        get
        {
            if (_gamaProductos == null)
            {
                _gamaProductos = new GamaProductRepo(_context);
            }
            return _gamaProductos;
        }
    }

    public IOficina Oficinas
    {
        get
        {
            if (_oficinas == null)
            {
                _oficinas = new OficinaRepo(_context);
            }
            return _oficinas;
        }
    }

    public IPago Pagos
    {
        get
        {
            if (_pagos == null)
            {
                _pagos = new PagoRepo(_context);
            }
            return _pagos;
        }
    }

    public IPedido Pedidos
    {
        get
        {
            if (_pedidos == null)
            {
                _pedidos = new PedidoRepo(_context);
            }
            return _pedidos;
        }
    }

    public IProducto Productos
    {
        get
        {
            if (_productos == null)
            {
                _productos = new ProductoRepo(_context);
            }
            return _productos;
        }
    }


    public async Task<int> SaveAsync()
    {
        return await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}