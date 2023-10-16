using Teste_TGS_API.Models;

namespace Teste_TGS_API.Interfaces
{
    public interface IClienteRepository
    {
        IEnumerable<Cliente> GetAllClientes();
        Cliente GetClienteById(int id);
        void CreateCliente(Cliente _Cliente);
        void UpdateCliente(Cliente _Cliente);
        void DeleteCliente(int id);
        IEnumerable<Logradouro> GetAllLogradouros(int id);

    }
}
