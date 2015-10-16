using PizzariaPoloh.Dominio.Entidades;
using PizzariaPoloh.Dominio.Repositorio.Interfaces;
using PizzariaPoloh.Web.Models;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace PizzariaPoloh.Web.Controllers
{
    public class PedidoController : Controller
    {
        private readonly IProdutoRepositorio _produtoRepositorio;
        private readonly IPedidoRepositorio _pedidoRepositorio;
        private readonly IClienteRepositorio _clienteRepositorio;

        public PedidoController(IProdutoRepositorio produtoRepositorio, IPedidoRepositorio pedidoRepositorio,
            IClienteRepositorio clienteRepositorio)
        {
            _produtoRepositorio = produtoRepositorio;
            _pedidoRepositorio = pedidoRepositorio;
            _clienteRepositorio = clienteRepositorio;
        }

        
        [HttpPost]
        public ActionResult Finalizar(PedidoViewModel pedido)
        {
            // Caso o modelo não seja válido, é retornado um array contendo os erros necessários 
            // para mostrar ao usuário
            if (!ModelState.IsValid)
            {
                var erros = new List<string>();

                foreach (var state in ModelState.Values)
                {
                    foreach (var item in state.Errors)
                    {
                        erros.Add(item.ErrorMessage);
                    }
                }

                // Aqui poderiamos gravar os erros que aconteceram em algum log para análise técnica
                // servicoLog.GravaLogErro(erros);

                // Seta o statusCode da resposta para o client como sendo 400, BadRequest
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                return null;
            }

            // Pega cliente pelo email e verifica se existe
            // Se estiver nulo é porque o cliente não foi cadastrado
            Cliente cliente = _clienteRepositorio.PegaClientePeloEmail(pedido.ClienteEmail);

            if (cliente == null)
            {
                // Retorna 404 NotFound, mas o ideal seria mandar alguma mensagem informando que o cliente não existe
                // Talvez enviar um 500 com BadRequest
                Response.StatusCode = (int)HttpStatusCode.NotFound;
                return null;
            }

            // Pega os ids enviado pelo client e busca o modelo completo para pegar o preco e o código
            // que podem ser injetados no client
            var listaDeIds = pedido.Produtos.Select(t => t.ProdutoId);
            var listaDeProdutos = _produtoRepositorio.PegaProdutos(listaDeIds);
            var listDeProdutosView = pedido.Produtos;
            var itensPedido = new List<ItemPedido>();
            ItemPedidoViewModel p;
            Pedido ped = new Pedido
            {
                ClienteId = cliente.ClienteId
            };

            foreach (var produto in listaDeProdutos)
            {
                p = listDeProdutosView.Where(t => t.ProdutoId == produto.ProdutoId).FirstOrDefault();
                p.Nome = produto.Nome;
                p.Preco = produto.Preco;

                itensPedido.Add(new ItemPedido
                {
                    Pedido = ped,
                    ProdutoId = produto.ProdutoId,
                    Quantidade = p.Quantidade
                });
            }

            ped.Itens = itensPedido;

            pedido.PedidoId = _pedidoRepositorio.SalvaPedido(ped);

            return View(pedido);
        }
    }
}