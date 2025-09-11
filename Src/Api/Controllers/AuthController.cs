using ERP.Src.Application.Services;
using ERP.Src.Api.DTO;
using ERP.Src.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            try
            {
                var usuario = await _authService.RegisterAsync(dto.NomeLogin, dto.EmailLogin, dto.Senha, dto.IdPermissao, dto.IdNivelAcesso);
                return Ok(new { usuario.IdLogin, usuario.NomeLogin, usuario.EmailLogin });
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            try
            {
                var token = await _authService.LoginAsync(dto.EmailLogin, dto.Senha);
                return Ok(new AuthResponseDto
                {
                    Token = token,
                    NomeLogin = dto.EmailLogin,
                    EmailLogin = dto.EmailLogin
                });
            }
            catch (Exception ex)
            {
                return Unauthorized(new { mensagem = ex.Message });
            }
        }
    }
}
