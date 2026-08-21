using System.ComponentModel.DataAnnotations;

namespace BookoPhile.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }=String.Empty;

        public int DisplayOrder{ get; set; }
    }
}
