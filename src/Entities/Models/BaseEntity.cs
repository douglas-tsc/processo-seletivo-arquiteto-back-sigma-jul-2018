using Newtonsoft.Json;
using System;

namespace Sigma.PatrimonioApi.Entities.Models
{
    public class BaseEntity
    {
        [JsonIgnore]
        public DateTime DataCriacao { get; set; }
    }
}
