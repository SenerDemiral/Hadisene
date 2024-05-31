using FirebirdSql.Data.FirebirdClient;
using System.Data;

namespace Hadisene.Lib;

public interface IDbCon
{
    IDbConnection GetConnection();
}

public class DbCon : IDbCon
{
    private string? conStr;

    public DbCon(IConfiguration config)
    {
        conStr = config.GetConnectionString("Default");
    }

    public IDbConnection GetConnection()
    {
        return new FbConnection(conStr);
    }

}
