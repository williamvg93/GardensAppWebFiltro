using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interfaces;
using Persistence.Data;

namespace Application.Repository;

public class EmpleadoRepo : GenericRepository<Empleado>, IEmpleado
{
    private readonly ApiGardensContext _context;

    public EmpleadoRepo(ApiGardensContext context) : base(context)
    {
        _context = context;
    }
}