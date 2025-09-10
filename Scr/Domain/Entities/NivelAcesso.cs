using ERP.Scr.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Scr.Domain.Entities
{
    [Table("TAB_Nivel_Acesso", Schema = "dbo")]
    public class NivelAcesso
    {
        [Key]
        [Column("Idf_Nivel_Acesso")]
        public int IdNivelAcesso { get; set; }

        [Required]
        [MaxLength(100)]
        [Column("Nme_Nivel_Acesso")]
        public string NomeNivel { get; set; } = null!;

        [MaxLength(255)]
        [Column("Des_Nivel_Acesso")]
        public string? DescricaoNivel { get; set; }

        [Required]
        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Required]
        [Column("Dta_Alteracao")]
        public DateTime DataAlteracao { get; set; }

        [Required]
        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }

        //nav
        public ICollection<Login> Login { get; set; } = new List<Login>();
    }
}
