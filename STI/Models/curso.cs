using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace STI.Models
{
    public class curso
    {
        [Key]
        public int id_curso { get; set; }
        [Required(ErrorMessage ="Campo requerido")]
        [StringLength(80, MinimumLength = 5, ErrorMessage ="El nombre debe tener almenos 5 caracteres")]
        public String nombre_curso { get; set; }
        [Required(ErrorMessage ="Campo requerido")]
        [StringLength(80, MinimumLength = 5, ErrorMessage = "El nivel debe tener almenos 5 caracteres")]
        public String nivel { get; set; }
        public ICollection<temas_curso> temas_Cursos { get; set; }

    }
}
