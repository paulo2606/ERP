using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interfaces;
using ERP.Src.Domain.Entities;
using ERP.Src.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Src.Application.Services
{
    public class CentroCustoService : ICentroCustoService
    {
        private readonly AppDbContext _context;

        public CentroCustoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CentroCustoDto> CreateAsync(CreateCentroCustoDto dto, int userId)
        {
            var centro = new CentroCusto
            {
                NomeCentroCusto = dto.NomeCentroCusto,
                Descricao = dto.Descricao,
                CodigoCentroCusto = dto.CodigoCentroCusto,
                DataCadastro = DateTime.Now,
                DataAlteracao = DateTime.Now,
                FlgInativo = false
            };

            _context.CentroCusto.Add(centro);
            await _context.SaveChangesAsync();

            return MapToDto(centro);
        }

        public async Task<CentroCustoDto?> GetByIdAsync(int id)
        {
            var centro = await _context.CentroCusto.FindAsync(id);
            return centro == null ? null : MapToDto(centro);
        }

        public async Task<IEnumerable<CentroCustoDto>> GetAllAsync()
        {
            var centros = await _context.CentroCusto.ToListAsync();
            return centros.Select(MapToDto);
        }

        public async Task<CentroCustoDto?> UpdateAsync(int id, UpdateCentroCustoDto dto, int userId)
        {
            var centro = await _context.CentroCusto.FindAsync(id);
            if (centro == null) return null;

            centro.NomeCentroCusto = dto.NomeCentroCusto;
            centro.Descricao = dto.Descricao;
            centro.CodigoCentroCusto = dto.CodigoCentroCusto;
            centro.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();

            return MapToDto(centro);
        }

        public async Task<bool> SoftDeleteAsync(int id, int userId)
        {
            var centro = await _context.CentroCusto.FindAsync(id);
            if (centro == null) return false;

            centro.FlgInativo = true;
            centro.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        private CentroCustoDto MapToDto(CentroCusto c) =>
            new CentroCustoDto
            {
                IdCentroCusto = c.IdCentroCusto,
                NomeCentroCusto = c.NomeCentroCusto,
                Descricao = c.Descricao,
                CodigoCentroCusto = c.CodigoCentroCusto,
                DataCadastro = c.DataCadastro,
                DataAlteracao = c.DataAlteracao,
                FlgInativo = c.FlgInativo
            };
    }
}
