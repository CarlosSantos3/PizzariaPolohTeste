namespace PizzariaPoloh.Dominio.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Cliente",
                c => new
                    {
                        ClienteId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Endereco = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.ClienteId);
            
            CreateTable(
                "dbo.ItemPedido",
                c => new
                    {
                        ItemPedidoId = c.Int(nullable: false, identity: true),
                        Quantidade = c.Int(nullable: false),
                        ProdutoId = c.Int(nullable: false),
                        Pedido_PedidoId = c.Int(),
                    })
                .PrimaryKey(t => t.ItemPedidoId)
                .ForeignKey("dbo.Pedido", t => t.Pedido_PedidoId)
                .Index(t => t.Pedido_PedidoId);
            
            CreateTable(
                "dbo.Pedido",
                c => new
                    {
                        PedidoId = c.Int(nullable: false, identity: true),
                        ClienteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PedidoId);
            
            CreateTable(
                "dbo.Produto",
                c => new
                    {
                        ProdutoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        Preco = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ProdutoId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemPedido", "Pedido_PedidoId", "dbo.Pedido");
            DropIndex("dbo.ItemPedido", new[] { "Pedido_PedidoId" });
            DropTable("dbo.Produto");
            DropTable("dbo.Pedido");
            DropTable("dbo.ItemPedido");
            DropTable("dbo.Cliente");
        }
    }
}
