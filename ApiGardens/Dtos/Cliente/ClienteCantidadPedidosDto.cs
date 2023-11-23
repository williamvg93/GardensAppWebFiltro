using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGardens.Dtos.Cliente;

public class ClienteCantidadPedidosDto
{
    public string NombreCliente { get; set; }
    public int CantidadPedidos { get; set; }
}
