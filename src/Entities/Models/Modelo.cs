using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sigma.PatrimonioApi.Entities.Models
{
    [Table("Modelo")]
    public class Modelo : BaseEntity
    {
        [Key]
        public int ModeloId { get; set; }
        public string Nome { get; set; }

        public Modelo() { DataCriacao = DateTime.Now; }

    }
}