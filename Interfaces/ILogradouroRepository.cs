using Teste_TGS_API.Models;

namespace Teste_TGS_API.Interfaces
{
    public interface ILogradouroRepository
    {
        IEnumerable<Logradouro> GetLogradouroByClienteId(int id);
        Logradouro GetLogradouroById(int id, int clienteId);

        void CreateLogradouro(Logradouro _Logradouro);
        void UpdateLogradouro(Logradouro _Logradouro);
        void DeleteLogradouro(int id);
    }
}