using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Nova_WebApp.Server.Models
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] // Declarando explicitamente el auto-increment
        public int Id { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El nombre no debe exceder de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "El apellido no debe exceder de 50 caracteres.")]
        [RegularExpression(@"^[a-zA-ZñÑáéíóúÁÉÍÓÚüÜ]+$", ErrorMessage = "Solo se permiten caracteres alfabéticos.")]
        public string LastName { get; set; }

        [Required]
        [StringLength(254, ErrorMessage = "La dirección de correo electrónico no debe exceder de 254 caracteres.")]
        [EmailAddress(ErrorMessage = "El formato de la dirección de correo electrónico no es válido.")]
        public string EmailAddress { get; set; }

        [Required]
        [StringLength(15, ErrorMessage = "El número de teléfono no debe exceder de 15 caracteres.")]
        [Phone(ErrorMessage = "El formato del número de teléfono no es válido.")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(64, MinimumLength = 8, ErrorMessage = "La contraseña debe tener entre 8 y 64 caracteres.")]
        public string Password { get; set; }
        public bool AcceptTerms { get; set; }
        public bool AcceptNewsletter { get; set; }

        [Required]
        public DateTime CreatedDate { get; set; }

        public User()
        {
            // Iniciar CreatedDate al UTC date/time en creacion
            CreatedDate = DateTime.UtcNow;
        }
    }
}
