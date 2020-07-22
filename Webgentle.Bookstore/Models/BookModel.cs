using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Webgentle.Bookstore.Enums;

namespace Webgentle.Bookstore.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        
        [StringLength(100, MinimumLength = 5)]
        [Required(ErrorMessage ="Please enter the title of your book")]
        public string Title { get; set; }
        
        [Required(ErrorMessage = "Please enter the author name")]
        public string Author { get; set; }
        
        [StringLength(500)]
        public string Description { get; set; }
        public string Category { get; set; }

        [Required(ErrorMessage = "Please select a language for your book")]
        public string Language { get; set; }

        [Required(ErrorMessage = "Please select a language for your book")]
        public LanguageEnum LanguageEnum { get; set; }
       
        [Required(ErrorMessage = "Please enter total pages")]
        [Display(Name = "Total Pages of book")]
        public int? TotalPages { get; set; }
    }
}
