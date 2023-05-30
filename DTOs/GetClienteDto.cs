using System;
using System.Collections.Generic;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.DTOs
{
    public class GetClienteDto
    {

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
    }
}