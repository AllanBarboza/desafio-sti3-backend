using System;
using System.Collections.Generic;

namespace AgendaTelefonica.Models
{
    public class Cliente
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public DateTime? DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataAlteracao { get; set; }
        public virtual ICollection<ClienteTelefone> Telefones { get; set; }
    }
}