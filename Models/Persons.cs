
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace UserForm.Models
{
    [Table("Persons")]
    public class Persons
    {

        [Key]
        public int UserId { get; set; }


        [Required(ErrorMessage = "Name is required")]
        public string? Name { get; set; } = string.Empty;


        [Required]
        [StringLength(300)]
        public string? Address { get; set; }


        [Required(ErrorMessage = "Age is required")]
        [Range(0, 150)]
        public int? Age { get; set; }


        [Required(ErrorMessage = "Gender is required")]
        public string? Gender { get; set; } = string.Empty;


        [StringLength(100)]
        public string? Profession { get; set; }
    }
}