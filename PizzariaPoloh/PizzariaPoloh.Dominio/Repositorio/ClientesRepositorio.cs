using PizzariaPoloh.Dominio.Entidades;
using PizzariaPoloh.Dominio.Repositorio.Interfaces;
using System.Linq;

namespace PizzariaPoloh.Dominio.Repositorio
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        private readonly PizzariaPolohDBContext _context = new PizzariaPolohDBContext();
        
        public Cliente PegaClientePeloEmail(string email)
        {
            return _context.Clientes.Where(t => t.Email == email).FirstOrDefault();
        }
    }
}
