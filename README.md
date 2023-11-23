# GardensAppWebFiltro

Gardens Web Api 4 layers

# Devuelve el nombre de los clientes a los que no se les ha entregado a tiempo un pedido.

- ## endpoint: /gardens/Pedido/GetClientesPedidoRetrasado
- ## code:

  public async Task<IEnumerable<Cliente>> GetClientesPedidoRetrasado()
  {
  return await (

            from ped in _context.Pedidos
            where ped.FechaEntrega.Year >= ped.FechaEsperada.Year && ped.FechaEntrega.Month >= ped.FechaEsperada.Month && ped.FechaEntrega.Day > ped.FechaEsperada.Day
            join cli in _context.Clientes
            on ped.CodigoCliente equals cli.CodigoCliente
            group cli by cli.NombreCliente into pedCli
            select new Cliente
            {
                NombreCliente = pedCli.Key
            }
        ).ToListAsync();

  }

- Primero hacemos un form \_context.Pedidos para traer los datos de la tabla pedido, despues colocamos
  una condicion para que nos de solo los pedidos que llegaron tarde, hacemos un join con la tabla clientes para
  poder obtener el nombre del cliente, agrupamos los registros repetidos con group, por ultimo creamos un nuevo objeto en
  base a la clase cliente y agregamos el dato que se nos pide en la consulta (nomrbe cliente), retornamos la lista.
