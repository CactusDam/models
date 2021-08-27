using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ModelsTurnin.Models
{
    //Video Games
    public class vg
    {

        [Required(ErrorMessage = "Title is required.")]
        public string title { set; get; }
        public int id { get; set; }
        public string rating { set; get; }

        [ScaffoldColumn(true)]
        [StringLength(20, ErrorMessage = "The developer name cannot exceed 20 characters. ")]
        public string developer { set; get; }
        
        public int releaseYear { set; get; }
        [Range(10, 1000,
        ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int budget { set; get; }
    }
}