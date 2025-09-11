using ERP.Src.Api.Dtos;
using ERP.Src.Application.Services.Interface;
using ERP.Src.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ERP.Src.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaService _empresaService;

        public EmpresaController(IEmpresaService empresaService)
        {
            _empresaService = empresaService;
        }

        [HttpPost("criar-empresa")]
        public async Task<IActionResult> Create(EmpresaCreateDto dto)
        {
            var empresa = await _empresaService.CreateAsync(dto);
            return Ok(empresa);
        }

        [HttpGet("listar-empresa")]
        public async Task<IActionResult> GetAll()
        {
            var empresas = await _empresaService.GetAllAsync();
            return Ok(empresas);
        }

        [HttpGet("buscar-empresa/{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var empresa = await _empresaService.GetByIdAsync(id);
            if (empresa == null) return NotFound();
            return Ok(empresa);
        }

        [HttpPut("atualiza-empresa/{id}")]
        public async Task<IActionResult> Update(int id, EmpresaUpdateDto dto)
        {
            if (id != dto.IdEmpresa) return BadRequest();

            var empresa = new Empresas
            {
                IdEmpresa = dto.IdEmpresa,
                NomeFantasia = dto.NomeFantasia,
                NumCnpj = dto.NumCnpj,
                RazaoSocial = dto.RazaoSocial,
                EmailEmpresa = dto.EmailEmpresa,
                IdNaturezaJuridica = dto.IdNaturezaJuridica,
                IdTipoVinculoEmpresa = dto.IdTipoVinculoEmpresa,
                IdEndereco = dto.IdEndereco,
                NumDddTelefone = dto.NumDddTelefone,
                NumTelefone = dto.NumTelefone
            };

            var atualizada = await _empresaService.UpdateAsync(empresa);
            if (atualizada == null) return NotFound();

            return Ok(atualizada);
        }

        [HttpDelete("soft-delete{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _empresaService.DeleteAsync(id);
            if (!result) return NotFound();
            return NoContent();
        }
    }
}
