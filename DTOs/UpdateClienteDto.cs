using System;
using System.ComponentModel.DataAnnotations;
using AgendaTelefonica.Assets;

namespace AgendaTelefonica.DTOs
{
    public class UpdateClienteDto
    {
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        public Guid Id { get; set; }
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        [MinLength(3, ErrorMessage = Messages.NAME_MIN_LENGTH)]
        [MaxLength(30, ErrorMessage = Messages.NAME_MAX_LENGTH)]
        public string Nome { get; set; }
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        [EmailAddress(ErrorMessage = Messages.FILD_INVALID)]
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}