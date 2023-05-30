using System.Threading.Tasks;
using AgendaTelefonica.Assets;
using AgendaTelefonica.Data.Repositories;
using AgendaTelefonica.DTOs;
using AgendaTelefonica.Services;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AgendaTelefonica.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private IAuthService _authService;
        private IUsuarioRepository _repository;
        private ICryptographyService _cryptographyService;
        private readonly IMapper _mapper;

        public AuthController(IAuthService authService, IUsuarioRepository repository, ICryptographyService cryptographyService, IMapper mapper)
        {
            _authService = authService;
            _repository = repository;
            _cryptographyService = cryptographyService;
            _mapper = mapper;
        }


        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> GetToken([FromBody] AuthDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            dto.Password = _cryptographyService.createHash(dto.Password);
            try
            {
                var usuario = await _repository.GetByCredentials(dto.Email, dto.Password);
                if (usuario == null)
                    return NotFound(new { message = Messages.USER_NOT_FOUND });

                var token = _authService.GenerateToken(usuario);
                return Ok(new { name = usuario.Name, email = usuario.Email, token = token });

            }
            catch
            {
                return StatusCode(500, new { message = Messages.INTERNAL_SERVER_ERROR });
            }
        }
    }
}