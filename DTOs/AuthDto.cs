using System.ComponentModel.DataAnnotations;
using AgendaTelefonica.Assets;

namespace AgendaTelefonica.DTOs
{
    public class AuthDto
    {
        [Required(ErrorMessage = Messages.FILD_INVALID)]
        [EmailAddress]
        public string Email { get; set; }
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        [MinLength(6, ErrorMessage = Messages.PASSWORD_MIN_LENGTH)]
        public string Password { get; set; }
    }
}