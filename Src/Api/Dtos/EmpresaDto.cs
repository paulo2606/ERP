using ERP.Src.Domain.Entities;

namespace ERP.Src.Api.Dtos
{
    //dtos para criar empresa
    public class EmpresaCreateDto
    {
        public string NomeFantasia { get; set; } = null!;
        public decimal NumCnpj { get; set; }
        public string RazaoSocial { get; set; } = null!;
        public string? EmailEmpresa { get; set; }

        public int IdNaturezaJuridica { get; set; }
        public int IdTipoVinculo { get; set; }
        public EnderecoCreateDto Endereco { get; set; } = null!;

        public string? NumDddTelefone { get; set; }
        public string? NumTelefone { get; set; }
    }

    public class EnderecoCreateDto
    {
        public string Cep { get; set; } = null!;
        public string Logradouro { get; set; } = null!;
        public string Numero { get; set; } = null!;
        public string? Complemento { get; set; }
        public string Bairro { get; set; } = null!;
        public CidadeCreateDto Cidade { get; set; }
    }

    public class CidadeCreateDto
    {
        public string NomeCidade { get; set; } = null!;
        public string SiglaEstado { get; set; } = null!;
        public int IdEstado { get; set; }
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
