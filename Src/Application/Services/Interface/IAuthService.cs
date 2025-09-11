using ERP.Src.Domain.Entities;

namespace ERP.Src.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Login> RegisterAsync(string nome, string email, string senha, int idPermissao, int idNivelAcesso);
        Task<string> LoginAsync(string email, string senha);
    }
}
