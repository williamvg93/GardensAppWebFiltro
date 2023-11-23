using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Interfaces;

public interface IPedido : IGenericRepository<Pedido>
{
    Task<IEnumerable<Cliente>> GetClientesPedidoRetrasado();
    Task<IEnumerable<Pedido>> GetClientesPedidoRetrasadoData();
}