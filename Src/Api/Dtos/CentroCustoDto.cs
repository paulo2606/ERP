namespace ERP.Src.Api.Dtos
{
    public class CreateCentroCustoDto
    {
        public string NomeCentroCusto { get; set; }
        public string? Descricao { get; set; }
        public string? CodigoCentroCusto { get; set; }
    }

    public class UpdateCentroCustoDto
    {
        public string NomeCentroCusto { get; set; }
        public string? Descricao { get; set; }
        public string? CodigoCentroCusto { get; set; }
    }

    public class CentroCustoDto
    {
        public int IdCentroCusto { get; set; }
        public string NomeCentroCusto { get; set; }
        public string? CodigoCentroCusto { get; set; }
        public string? Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool FlgInativo { get; set; }
    }
}
