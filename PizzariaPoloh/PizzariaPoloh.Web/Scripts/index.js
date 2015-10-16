var produtosQtdTotal = 0;
var precoAtual = 0;

function adicionaQuantidade(produtoId) {
    var span = $("[data-prod-id=" + produtoId + "]");
    var qtdAntiga = parseInt(span.html());

    span.html(++qtdAntiga);

    produtosQtdTotal++;
}

function removeQuantidade(produtoId) {
    var span = $("[data-prod-id=" + produtoId + "]");
    var qtdAntiga = parseInt(span.html());

    if (qtdAntiga <= 0) {
        span.html(0);
        return;
    }

    span.html(--qtdAntiga);

    produtosQtdTotal--;
}

function atualizaPreco(preco) {
    var totalPedidoEl = $("#totalPedido");
    var totalProdutosEl = $("#totalProdutos");

    if (precoAtual + preco <= 0)
        precoAtual = 0;
    else
        precoAtual += preco;

    totalPedidoEl.html("R$ " + parseFloat(precoAtual).toFixed(2));
    totalProdutosEl.html(produtosQtdTotal + " itens no pedido");
}

function finalizaPedido() {
    if (produtosQtdTotal <= 0) {
        alert("Pedido não contém itens");
        return;
    }

    var emailCliente = $("[name=email]").val();

    if (emailCliente.length == 0) {
        alert("Necessário colocar o seu email");
        return;
    }

    var produtos = [];
    var listaProdutos = $("[data-prod-id]");
    var qtdAEnviar = 0;
    var $item;
    var itemId;

    listaProdutos.each(function (ix, item) {
        $item = $(item);
        itemId = $item.attr("data-prod-id");
        qtdAEnviar = parseInt($item.html());

        if (qtdAEnviar <= 0)
            return;

        produtos.push({
            ProdutoId: itemId,
            Quantidade: qtdAEnviar
        });
    });

    // Ajax!
    $.ajax({
        type: "POST",
        url: "/pedido/finalizar",
        data: {
            pedido: {
                ClienteEmail: emailCliente,
                Produtos: produtos 
            }
        },
        success: function (result) {
            $("#corpo").html(result);
        }
    })
    .fail(function (err) {
        alert("Desculpe, um problema aconteceu com o seu pedido. Entre no site novamente e refaça seu pedido.");
    });

}