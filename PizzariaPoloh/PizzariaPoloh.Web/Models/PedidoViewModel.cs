using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PizzariaPoloh.Web.Models
{
    public class PedidoViewModel
    {
        public int PedidoId { get; set; }

        [Required]
        public string ClienteEmail { get; set; }

        [Required]
        public List<ItemPedidoViewModel> Produtos { get; set; }
    }
}