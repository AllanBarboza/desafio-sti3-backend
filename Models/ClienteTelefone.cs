using System;

namespace AgendaTelefonica.Models
{
    public class ClienteTelefone
    {
        public Guid Id { get; set; }
        public TelefoneEnum Descricao { get; set; }
        public string Numero { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
    }

    public enum TelefoneEnum
    {
        CASA, TRABALHO, CELULAR
    }
}