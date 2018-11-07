using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace STI.Models
{
    public class temas_curso
    {
        [Key]
        public int id_temas { get; set; }
        [Required(ErrorMessage = "Campo requerido")]
        public String nombre_tema { get; set; }
        public int id_curso { get; set; }
        public curso curso { get; set; }

    }
}
