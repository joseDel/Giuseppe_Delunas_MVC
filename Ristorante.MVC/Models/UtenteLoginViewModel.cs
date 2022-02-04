using System.ComponentModel.DataAnnotations;

namespace Ristorante.MVC.Models
{
    public class UtenteLoginViewModel
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }

        public string ReturnUrl { get; set; }
    }
}
