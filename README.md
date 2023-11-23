# GardensAppWebFiltro

Gardens Web Api 4 layers

# Devuelve el nombre de los clientes a los que no se les ha entregado a tiempo un pedido.

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

# Devuelve un listado de las diferentes gamas de producto que ha comprado cada cliente.

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

- Primero hacemos un form \_context.Clientes para traer los datos de la tabla pedido, hacemos un join con las tabla pedidos, detallepedidos, productos y gamaproductos para poder obtener el nombre de la gamma y el del cliente que ha comprado esa gama, agrupamos los registros repetidos con group, por ultimo creamos un nuevo objeto en base a la clase ClienteGamaProducto y agregamos el dato que se nos pide en la consulta (nomrbecliente y nombregama), retornamos la lista.
