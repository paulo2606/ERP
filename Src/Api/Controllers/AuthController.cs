using ERP.Src.Api.DTO;
using ERP.Src.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [AllowAnonymous]
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

    [AllowAnonymous]
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
    {
        try
        {
            var token = await _authService.LoginAsync(loginDto.EmailLogin, loginDto.Senha);
            return Ok(new { token });
        }
        catch (Exception ex)
        {
            return Unauthorized(new { mensagem = ex.Message });
        }
    }
}
