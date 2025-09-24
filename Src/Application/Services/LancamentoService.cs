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

        public async Task<LancamentoDto> CreateAsync(CreateLancamentoDto dto, int userId)
        {
            var lancamento = new Lancamento
            {
                DescricaoLancamento = dto.DescricaoLancamento,
                ValorLancamentoPrevisto = dto.ValorLancamentoPrevisto,
                DataLancamento = DateTime.Now,
                IdSituacaoLancamento = dto.IdSituacaoLancamento,
                IdEmpresa = dto.IdEmpresa,
                IdCategoria = dto.IdCategoria,
                IdCentroCusto = dto.IdCentroCusto,
                IdResponsavelCriacao = userId,
                IdResponsavelAlteracao = userId,
                DataCadastro = DateTime.Now,
                DataAlteracao = DateTime.Now,
                FlagInativo = false
            };

            _context.Lancamentos.Add(lancamento);
            await _context.SaveChangesAsync();

            return MapToDto(lancamento);
        }

        public async Task<LancamentoDto?> GetByIdAsync(int id)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            return lancamento == null ? null : MapToDto(lancamento);
        }

        public async Task<IEnumerable<LancamentoDto>> GetAllAsync()
        {
            var lancamentos = await _context.Lancamentos.ToListAsync();
            return lancamentos.Select(MapToDto);
        }

        public async Task<LancamentoDto?> UpdateAsync(int id, UpdateLancamentoDto dto, int userId)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null) return null;

            lancamento.DescricaoLancamento = dto.DescricaoLancamento;
            lancamento.ValorLancamentoPrevisto = dto.ValorLancamentoPrevisto;
            lancamento.IdSituacaoLancamento = dto.IdSituacaoLancamento;
            lancamento.IdEmpresa = dto.IdEmpresa;
            lancamento.IdCategoria = dto.IdCategoria;
            lancamento.IdCentroCusto = dto.IdCentroCusto;
            lancamento.IdResponsavelAlteracao = userId;
            lancamento.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();

            return MapToDto(lancamento);
        }

        public async Task<bool> SoftDeleteAsync(int id, int userId)
        {
            var lancamento = await _context.Lancamentos.FindAsync(id);
            if (lancamento == null) return false;

            lancamento.FlagInativo = true;
            lancamento.IdResponsavelAlteracao = userId;
            lancamento.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();

            return true;
        }

        private LancamentoDto MapToDto(Lancamento l) =>
            new LancamentoDto
            {
                IdLancamento = l.IdLancamento,
                DescricaoLancamento = l.DescricaoLancamento,
                ValorLancamentoPrevisto = l.ValorLancamentoPrevisto,
                DataLancamento = l.DataLancamento,
                IdSituacaoLancamento = l.IdSituacaoLancamento,
                IdEmpresa = l.IdEmpresa,
                IdCategoria = l.IdCategoria,
                IdCentroCusto = l.IdCentroCusto,
                IdResponsavelCriacao = l.IdResponsavelCriacao,
                IdResponsavelAlteracao = l.IdResponsavelAlteracao,
                DataCadastro = l.DataCadastro,
                DataAlteracao = l.DataAlteracao,
                FlagInativo = l.FlagInativo
            };
    }
}
