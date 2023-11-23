using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGardens.Dtos.Cliente;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiGardens.Controllers;

public class PedidoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PedidoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Pedido>>> Get()
    {
        var clientes = await _unitOfWork.Pedidos.GetAllAsync();
        return _mapper.Map<List<Pedido>>(clientes);
    }

    /* Get Codigo de Clientes con Pedidos Retrasado */
    [HttpGet("GetClientesPedidoRetrasado")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<ClienteNombreDto>>> GetClientesPedidoRetrasado()
    {
        var pedidos = await _unitOfWork.Pedidos.GetClientesPedidoRetrasado();
        if (pedidos == null)
        {
            return NotFound();
        }
        return _mapper.Map<List<ClienteNombreDto>>(pedidos);
    }

    /* Get Codigo de Clientes con Pedidos Retrasado */
    [HttpGet("GetClientesPedidoRetrasadoData")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<ClientePedidoDto>>> GetClientesPedidoRetrasadoData()
    {
        var pedidos = await _unitOfWork.Pedidos.GetClientesPedidoRetrasadoData();
        if (pedidos == null)
        {
            return NotFound();
        }
        return _mapper.Map<List<ClientePedidoDto>>(pedidos);
    }
}