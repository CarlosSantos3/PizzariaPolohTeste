# PizzariaPolohTeste

Projeto:

Sistema de Pedidos Online da Empresa Pizzaria Poloh
Tecnologias Usadas :

- Visual Studio 2015
- Microsoft C# .NET 6.0, ASP.NET MVC 5
- Jquery 2.1.3
- Razor 3.2.3
- Entity Framework 6.1.3
- WCF
- SqlServer 2014
- DDD
- POO
- BootStrap
- Ninject 3.2.2 (Usado para injeção de dependência)

Foram criados dois projetos um contendo um domínio e o outro a parte de web:
- Domínio : Nesse projeto estão as entidades, migrations (Entity Framework Migrations) e a pasta repositórios que contém o Context do Banco, os repositórios das classes e a interface. 
- Web : Nesse projeto temos, a pasta App_Start que contém a configuração da rota e da injeção de dependência(Ninject), content(arquivos de estilo),controllers, Model(Contém a ViewModel do Item Pedido), scripts, e as views.
* Foi criado também um projeto em outra solução para a WCF, que contém o contrato de serviço, uma simulação com um IList<> para conexão de banco de dados, classe e etc... Ou seja apenas um WCF básico que não foi implementado ao sistema principal.

Instalação

Atualmente todo o código se encontra disponível no GitHub, link :

Serão apresentados todos os arquivos do repositório
Leia as instruções do ReadMe (Vai conter as mesmas informações desse documento), após isso, clique em download zip para baixar os arquivos.
Extraia o arquivo vai conter uma pasta com os documentos da Pizzaria.
Agora vamos a parte de Deploy:

Passos para o Deploy:

Passos para fazer o deploy de cada parte e verificar se estão funcionando corretamente.
Introdução
Esta parte do documento explica como fazer o deploy passo a passo de modo que possa verificar se alguma parte do projeto está apresentando problemas.
Sequência de deploy
1.	Dentro da primeira pasta abra o arquivo PizzariaPoloh.sln
2.	Aperte F5, a sua rota padrão já estará configurada e irá abrir a tela principal do sistemas
3.	Verifique se o console do browser possui algum erro e verifique também o console do Visual Studio
4.	Tente simular um pedido, o “+” e “-“ controlam a quantidade do produto, nunca sendo menor que 0.
5.	Você pode conferir quantos itens existem no pedido na parte superior direita.
6.	Após selecionar os itens, insira um e-mail cadastrado*(carlos@gmail.com, luna@gmail.com) clique sobre o botão Finalizar Pedido, se o seu pedido não conter itens ou não for um e-mail válido você não poderá prosseguir.
7.	Todos os produtos selecionados serão listados e você fechará seu pedido.
8.	As informações irão para ser gravadas na tabela Pedido e ItemPedido.
Sequência de deploy WCF***
9.	Abra a pasta WCF Pizzaria Poloh dentro da pasta principal do projeto
10.	Aperte F5, irá aparecer um console informando que o serviço está online e a endereço.
11.	Acesse o endereço http://localhost:8080/produtos para testar o webservice
Obs: 3. Durante o deploy, é interessante monitorar o log do servidor para que você possa visualizar possíveis erros 
*Ainda não há uma tela para cadastro de e-mail.
***Como mencionado durante a introdução foi criado um WCF básico apenas para mostrar um serviço simples sendo criado, porém como eu tive um pouco de dificuldade na hora da implementação resolvi dar ênfase a outras tecnologias por conta da administração do tempo.


















