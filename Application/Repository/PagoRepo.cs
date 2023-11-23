using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class PagoRepo : GenericRepository<Pago>, IPago
{
    private readonly ApiGardensContext _context;

    public PagoRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }
}