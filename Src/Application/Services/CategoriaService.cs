using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interfaces;
using ERP.Src.Domain.Entities;
using ERP.Src.Infraestructure.Data;
using Microsoft.EntityFrameworkCore;

namespace ERP.Src.Application.Services
{
    public class CategoriaService : ICategoriaService
    {
        private readonly AppDbContext _context;

        public CategoriaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<CategoriaDto>> GetAllAsync()
        {
            var categorias = await _context.Categoria
                .Where(c => !c.FlagInativo)
                .ToListAsync();

            return categorias.Select(MapToDto);
        }

        public async Task<CategoriaDto?> GetByIdAsync(int id)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null || categoria.FlagInativo) return null;

            return MapToDto(categoria);
        }

        public async Task<CategoriaDto> CreateAsync(CreateCategoriaDto dto, int userId)
        {
            var categoria = new Categoria
            {
                NomeCategoria = dto.NomeCategoria,
                TipoCategoria = dto.TipoCategoria,
                DataAlteracao = DateTime.Now,
                DataCadastro = DateTime.Now,
            };

            _context.Categoria.Add(categoria);
            await _context.SaveChangesAsync();

            return MapToDto(categoria);
        }

        public async Task<CategoriaDto?> UpdateAsync(int id, UpdateCategoriaDto dto, int userId)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null || categoria.FlagInativo) return null;

            categoria.NomeCategoria = dto.NomeCategoria;
            categoria.TipoCategoria = dto.TipoCategoria;
            categoria.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();

            return MapToDto(categoria);
        }

        public async Task<bool> SoftDeleteAsync(int id, int userId)
        {
            var categoria = await _context.Categoria.FindAsync(id);
            if (categoria == null || categoria.FlagInativo) return false;

            categoria.FlagInativo = true;
            categoria.DataAlteracao = DateTime.Now;

            await _context.SaveChangesAsync();
            return true;
        }

        private static CategoriaDto MapToDto(Categoria categoria)
        {
            return new CategoriaDto
            {
                IdCategoria = categoria.IdCategoria,
                NomeCategoria = categoria.NomeCategoria,
                TipoCategoria = categoria.TipoCategoria,
                DataCadastro = categoria.DataCadastro,
                DataAlteracao = categoria.DataAlteracao,
                FlagInativo = categoria.FlagInativo
            };
        }
    }
}
