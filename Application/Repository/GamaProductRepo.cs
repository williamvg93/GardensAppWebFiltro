using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class GamaProductRepo : GenericRepository<GamaProducto>, IGamaProducto
{
    private readonly ApiGardensContext _context;

    public GamaProductRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }
}