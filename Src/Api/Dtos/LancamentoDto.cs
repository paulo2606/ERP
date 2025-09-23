namespace ERP.Src.Api.Dtos
{
    public class CreateLancamentoDto
    {
        public string DescricaoLancamento { get; set; }
        public decimal ValorLancamentoPrevisto { get; set; }
        public int IdSituacaoLancamento { get; set; }
        public int? IdEmpresa { get; set; }
        public int IdCategoria { get; set; }
        public int IdCentroCusto { get; set; }

    }

    public class LancamentoDto
    {
        public int IdLancamento { get; set; }
        public string DescricaoLancamento { get; set; }
        public decimal ValorLancamentoPrevisto { get; set; }
        public DateTime DataLancamento { get; set; }
        public int IdSituacaoLancamento { get; set; }
        public int? IdEmpresa { get; set; }
        public int IdCategoria { get; set; }
        public int IdCentroCusto { get; set; }
        public int IdResponsavelCriacao { get; set; }
        public int? IdResponsavelAlteracao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool FlagInativo { get; set; }
    }

    public class UpdateLancamentoDto
    {
        public string DescricaoLancamento { get; set; }
        public decimal ValorLancamentoPrevisto { get; set; }
        public int IdSituacaoLancamento { get; set; }
        public int? IdEmpresa { get; set; }
        public int IdCategoria { get; set; }
        public int IdCentroCusto { get; set; }
    }
}
