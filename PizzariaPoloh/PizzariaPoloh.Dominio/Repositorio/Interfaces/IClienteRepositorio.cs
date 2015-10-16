using PizzariaPoloh.Dominio.Entidades;

namespace PizzariaPoloh.Dominio.Repositorio.Interfaces
{
    public interface IClienteRepositorio
    {
        Cliente PegaClientePeloEmail(string email);
    }
}
