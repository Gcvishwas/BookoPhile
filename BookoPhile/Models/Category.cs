using System.ComponentModel.DataAnnotations;

namespace BookoPhile.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }=String.Empty;

        [Range(0,100,ErrorMessage ="Range must be between 0 and 100")]
        public int? DisplayOrder{ get; set; }
    }
}
