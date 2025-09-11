using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Endereco", Schema = "dbo")]
    public class Endereco
    {
        [Key]
        [Column("Idf_Endereco")]
        public int IdEndereco { get; set; }

        [Required]
        [MaxLength(8)]
        [Column("Num_CEP")]
        public string Cep { get; set; } = null!;

        [Required]
        [MaxLength(255)]
        [Column("Des_Logradouro")]
        public string Logradouro { get; set; } = null!;

        [Required]
        [MaxLength(20)]
        [Column("Num_Endereco")]
        public string Numero { get; set; } = null!;

        [MaxLength(255)]
        [Column("Des_Complemento")]
        public string? Complemento { get; set; }

        [Required]
        [MaxLength(150)]
        [Column("Des_Bairro")]
        public string Bairro { get; set; } = null!;

        [Required]
        [Column("Idf_Cidade")]
        [ForeignKey("Cidade")]
        public int IdCidade { get; set; }

        [Column("Dta_Cadastro")]
        public DateTime DataCadastro { get; set; }

        [Column("Dta_Alteracao")]
        public DateTime DataAlteracao { get; set; }

        [MaxLength(50)]
        [Column("Ref_Insert_Endereco")]
        public string? RefInsertEndereco { get; set; }

        [Column("Flg_Inativo")]
        public bool FlgInativo { get; set; }

        // nav
        public Cidade Cidade { get; set; } = null!;
    }
}
