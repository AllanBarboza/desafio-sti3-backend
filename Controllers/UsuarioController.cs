using System.Threading.Tasks;
using AgendaTelefonica.Assets;
using AgendaTelefonica.Data.Repositories;
using AgendaTelefonica.DTOs;
using AgendaTelefonica.Models;
using AgendaTelefonica.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.Controllers
{

    [ApiController]
    [Route("v1/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _repository;
        private ICryptographyService _cryptographyService;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository repository, ICryptographyService cryptographyService, IMapper mapper)
        {
            _repository = repository;
            _cryptographyService = cryptographyService;
            _mapper = mapper;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Create([FromBody] CreateUsuarioDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                var registered = await _repository.GetByEmail(dto.Email);
                if (registered != null)
                    return Conflict(new { message = Messages.EMAIL_ALREADY_REGISTERED });

                var usuario = _mapper.Map<Usuario>(dto);
                usuario.Password = _cryptographyService.createHash(usuario.Password);

                await _repository.Create(usuario);
                return Created($"v1/usuario/{usuario.Id}", new { Id = usuario.Id });
            }
            catch
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR });
            }
        }
    }
}