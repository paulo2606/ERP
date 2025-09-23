using ERP.Src.Application.Services.Interfaces;
using ERP.Src.Domain.Entities;
using ERP.Src.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

public class AuthService : IAuthService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;

    public AuthService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
    }

    public async Task<Login> RegisterAsync(string nome, string email, string senha, int idPermissao, int idNivelAcesso)
    {
        if (await _context.Login.AnyAsync(u => u.EmailLogin == email))
            throw new Exception("E-mail já registrado.");

        var hashedPassword = HashPassword(senha);

        var usuario = new Login
        {
            NomeLogin = nome,
            EmailLogin = email,
            SenhaHash = hashedPassword,
            IdPermissao = idPermissao,
            IdNivelAcesso = idNivelAcesso,
            DataCadastro = DateTime.Now,
            DataAlteracao = DateTime.Now,
            FlgInativo = false
        };

        _context.Login.Add(usuario);
        await _context.SaveChangesAsync();

        return usuario;
    }

    public async Task<string> LoginAsync(string email, string senha)
    {
        var usuario = await _context.Login
            .FirstOrDefaultAsync(u => u.EmailLogin == email);

        if (usuario == null || !VerifyPassword(senha, usuario.SenhaHash))
            throw new Exception("E-mail ou senha inválidos.");

        return GenerateJwtToken(usuario);
    }

    private string HashPassword(string senha)
    {
        using var sha256 = SHA256.Create();
        var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(senha));
        return Convert.ToBase64String(hashedBytes);
    }

    private bool VerifyPassword(string senhaDigitada, string senhaHash)
    {
        var hashInput = HashPassword(senhaDigitada);
        return hashInput == senhaHash;
    }

    public string GenerateJwtToken(Login user)
    {
        var claims = new[]
        {
            new Claim("id", user.IdLogin.ToString()),
            new Claim(ClaimTypes.Name, user.NomeLogin),
            new Claim(ClaimTypes.Email, user.EmailLogin),
            new Claim("permissao", user.IdPermissao.ToString()),
            new Claim("nivel", user.IdNivelAcesso.ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: creds
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
