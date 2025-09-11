using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Estado", Schema = "dbo")]
    public class Estado
    {
        [Key]
        [Column("Idf_Estado")]
        public int IdEstado { get; set; }

        [Required]
        [MaxLength(2)]
        [Column("Sig_Estado")]
        public string SiglaEstado { get; set; } = null!;

        [Required]
        [MaxLength(150)]
        [Column("Nme_Estado")]
        public string NomeEstado { get; set; } = null!;

        [Required]
        [Column("Idf_Regiao")]
        [ForeignKey("Regiao")]
        public int IdRegiao { get; set; }

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }

        // nav
        public Regiao Regiao { get; set; } = null!;
        public ICollection<Cidade> Cidades { get; set; } = new List<Cidade>();
    }
}
