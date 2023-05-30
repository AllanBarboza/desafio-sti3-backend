using System;
using System.Threading.Tasks;
using AgendaTelefonica.Assets;
using AgendaTelefonica.Data.Repositories;
using AgendaTelefonica.DTOs;
using AgendaTelefonica.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class ClienteController : ControllerBase
    {
        private IClienteRepository _repository;
        private readonly IMapper _mapper;
        public ClienteController(IClienteRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Create([FromBody] CreateClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var cliente = _mapper.Map<Cliente>(dto);

            try
            {
                await _repository.Create(cliente);
                return Created($"v1/usuario/{cliente.Id}", new { Id = cliente.Id });
            }
            catch
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR });
            }
        }
        [HttpPut]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Update([FromBody] UpdateClienteDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var cliente = await _repository.GetById(dto.Id);
                if (cliente == null)
                    return NotFound(new { message = Messages.CUSTOMER_NOT_FOUND });

                cliente = _mapper.Map<Cliente>(dto);

                await _repository.Update(cliente);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR });
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var cliente = await _repository.GetById(id);
                if (cliente == null)
                    return NotFound(new { message = Messages.CUSTOMER_NOT_FOUND });

                await _repository.Delete(cliente);
                return Ok();
            }
            catch
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR });
            }
        }
        [HttpGet]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var clientes = await _repository.Get();
                return Ok(_mapper.Map<GetClienteDto[]>(clientes));
            }
            catch
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR });
            }
        }
        [HttpGet("{id}")]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Get([FromRoute] Guid id)
        {
            try
            {
                var cliente = await _repository.GetById(id);
                if (cliente == null)
                    return NotFound(new { message = Messages.CUSTOMER_NOT_FOUND });
                return Ok(_mapper.Map<GetClienteDto>(cliente));
            }
            catch
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR });
            }
        }
    }
}