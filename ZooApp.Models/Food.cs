﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooApp.Models
{
    public class Food
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [StringLength(50)]
        [Required]
        [Index("Ix_FoodName", 1, IsUnique = true)]
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }
        public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
    }
}