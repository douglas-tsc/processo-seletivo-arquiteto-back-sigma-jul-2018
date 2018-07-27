using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigma.PatrimonioApi.Entities.Models
{
    [Table("Marca")]
    public class Marca : BaseEntity
    {
        [Key]
        public int MarcaId { get; set; }
        public string Nome { get; set; }

        public Marca() { DataCriacao = DateTime.Now; }

    }
}