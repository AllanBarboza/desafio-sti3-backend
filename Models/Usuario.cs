using System;

namespace AgendaTelefonica.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public RoleEnum Role { get; set; }
    }

    public enum RoleEnum
    {
        USER, ADMIN
    }

}