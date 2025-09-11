using ERP.Src.Domain.Entities;
using ERP.Src.Api.Dtos;

namespace ERP.Src.Application.Services.Interface
{
    public interface IEmpresaService
    {
        Task<Empresas> CreateAsync(EmpresaCreateDto empresaDto);
        Task<IEnumerable<Empresas>> GetAllAsync();
        Task<Empresas?> GetByIdAsync(int id);
        Task<Empresas?> UpdateAsync(Empresas empresa);
        Task<bool> DeleteAsync(int id);
    }
}
