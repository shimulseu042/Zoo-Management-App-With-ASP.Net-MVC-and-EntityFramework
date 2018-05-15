﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooApp.Models
{
    public class Animal
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
		[StringLength(50)]
		[Required]
		[Index("Ix_AnimalName")]
        public string Name { get; set; }
	    [StringLength(50)]
	    [Required]
	    [Index("Ix_AnimalOrigin")]
		public string Origin { get; set; }
		public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
    }

	public class Food
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }
		[StringLength(50)]
		[Required]
		[Index("Ix_FoodName")]
		public string Name { get; set; }
		public virtual ICollection<AnimalFood> AnimalFoods { get; set; }
	}

	public class AnimalFood
	{
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int Id { get; set; }

		//EF Relationship Properties
		[ForeignKey("Animal")]
		[Required]
		public int AnimalId { get; set; }
		[ForeignKey("Food")]
		[Required]
		public int FoodId { get; set; }
		public virtual Animal Animal { get; set; }
		public virtual Food Food { get; set; }
		[Required]
		public int Quantity { get; set; }
	}
}
