using System.ComponentModel.DataAnnotations;

namespace Nova_WebApp.Server.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime CreatedDate { get; set; }

        public User()
        {
                
        }
    }
}