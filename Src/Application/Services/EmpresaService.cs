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

        public async Task<IEnumerable<EmpresaResponseDto>> GetAllAsync()
        {
            var empresas = await _context.Empresas
                .Include(e => e.NaturezaJuridica)
                .Include(e => e.TipoVinculoEmpresa)
                .Include(e => e.Endereco)
                    .ThenInclude(end => end.Cidade)
                        .ThenInclude(c => c.Estado)
                            .ThenInclude(est => est.Regiao)
                .Select(e => new EmpresaResponseDto
                {
                    IdEmpresa = e.IdEmpresa,
                    NomeFantasia = e.NomeFantasia,
                    RazaoSocial = e.RazaoSocial,
                    NumCnpj = e.NumCnpj,
                    EmailEmpresa = e.EmailEmpresa,
                    NaturezaJuridica = e.NaturezaJuridica.NomeNaturezaJuridica,
                    TipoVinculo = e.TipoVinculoEmpresa.NomeTipoVinculoEmpresa,
                    Endereco = e.Endereco.Logradouro + ", " + e.Endereco.Numero,
                    Cidade = e.Endereco.Cidade.NomeCidade,
                    Estado = e.Endereco.Cidade.Estado.NomeEstado,
                    Regiao = e.Endereco.Cidade.Estado.Regiao.NomeRegiao
                })
                .ToListAsync(); 

            return (empresas);
        }

        public async Task<EmpresaResponseDto?> GetEmpresaByIdAsync(int id)
        {
            var empresa = await _context.Empresas
                .Include(e => e.NaturezaJuridica)
                .Include(e => e.TipoVinculoEmpresa)
                .Include(e => e.Endereco)
                    .ThenInclude(end => end.Cidade)
                        .ThenInclude(c => c.Estado)
                            .ThenInclude(est => est.Regiao)
                .FirstOrDefaultAsync(e => e.IdEmpresa == id);

            if (empresa == null)
                return null;

            return new EmpresaResponseDto
            {
                IdEmpresa = empresa.IdEmpresa,
                NomeFantasia = empresa.NomeFantasia,
                RazaoSocial = empresa.RazaoSocial,
                NumCnpj = empresa.NumCnpj,
                EmailEmpresa = empresa.EmailEmpresa,
                NaturezaJuridica = empresa.NaturezaJuridica.NomeNaturezaJuridica,
                TipoVinculo = empresa.TipoVinculoEmpresa.NomeTipoVinculoEmpresa,
                Endereco = $"{empresa.Endereco.Logradouro}, {empresa.Endereco.Numero}",
                Cidade = empresa.Endereco.Cidade.NomeCidade,
                Estado = empresa.Endereco.Cidade.Estado.NomeEstado,
                Regiao = empresa.Endereco.Cidade.Estado.Regiao.NomeRegiao
            };
        }

        public async Task<bool> UpdateEmpresaAsync(int id, EmpresaUpdateDto empresaDto)
        {
            var empresa = await _context.Empresas.FirstOrDefaultAsync(e => e.IdEmpresa == id);
            if (empresa == null) return false;

            empresa.NomeFantasia = empresaDto.NomeFantasia;
            empresa.RazaoSocial = empresaDto.RazaoSocial;
            empresa.NumCnpj = empresaDto.NumCnpj;
            empresa.EmailEmpresa = empresaDto.EmailEmpresa;
            empresa.IdNaturezaJuridica = empresaDto.IdNaturezaJuridica;
            empresa.IdTipoVinculoEmpresa = empresaDto.IdTipoVinculoEmpresa;
            empresa.IdEndereco = empresaDto.IdEndereco;
            empresa.NumDddTelefone = empresaDto.NumDddTelefone;
            empresa.NumTelefone = empresaDto.NumTelefone;
            empresa.DataAlteracao = DateTime.Now;

            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null) return false;

            empresa.FlgInativo = true;

            _context.Empresas.Update(empresa);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
