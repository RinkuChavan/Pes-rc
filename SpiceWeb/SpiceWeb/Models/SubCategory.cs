﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SpiceWeb.Models
{
    public class SubCategory
    {

        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name ="SubCategory")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [ForeignKey("CategoryId")]
         public virtual Category Category { get; set; }
    }
}
