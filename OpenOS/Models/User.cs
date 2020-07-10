using OpenOS.Enums;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenOS.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3)]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
