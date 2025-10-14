using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interface;
using ERP.Src.Application.Services.Interfaces;
using ERP.Src.Domain.Entities;
using ERP.Src.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Src.Application.Services
{
    public class EmpresaService : IEmpresaService
    {
        private readonly AppDbContext _context;
        private readonly IHistoricoAlteracaoService _historicoService;

        public EmpresaService(AppDbContext context, IHistoricoAlteracaoService historicoService)
        {
            _context = context;
            _historicoService = historicoService;
        }

        public async Task<EmpresaResponseDto?> CreateAsync(EmpresaCreateDto empresaDto)
        {
            var natureza = await ObterNaturezaJuridica(empresaDto.IdNaturezaJuridica);
            var tipoVinculo = await ObterTipoVinculoEmpresa(empresaDto.IdTipoVinculo);
            var cidade = await ObterOuCriarCidade(empresaDto.Endereco.Cidade);

            var endereco = new Endereco
            {
                Cep = empresaDto.Endereco.Cep,
                Logradouro = empresaDto.Endereco.Logradouro,
                Numero = empresaDto.Endereco.Numero,
                Complemento = empresaDto.Endereco.Complemento,
                Bairro = empresaDto.Endereco.Bairro,
                IdCidade = cidade.IdCidade,
                DataCadastro = DateTime.Now,
                DataAlteracao = DateTime.Now,
                FlgInativo = false
            };
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            var empresa = new Empresas
            {
                NomeFantasia = empresaDto.NomeFantasia,
                NumCnpj = empresaDto.NumCnpj,
                RazaoSocial = empresaDto.RazaoSocial,
                EmailEmpresa = empresaDto.EmailEmpresa,
                IdNaturezaJuridica = natureza.IdNaturezaJuridica,
                IdTipoVinculoEmpresa = tipoVinculo.IdTipoVinculoEmpresa,
                IdEndereco = endereco.IdEndereco,
                NumDddTelefone = empresaDto.NumDddTelefone,
                NumTelefone = empresaDto.NumTelefone,
                DataCadastro = DateTime.Now,
                DataAlteracao = DateTime.Now,
                FlgInativo = false
            };
            _context.Empresas.Add(empresa);
            await _context.SaveChangesAsync();

            var empresaRecemCriada = await _context.Empresas
                .Include(e => e.NaturezaJuridica)
                .Include(e => e.TipoVinculoEmpresa)
                .Include(e => e.Endereco)
                    .ThenInclude(end => end.Cidade)
                        .ThenInclude(c => c.Estado)
                            .ThenInclude(est => est.Regiao)
                .FirstOrDefaultAsync(e => e.IdEmpresa == empresa.IdEmpresa);

            if (empresaRecemCriada == null)
            {
                return null;
            }

            return new EmpresaResponseDto
            {
                IdEmpresa = empresaRecemCriada.IdEmpresa,
                NomeFantasia = empresaRecemCriada.NomeFantasia,
                RazaoSocial = empresaRecemCriada.RazaoSocial,
                NumCnpj = empresaRecemCriada.NumCnpj,
                EmailEmpresa = empresaRecemCriada.EmailEmpresa,
                NaturezaJuridica = empresaRecemCriada.NaturezaJuridica.NomeNaturezaJuridica,
                TipoVinculo = empresaRecemCriada.TipoVinculoEmpresa.NomeTipoVinculoEmpresa,
                Endereco = $"{empresaRecemCriada.Endereco.Logradouro}, {empresaRecemCriada.Endereco.Numero}",
                Cidade = empresaRecemCriada.Endereco.Cidade.NomeCidade,
                Estado = empresaRecemCriada.Endereco.Cidade.Estado.NomeEstado,
                Regiao = empresaRecemCriada.Endereco.Cidade.Estado.Regiao.NomeRegiao
            };
        }

        private async Task<NaturezaJuridica> ObterNaturezaJuridica(int idNatureza)
        {
            var natureza = await _context.NaturezasJuridicas
                .FirstOrDefaultAsync(n => n.IdNaturezaJuridica == idNatureza);

            if (natureza is null)
                throw new ArgumentException("Natureza Jurídica inválida.");

            return natureza;
        }

        private async Task<TipoVinculoEmpresa> ObterTipoVinculoEmpresa(int idTipoVinculo)
        {
            var tipoVinculo = await _context.TiposVinculoEmpresa
                .FirstOrDefaultAsync(t => t.IdTipoVinculoEmpresa == idTipoVinculo);

            if (tipoVinculo is null)
                throw new ArgumentException("Tipo de Vínculo inválido.");

            return tipoVinculo;
        }

        private async Task<Cidade> ObterOuCriarCidade(CidadeCreateDto cidadeDto)
        {
            var cidade = await _context.Cidades
                .FirstOrDefaultAsync(c =>
                    c.NomeCidade == cidadeDto.NomeCidade &&
                    c.IdEstado == cidadeDto.IdEstado);

            if (cidade is not null)
                return cidade;

            var novaCidade = new Cidade
            {
                NomeCidade = cidadeDto.NomeCidade,
                SiglaEstado = cidadeDto.SiglaEstado,
                IdEstado = cidadeDto.IdEstado,
                DataCadastro = DateTime.Now,
                FlgInativo = false
            };

            _context.Cidades.Add(novaCidade);
            await _context.SaveChangesAsync();

            return novaCidade;
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
