using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Nova_WebApp.Server.DTOs.Users
{
    public class UserInputDto //Que necesito yo recibir y guardar
    {
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
    }
}
