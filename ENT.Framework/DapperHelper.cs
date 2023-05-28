using Dapper;
using System.Data;
using System.Data.SqlClient;

namespace ENT.Framework
{
    public class DapperHelper : IDisposable
    {
        private const int COMMAND_TIMEOUT = 30;
        public IDbConnection Connection { get; }
        public IDbTransaction Transaction { get; set; }

        public DapperHelper(bool pManager = false)
        {
            Connection = new SqlConnection(pManager ? ConfigApp.StringConexaoManager : ConfigApp.StringConexaoSQLServer);
            Connection.Open();
        }

        public void BeginTransaction() =>
            Transaction = Connection.BeginTransaction();

        public void Commit() =>
            Transaction?.Commit();

        public void Rollback() =>
            Transaction?.Rollback();

        private int? GetCommandTimeout(int? commandTimeout = null)
        {
            if (!commandTimeout.HasValue)
                commandTimeout = COMMAND_TIMEOUT;

            return commandTimeout;
        }

        public int Execute(string sql, object param = null, CommandType commandType = CommandType.Text, int? commandTimeout = null) =>
            Connection.Execute(sql, param, Transaction, commandTimeout: GetCommandTimeout(commandTimeout), commandType: commandType);

        public T ExecuteScalar<T>(string sql, object param = null, CommandType commandType = CommandType.Text, int? commandTimeout = null) =>
            Connection.ExecuteScalar<T>(sql, param, Transaction, commandTimeout: GetCommandTimeout(commandTimeout), commandType: commandType);

        public T QueryFirstOrDefault<T>(string sql, object param = null, CommandType commandType = CommandType.Text, int? commandTimeout = null) =>
            Connection.QueryFirstOrDefault<T>(sql, param, Transaction, commandTimeout: GetCommandTimeout(commandTimeout), commandType: commandType);

        public IEnumerable<T> Query<T>(string sql, object param = null, CommandType commandType = CommandType.Text, int? commandTimeout = null) =>
            Connection.Query<T>(sql, param, Transaction, commandTimeout: GetCommandTimeout(commandTimeout), commandType: commandType);

        public async Task<int> ExecuteAsync(string sql, object param = null, CommandType commandType = CommandType.Text, int? commandTimeout = null) =>
            await Connection.ExecuteAsync(sql, param, Transaction, commandTimeout: GetCommandTimeout(commandTimeout), commandType: commandType);

        public async Task<T> ExecuteScalarAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text, int? commandTimeout = null) =>
            await Connection.ExecuteScalarAsync<T>(sql, param, Transaction, commandTimeout: GetCommandTimeout(commandTimeout), commandType: commandType);

        public async Task<T> QueryFirstOrDefaultAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text, int? commandTimeout = null) =>
            await Connection.QueryFirstOrDefaultAsync<T>(sql, param, Transaction, commandTimeout: GetCommandTimeout(commandTimeout), commandType: commandType);

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object param = null, CommandType commandType = CommandType.Text, int? commandTimeout = null) =>
            await Connection.QueryAsync<T>(sql, param, Transaction, commandTimeout: GetCommandTimeout(commandTimeout), commandType: commandType);

        public void Dispose()
        {
            Transaction?.Dispose();
            Connection?.Dispose();
        }
    }

}
