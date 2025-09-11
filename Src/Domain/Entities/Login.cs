using ERP.Src.Domain.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Login", Schema = "dbo")]
    public class Login
    {
        [Key]
        [Column("Idf_Login")]
        public int IdLogin { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Nme_Login")]
        public string NomeLogin { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        [Column("Eml_Login")]
        public string EmailLogin { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        [Column("Sen_Login")]
        public string SenhaHash { get; set; } = null!;

        [Required]
        [Column("Idf_Permissao")]
        [ForeignKey("Permissao")]
        public int IdPermissao { get; set; }

        [Required]
        [Column("Idf_Nivel_Acesso")]
        [ForeignKey("NivelAcesso")]
        public int IdNivelAcesso { get; set; }

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
        public Permissao Permissao { get; set; } = null!;
        public NivelAcesso NivelAcesso { get; set; } = null!;
    }
}
