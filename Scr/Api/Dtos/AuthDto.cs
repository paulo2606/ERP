namespace ERP.Src.Api.DTO
{
    public class RegisterDto
    {
        public string NomeLogin { get; set; } = null!;
        public string EmailLogin { get; set; } = null!;
        public string Senha { get; set; } = null!;
        public int IdPermissao { get; set; }
        public int IdNivelAcesso { get; set; }
    }

    public class LoginDto
    {
        public string EmailLogin { get; set; } = null!;
        public string Senha { get; set; } = null!;
    }

    public class AuthResponseDto
    {
        public string Token { get; set; } = null!;
        public string NomeLogin { get; set; } = null!;
        public string EmailLogin { get; set; } = null!;
    }
}
