namespace ERP.Src.Api.Dtos
{
    public class EmpresaCreateDto
    {
        public string NomeFantasia { get; set; } = null!;
        public decimal NumCnpj { get; set; }
        public string RazaoSocial { get; set; } = null!;
        public string? EmailEmpresa { get; set; }

        public int IdNaturezaJuridica { get; set; }
        public int IdTipoVinculoEmpresa { get; set; }
        public int IdEndereco { get; set; }

        public string? NumDddTelefone { get; set; }
        public string? NumTelefone { get; set; }
    }

    public class EmpresaResponseDto
    {
        public int IdEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public decimal NumCnpj { get; set; }
        public string? EmailEmpresa { get; set; }

        public string NaturezaJuridica { get; set; }
        public string TipoVinculo { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Regiao { get; set; }
    }

    public class EmpresaUpdateDto
    {
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public decimal NumCnpj { get; set; }
        public string? EmailEmpresa { get; set; }

        public int IdNaturezaJuridica { get; set; }
        public int IdTipoVinculoEmpresa { get; set; }
        public int IdEndereco { get; set; }

        public string? NumDddTelefone { get; set; }
        public string? NumTelefone { get; set; }

        //public DateTime DataAlteracao { get; set; }
    }

    public class EmpresaDeleteDto
    {
        public bool FlgInativo { get; set; }
    }


}
