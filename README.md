# GardensAppWebFiltro

Gardens Web Api 4 layers

# 1) Devuelve el listado de clientes indicando el nombre del cliente y cuántos pedidos ha realizado. Tenga en cuenta que pueden existir clientes que no han realizado ningún pedido.

- ## endpoint: http://localhost:5257/gardens//gardens/Cliente/GetCantidadPedidosCliente
- ## code:

  public async Task<IEnumerable<ClienteCantidadPedidos>> GetCantidadPedidosCliente()
  {
  return await (
  from cli in \_context.Clientes
  join ped in \_context.Pedidos
  on cli.CodigoCliente equals ped.CodigoCliente
  group cli by new { cli.NombreCliente } into pedCli
  /_ group pedCli by pedCli.Key.NombreCliente into NomCli _/
  select new ClienteCantidadPedidos
  {
  NombreCliente = pedCli.Key.NombreCliente,
  CantidadPedidos = pedCli.Count()
  }
  ).ToListAsync();
  }

- Primero hacemos un form \_context.Clientes para traer los datos de la tabla Clientes, hacemos un join con las tabla pedidos, agrupamos los registros repetidos con group teniendo en cuenta el nombre del cliente, asi con el metodo Count sabremos cuantos pedidos ha realizado el cliente, por ultimo creamos un nuevo objeto en base a la clase GetCantidadPedidosCliente y agregamos el dato que se nos pide en la consulta (NombreCliente y CantidadPedidos), retornamos la lista.

# 9) Devuelve el nombre de los clientes a los que no se les ha entregado a tiempo un pedido.

- ## endpoint: http://localhost:5257/gardens/Pedido/GetClientesPedidoRetrasado
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

# 10) Devuelve un listado de las diferentes gamas de producto que ha comprado cada cliente.

- ## endpoint: http://localhost:5257/gardens/GamaProducto/GetClientesGamasProducto
- ## code:

  public async Task<IEnumerable<ClienteGamaProducto>> GetClientesGamasProducto()
  {
  return await (
  from cli in \_context.Clientes
  join ped in \_context.Pedidos
  on cli.CodigoCliente equals ped.CodigoCliente
  join detp in \_context.DetallePedidos
  on ped.CodigoPedido equals detp.CodigoPedido
  join pro in \_context.Productos
  on detp.CodigoProducto equals pro.CodigoProducto
  join gamp in \_context.GamaProductos
  on pro.Gama equals gamp.Gama
  group gamp by new { gamp.Gama, cli.NombreCliente } into gamaPro
  select new ClienteGamaProducto
  {
  NombreCliente = gamaPro.Key.NombreCliente,
  NombreGama = gamaPro.Key.Gama
  }
  ).ToListAsync();
  }

- Primero hacemos un form \_context.Clientes para traer los datos de la tabla Cliente, hacemos un join con las tabla pedidos, detallepedidos, productos y gamaproductos para poder obtener el nombre de la gamma y el del cliente que ha comprado esa gama, agrupamos los registros repetidos con group, por ultimo creamos un nuevo objeto en base a la clase ClienteGamaProducto y agregamos el dato que se nos pide en la consulta (nomrbecliente y nombregama), retornamos la lista.
