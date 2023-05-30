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
    public class TelefoneController : ControllerBase
    {
        private ITelefoneRepository _repository;
        private IMapper _mapper;
        public TelefoneController(ITelefoneRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        [HttpPost]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Create([FromBody] CreateTelefoneDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var clienteTelefone = _mapper.Map<ClienteTelefone>(dto);

            try
            {
                await _repository.Create(clienteTelefone);
                return Created($"v1/ClienteTelefone/{clienteTelefone.Id}", new { Id = clienteTelefone.Id });
            }
            catch (System.Exception e)
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR, e });
            }
        }
        [HttpPut]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Update([FromBody] UpdateTelefoneDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var telefone = await _repository.GetById(dto.Id);

                if (telefone == null)
                    return NotFound();


                var clienteId = telefone.ClienteId;
                telefone = _mapper.Map<ClienteTelefone>(dto);
                telefone.ClienteId = clienteId;

                await _repository.Update(telefone);
                return Ok();
            }
            catch (System.Exception e)
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR, e });
            }
        }
        [HttpDelete("{id}")]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            try
            {
                var telefone = await _repository.GetById(id);

                if (telefone == null)
                    return NotFound();
                await _repository.Delete(telefone);
                return Ok();
            }
            catch (System.Exception e)
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR, e });
            }
        }
        [HttpGet]
        [Authorize(Roles = Roles.USER)]
        public async Task<IActionResult> Get([FromQuery] Guid clienteId)
        {
            try
            {
                var telefones = await _repository.Get(clienteId);

                return Ok(_mapper.Map<GetTelefoneDto[]>(telefones));
            }
            catch (System.Exception e)
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR, e });
            }
        }
    }
}