using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class DetallePedidoRepo : GenericRepository<DetallePedido>, IDetallePedido
{
    private readonly ApiGardensContext _context;

    public DetallePedidoRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }
}