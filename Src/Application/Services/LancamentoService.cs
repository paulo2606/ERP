using ERP.Src.Infraestructure.Data;
using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interfaces;
using ERP.Src.Domain.Entities;
using ERP.Src.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Src.Application.Services
{
    public class LancamentoService : ILancamentoService
    {
        private readonly AppDbContext _context;

        public LancamentoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Lancamento> CreateAsync(CreateLancamentoDto dto, int userId)
        {
            var lancamento = new Lancamento
            {
                DescricaoLancamento = dto.DescricaoLancamento,
                ValorLancamentoPrevisto = dto.ValorLancamentoPrevisto,
                IdSituacaoLancamento = dto.IdSituacaoLancamento,
                IdEmpresa = dto.IdEmpresa,
                IdCategoria = dto.IdCategoria,
                IdCentroCusto = dto.IdCentroCusto,
                DataLancamento = DateTime.Now,
                DataCadastro = DateTime.Now,
                FlagInativo = false,
                IdResponsavelCriacao = userId
            };

            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();

            return lancamento;
        }

        public async Task<LancamentoDto?> GetByIdAsync(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            return lancamento == null ? null : MapToDto(lancamento);
        }

        public async Task<IEnumerable<LancamentoDto>> GetAllAsync()
        {
            var lancamentos = await _context.Lancamentos
                .Where(l => !l.FlagInativo)
                .ToListAsync();

            return lancamentos.Select(MapToDto);
        }

        public async Task<bool> UpdateAsync(int id, CreateLancamentoDto dto, int userId)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null) return false;

            lancamento.DescricaoLancamento = dto.DescricaoLancamento;
            lancamento.ValorLancamentoPrevisto = dto.ValorLancamentoPrevisto;
            lancamento.IdSituacaoLancamento = dto.IdSituacaoLancamento;
            lancamento.IdEmpresa = dto.IdEmpresa;
            lancamento.IdCategoria = dto.IdCategoria;
            lancamento.IdCentroCusto = dto.IdCentroCusto;
            lancamento.DataAlteracao = DateTime.Now;
            lancamento.IdResponsavelAlteracao = userId;

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> SoftDeleteAsync(int id, int idUsuario)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null || lancamento.FlagInativo) return false;

            lancamento.FlagInativo = true;
            lancamento.IdResponsavelAlteracao = idUsuario;
            lancamento.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        private LancamentoDto MapToDto(Lancamento lancamento)
        {
            return new LancamentoDto
            {
                IdLancamento = lancamento.IdLancamento,
                DescricaoLancamento = lancamento.DescricaoLancamento,
                ValorLancamentoPrevisto = lancamento.ValorLancamentoPrevisto,
                DataLancamento = lancamento.DataLancamento,
                IdSituacaoLancamento = lancamento.IdSituacaoLancamento,
                IdEmpresa = lancamento.IdEmpresa,
                IdCategoria = lancamento.IdCategoria,
                IdCentroCusto = lancamento.IdCentroCusto,
                IdResponsavelCriacao = lancamento.IdResponsavelCriacao,
                IdResponsavelAlteracao = lancamento.IdResponsavelAlteracao,
                DataCadastro = lancamento.DataCadastro,
                DataAlteracao = lancamento.DataAlteracao,
                FlagInativo = lancamento.FlagInativo
            };
        }

        Task<LancamentoDto> ILancamentoService.CreateAsync(CreateLancamentoDto dto, int userId)
        {
            throw new NotImplementedException();
        }

        public Task<LancamentoDto?> UpdateAsync(int id, UpdateLancamentoDto dto, int userId)
        {
            throw new NotImplementedException();
        }
    }
}
