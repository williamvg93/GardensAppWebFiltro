using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class ClienteRepo : GenericRepository<Cliente>, ICliente
{
    private readonly ApiGardensContext _context;

    public ClienteRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }
}