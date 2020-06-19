﻿using System.ComponentModel.DataAnnotations;

namespace NguyenMinhHung_Lab456.Models
{
    public class Category
    {
        public byte ID { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
    }
}