using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Entities.Query;

namespace Domain.Interfaces;

public interface ICliente : IGenericRepository<Cliente>
{
    Task<IEnumerable<ClienteCantidadPedidos>> GetCantidadPedidosCliente();

}