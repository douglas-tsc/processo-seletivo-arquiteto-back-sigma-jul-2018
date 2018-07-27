using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigma.PatrimonioApi.Entities.Models
{
    [Table("Patrimonio")]
    public class Patrimonio : BaseEntity
    {
        [Key]
        public int PatrimonioId { get; set; }
        public int MarcaId { get; set; }
        public int ModeloId { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int NroTombo { get; set; }

        public Patrimonio() { DataCriacao = DateTime.Now; }

        [ForeignKey("MarcaId")]
        public virtual Marca Marca { get; set; }

        [ForeignKey("ModeloId")]
        public virtual Modelo Modelo { get; set; }

    }
}