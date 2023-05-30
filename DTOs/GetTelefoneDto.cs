using System;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.DTOs
{
    public class GetTelefoneDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public string Numero { get; set; }
        public Guid ClienteId { get; set; }
    }
}