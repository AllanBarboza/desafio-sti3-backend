using System.ComponentModel.DataAnnotations;
using AgendaTelefonica.Assets;

namespace AgendaTelefonica.DTOs
{
    public class CreateUsuarioDto
    {
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        [MinLength(3, ErrorMessage = Messages.NAME_MIN_LENGTH)]
        [MaxLength(30, ErrorMessage = Messages.NAME_MAX_LENGTH)]
        public string Name { get; set; }
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        [EmailAddress(ErrorMessage = Messages.FILD_INVALID)]
        public string Email { get; set; }
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        [MinLength(6, ErrorMessage = Messages.PASSWORD_MIN_LENGTH)]
        public string Password { get; set; }
    }
}