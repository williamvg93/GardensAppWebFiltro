using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class PedidoRepo : GenericRepository<Pedido>, IPedido
{
    private readonly ApiGardensContext _context;

    public PedidoRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }
}