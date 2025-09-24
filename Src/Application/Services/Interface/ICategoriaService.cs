using ERP.Src.Api.Dtos;

namespace ERP.Src.Application.Services.Interfaces
{
    public interface ICategoriaService
    {
        Task<IEnumerable<CategoriaDto>> GetAllAsync();
        Task<CategoriaDto?> GetByIdAsync(int id);
        Task<CategoriaDto> CreateAsync(CreateCategoriaDto dto, int userId);
        Task<CategoriaDto?> UpdateAsync(int id, UpdateCategoriaDto dto, int userId);
        Task<bool> SoftDeleteAsync(int id, int userId);
    }
}
