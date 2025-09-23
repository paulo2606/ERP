using ERP.Src.Api.Dtos;
using ERP.Src.Domain.Entities;

namespace ERP.Src.Application.Services.Interfaces
{
    public interface ILancamentoService
    {
        Task<LancamentoDto> CreateAsync(CreateLancamentoDto dto, int userId);
        Task<LancamentoDto?> GetByIdAsync(int id);
        Task<IEnumerable<LancamentoDto>> GetAllAsync();
        Task<LancamentoDto?> UpdateAsync(int id, UpdateLancamentoDto dto, int userId);
        Task<bool> SoftDeleteAsync(int id, int idUsuario);
    }
}
