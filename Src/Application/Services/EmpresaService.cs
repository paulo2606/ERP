using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interface;
using ERP.Src.Domain.Entities;
using ERP.Src.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Src.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly AppDbContext _context;

        public EmpresaService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<Empresas> CreateAsync(EmpresaCreateDto empresaDto)
        {
            var empresa = new Empresas
            {
                NomeFantasia = empresaDto.NomeFantasia,
                NumCnpj = empresaDto.NumCnpj,
                RazaoSocial = empresaDto.RazaoSocial,
                EmailEmpresa = empresaDto.EmailEmpresa,

                IdNaturezaJuridica = empresaDto.IdNaturezaJuridica,
                IdTipoVinculoEmpresa = empresaDto.IdTipoVinculoEmpresa,
                IdEndereco = empresaDto.IdEndereco,

                NumDddTelefone = empresaDto.NumDddTelefone,
                NumTelefone = empresaDto.NumTelefone,
                DataCadastro = DateTime.Now,
                DataAlteracao = DateTime.Now,
                FlgInativo = false
            };

            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            return empresa;
        }


        public async Task<IEnumerable<Empresas>> GetAllAsync()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresas?> GetByIdAsync(int id)
        {
            return await _context.Empresas.FindAsync(id);
        }

        public async Task<Empresas?> UpdateAsync(Empresas empresa)
        {
            var existente = await _context.Empresas.FindAsync(empresa.IdEmpresa);
            if (existente == null) return null;

            existente.NomeFantasia = empresa.NomeFantasia;
            existente.NumCnpj = empresa.NumCnpj;
            existente.RazaoSocial = empresa.RazaoSocial;
            existente.EmailEmpresa = empresa.EmailEmpresa;
            existente.IdNaturezaJuridica = empresa.IdNaturezaJuridica;
            existente.IdTipoVinculoEmpresa = empresa.IdTipoVinculoEmpresa;
            existente.IdEndereco = empresa.IdEndereco;
            existente.NumDddTelefone = empresa.NumDddTelefone;
            existente.NumTelefone = empresa.NumTelefone;
            existente.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();
            return existente;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null) return false;

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
