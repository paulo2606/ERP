using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ERP.Src.Domain.Entities;

namespace ERP.Src.Domain.Entities
{
    [Table("TAB_Empresa", Schema = "dbo")]
    public class Empresas
    {
        [Key]
        [Column("Idf_Empresa")]
        public int IdEmpresa { get; set; }

        [Required]
        [MaxLength(255)]
        [Column("Nme_Fantasia")]
        public string NomeFantasia { get; set; } = null!;

        [Required]
        [Column("Num_CNPJ")]
        public decimal NumCnpj { get; set; }

        [Required]
        [MaxLength(250)]
        [Column("Raz_Social")]
        public string RazaoSocial { get; set; } = null!;

        [MaxLength(255)]
        [Column("Eml_Empresa")]
        public string? EmailEmpresa { get; set; }

        [Required]
        [Column("Idf_Natureza_Juridica")]
        [ForeignKey("NaturezaJuridica")]
        public int IdNaturezaJuridica { get; set; }

        [Required]
        [Column("Idf_Tipo_Vinculo_Empresa")]
        [ForeignKey("TipoVinculoEmpresa")]
        public int IdTipoVinculoEmpresa { get; set; }

        [Required]
        [Column("Idf_Endereco")]
        [ForeignKey("Endereco")]
        public int IdEndereco { get; set; }

        [Column("Num_DDD_Telefone")]
        [MaxLength(2)]
        public string? NumDddTelefone { get; set; }

        [Column("Num_Telefone")]
        [MaxLength(10)]
        public string? NumTelefone { get; set; }

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
        public NaturezaJuridica NaturezaJuridica { get; set; } = null!;
        public TipoVinculoEmpresa TipoVinculoEmpresa { get; set; } = null!;
        public Endereco Endereco { get; set; } = null!;
    }
}