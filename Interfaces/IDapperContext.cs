using System.Data;

namespace Teste_TGS_API.Interfaces
{
    public interface IDapperContext
    {
        IDbConnection CreateConnection();
    }
}