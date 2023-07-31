using System.ComponentModel.DataAnnotations;

namespace UserManagement
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(25, MinimumLength = 2)]
        // [MaxLength(25)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }
    }
}
