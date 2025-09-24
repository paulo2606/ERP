using ERP.Src.Api.Dtos;

namespace ERP.Src.Application.Services.Interfaces
{
    public interface ICentroCustoService
    {
        Task<CentroCustoDto> CreateAsync(CreateCentroCustoDto dto, int userId);
        Task<CentroCustoDto?> GetByIdAsync(int id);
        Task<IEnumerable<CentroCustoDto>> GetAllAsync();
        Task<CentroCustoDto?> UpdateAsync(int id, UpdateCentroCustoDto dto, int userId);
        Task<bool> SoftDeleteAsync(int id, int userId);
    }
}
