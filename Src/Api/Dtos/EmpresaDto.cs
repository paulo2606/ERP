namespace ERP.Src.Api.Dtos
{
    public class EmpresaCreateDto
    {
        public string NomeFantasia { get; set; } = null!;
        public string NumCnpj { get; set; } = null!;
        public string RazaoSocial { get; set; } = null!;
        public string? EmailEmpresa { get; set; }
        public int IdNaturezaJuridica { get; set; }
        public int IdTipoVinculoEmpresa { get; set; }
        public int IdEndereco { get; set; }
        public string? NumDddTelefone { get; set; }
        public string? NumTelefone { get; set; }
    }

    public class EmpresaUpdateDto : EmpresaCreateDto
    {
        public int IdEmpresa { get; set; }
    }

    public class EmpresaResponseDto
    {
        public int IdEmpresa { get; set; }
        public string NomeFantasia { get; set; } = null!;
        public string RazaoSocial { get; set; } = null!;
        public string NumCnpj { get; set; } = null!;
        public string? EmailEmpresa { get; set; }
        public bool FlgInativo { get; set; }
    }
}
