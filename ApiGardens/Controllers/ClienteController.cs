using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiGardens.Dtos.Cliente;
using AutoMapper;
using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Data;

namespace ApiGardens.Controllers;

public class ClienteController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;
    private readonly ApiGardensContext _apiGardensContext;

    public ClienteController(IUnitOfWork unitOfWork, IMapper mapper, ApiGardensContext apiGardensContext)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
        _apiGardensContext = apiGardensContext;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<Cliente>>> Get()
    {
        var clientes = await _unitOfWork.Clientes.GetAllAsync();
        return _mapper.Map<List<Cliente>>(clientes);
    }

    /* Get Clientes Cantidad Pedidos por Cliente*/
    [HttpGet("GetCantidadPedidosCliente")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<ClienteCantidadPedidosDto>>> GetCantidadPedidosCliente()
    {
        var clientes = await _unitOfWork.Clientes.GetCantidadPedidosCliente();
        if (clientes == null)
        {
            return NotFound();
        }

        return _mapper.Map<List<ClienteCantidadPedidosDto>>(clientes);
    }
}