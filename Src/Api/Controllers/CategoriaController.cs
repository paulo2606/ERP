using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace ERP.Src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaService _categoriaService;

        public CategoriaController(ICategoriaService categoriaService)
        {
            _categoriaService = categoriaService;
        }

        private int GetUserId() =>
            int.Parse(User.FindFirst("id")?.Value ?? "0");

        [HttpGet("lista-categoria")]
        public async Task<IActionResult> GetAll()
        {
            var categorias = await _categoriaService.GetAllAsync();
            return Ok(categorias);
        }

        [HttpGet("buscar-categoria/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categoria = await _categoriaService.GetByIdAsync(id);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpPost("cria-categoria")]
        public async Task<IActionResult> Create(CreateCategoriaDto dto)
        {
            var userId = GetUserId();
            var categoria = await _categoriaService.CreateAsync(dto, userId);
            return CreatedAtAction(nameof(GetById), new { id = categoria.IdCategoria }, categoria);
        }

        [HttpPut("atualiza-categoria/{id}")]
        public async Task<IActionResult> Update(int id, UpdateCategoriaDto dto)
        {
            var userId = GetUserId();
            var categoria = await _categoriaService.UpdateAsync(id, dto, userId);
            if (categoria == null) return NotFound();
            return Ok(categoria);
        }

        [HttpDelete("soft-delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = GetUserId();
            var result = await _categoriaService.SoftDeleteAsync(id, userId);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
