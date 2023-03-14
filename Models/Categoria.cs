using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Entity_Framework_Platzi.Models
{
    [Table("Categoria")]
    public class Categoria
    {
       // [Key]
        public Guid CategoriaId { get; set; }
       // [Required]
       // [MaxLength(150)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public virtual ICollection<Tarea>  Tareas { get; set; }

        public int Peso { get; set; }
    }
}