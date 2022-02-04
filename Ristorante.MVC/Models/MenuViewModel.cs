using System.ComponentModel.DataAnnotations;

namespace Ristorante.MVC.Models
{
    public class MenuViewModel
    {
        public int IdMenu { get; set; }
        [Required]
        public string Nome { get; set; }
        public List<PiattoViewModel> Piatti { get; set; } = new List<PiattoViewModel>();
    }
}
