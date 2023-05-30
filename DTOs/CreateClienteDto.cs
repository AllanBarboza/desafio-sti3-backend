using System;
using System.ComponentModel.DataAnnotations;
using AgendaTelefonica.Assets;

namespace AgendaTelefonica.DTOs
{
    public class CreateClienteDto
    {
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        [MaxLength(30, ErrorMessage = Messages.NAME_MAX_LENGTH)]
        [MinLength(3, ErrorMessage = Messages.NAME_MIN_LENGTH)]
        public string Nome { get; set; }
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        [EmailAddress(ErrorMessage = Messages.FILD_INVALID)]
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}