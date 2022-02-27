using BookStore.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStore.ViewModel
{
    public class BookAuthorViewModel
    {
        public int BookId { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(120)]
        public String Title { get; set; }

        [Required]
        [StringLength(120,MinimumLength =5)]
        public String Description { get; set; }
        public int AuthorId { get; set; }
        public List<Author> Authors { get; set; }
        public IFormFile File { get; set; }
        public String ImageUrl { get; set; }






    }
}
