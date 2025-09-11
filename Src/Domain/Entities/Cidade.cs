using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Cidade", Schema = "dbo")]
    public class Cidade
    {
        [Key]
        [Column("Idf_Cidade")]
        public int IdCidade { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Nme_Cidade")]
        public string NomeCidade { get; set; } = null!;

        [Required]
        [MaxLength(2)]
        [Column("Sig_Estado")]
        public string SiglaEstado { get; set; } = null!;

        [Required]
        [Column("Idf_Estado")]
        [ForeignKey("Estado")]
        public int IdEstado { get; set; }

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }

        // nav
        public Estado Estado { get; set; } = null!;
        public ICollection<Endereco> Enderecos { get; set; } = new List<Endereco>();
    }
}
