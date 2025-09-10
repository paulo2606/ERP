using ERP.Scr.Domain.Entities;
using ERP.Scr.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ERP.Src.Application.Services
{
    public class AuthService
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
                .Include(u => u.Permissao)
                .Include(u => u.NivelAcesso)
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

        private string GenerateJwtToken(Login usuario)
        {
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.NomeLogin),
                new Claim(ClaimTypes.Email, usuario.EmailLogin),
                new Claim("IdUsuario", usuario.IdLogin.ToString()),
                new Claim("Permissao", usuario.Permissao.NomePermissao),
                new Claim("NivelAcesso", usuario.NivelAcesso.NomeNivel)
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
}
