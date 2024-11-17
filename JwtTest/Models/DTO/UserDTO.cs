using System.ComponentModel.DataAnnotations;

namespace JwtTest.Models.DTO
{
    public class UserDTO
    {
        [Required(ErrorMessage ="El usuario es requerido.")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Introduca una contraseña.")]
        public string Password { get; set; }

    }
}
