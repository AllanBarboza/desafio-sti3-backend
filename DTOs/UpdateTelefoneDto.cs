using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using AgendaTelefonica.Assets;
using AgendaTelefonica.Models;

namespace AgendaTelefonica.DTOs
{
    public class UpdateTelefoneDto
    {
        [NotEmpty]
        public Guid Id { get; set; }
        [JsonConverter(typeof(JsonStringEnumConverter))]
        [EnumDataType(typeof(TelefoneEnum))]
        public TelefoneEnum Descricao { get; set; }
        [Required(ErrorMessage = Messages.FILD_REQUIRED)]
        public string Numero { get; set; }
    }
}