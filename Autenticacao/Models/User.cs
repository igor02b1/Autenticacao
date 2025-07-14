using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Autenticacao.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
