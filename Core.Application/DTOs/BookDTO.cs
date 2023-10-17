using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Application.DTOs
{
    public class BookDTO
    {
        [Required(ErrorMessage = "Titulo es requerido")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Descripcion es requerido")]
        public string Description { get; set; }

        [Required(ErrorMessage = "La cantidad de paginas son requeridas")]
        [Range(1, int.MaxValue, ErrorMessage = "Las paginas deben ser un numero positivo.")]
        public int? PageCount { get; set; }

        [Required(ErrorMessage = "El extracto del libro es requerido")]
        public string Excerpt { get; set; }

        public DateTime PublishDate { get; set; }

    }
}
