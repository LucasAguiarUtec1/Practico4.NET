using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shared;

namespace DataAccessLayer.EFModels
{
    public class Veichulos
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public long Id { get; set; }

        [MaxLength(100), MinLength(3), Required]
        public string Marca { get; set; } = "";

        [MaxLength(100), MinLength(3), Required]
        public string Modelo { get; set; } = "";

        [MaxLength(100), MinLength(3), Required]
        public string Matricula { get; set; } = "";
    }
}
