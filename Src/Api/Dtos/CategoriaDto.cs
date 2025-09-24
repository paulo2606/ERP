namespace ERP.Src.Api.Dtos
{
    public class CategoriaDto
    {
        public int IdCategoria { get; set; }
        public string NomeCategoria { get; set; }
        public string TipoCategoria { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataAlteracao { get; set; }
        public bool FlagInativo { get; set; }
    }

    public class CreateCategoriaDto
    {
        public string NomeCategoria { get; set; }
        public string TipoCategoria { get; set; }

    }

    public class UpdateCategoriaDto
    {
        public string NomeCategoria { get; set; }
        public string TipoCategoria { get; set; }

    }
}
