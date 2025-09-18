using ERP.Src.Domain.Entities;
using ERP.Src.Api.Dtos;

namespace ERP.Src.Application.Services.Interface
{
    public interface IEmpresaService
    {
        Task<EmpresaResponseDto?> CreateAsync(EmpresaCreateDto empresaDto);
        Task<IEnumerable<EmpresaResponseDto>> GetAllAsync();
        Task<EmpresaResponseDto?> GetEmpresaByIdAsync(int id);
        Task<bool> UpdateEmpresaAsync(int id, EmpresaUpdateDto empresaDto);
        Task<bool> DeleteAsync(int id);
    }
}
