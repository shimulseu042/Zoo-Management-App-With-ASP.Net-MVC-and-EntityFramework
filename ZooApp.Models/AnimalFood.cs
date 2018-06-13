using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZooApp.Models
{
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
        public double Quantity { get; set; }
    }
}