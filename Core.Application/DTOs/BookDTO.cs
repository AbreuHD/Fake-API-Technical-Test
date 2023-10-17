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
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; }

        [Required(ErrorMessage = "PageCount is required")]
        [Range(1, int.MaxValue, ErrorMessage = "PageCount must be a positive number.")]
        public int? PageCount { get; set; }

        [Required(ErrorMessage = "Excerpt is required")]
        public string Excerpt { get; set; }

        public DateTime PublishDate { get; set; }

    }
}
