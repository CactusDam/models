using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelsTurnin.Models
{
    //Horror Movies
    public class hm
    {
        [Required(ErrorMessage = "Title is required.")]
        public string title { set; get; }
        public int id { get; set; }
        public string rating { set; get; }
        public string director { set; get; }
        public int releaseYear { set; get; }
        [Range(0, 1000000000000,
        ErrorMessage = "Value for Budget must be between 0 and 1,000,000,000,000.")]
        public int budget { set; get; }
    }
}