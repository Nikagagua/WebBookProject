using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Security.Permissions;

namespace WebProject.Models.Models
{
    public class CategoryModel
    {
        [Key]
        public Guid CategoryId { get; set; }

        [Required]
        [DisplayName("Category Name")]
        [MaxLength(30)]
        public string? Name { get; set; }
        
        [Required]
        [DisplayName("Display Order")]
        [Range(1, 100, ErrorMessage = "Display Order must be between 1-100")]
        public int? DisplayOrder { get; set; }
    }
}
