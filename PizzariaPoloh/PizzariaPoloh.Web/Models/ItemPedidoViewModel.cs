using System;
using System.ComponentModel.DataAnnotations;

namespace PizzariaPoloh.Web.Models
{
    public class ItemPedidoViewModel
    {
        [Range(1, int.MaxValue)]
        public int ProdutoId { get; set; }

        public string Nome { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantidade { get; set; }

        public decimal Preco { get; set; }
    }
}