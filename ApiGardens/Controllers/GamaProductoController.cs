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

public class GamaProductoController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GamaProductoController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<GamaProducto>>> Get()
    {
        var gamas = await _unitOfWork.GamaProductos.GetAllAsync();
        return _mapper.Map<List<GamaProducto>>(gamas);
    }

    /* Get Data by ID */
    [HttpGet("GetClientesGamasProducto")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<IEnumerable<ClienteGamaProductoDto>>> GetClientesGamasProducto()
    {
        var gamaPro = await _unitOfWork.GamaProductos.GetClientesGamasProducto();
        if (gamaPro == null)
        {
            return NotFound();
        }
        return _mapper.Map<List<ClienteGamaProductoDto>>(gamaPro);
    }
}