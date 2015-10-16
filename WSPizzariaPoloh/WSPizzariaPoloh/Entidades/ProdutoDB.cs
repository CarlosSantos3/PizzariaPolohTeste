using System.Collections.Generic;
using System.Linq;

namespace WSPizzariaPoloh
{
   public class ProdutoDB
    {
        /// <summary>
        /// Simula um Banco de Dados
        /// </summary>
        private static List<Produto> produtos = new List<Produto>();

        public void Adicionar(Produto prod)
        {
            ProdutoDB.produtos.Add(prod);
        }

        public Produto Buscar(string Nome)
        {
            var resultado = ProdutoDB.produtos.Where(prod => prod.Nome.Equals(Nome)).FirstOrDefault();
            return (Produto)resultado;
        }
    }
}
