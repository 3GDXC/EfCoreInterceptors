/// <summary>
/// </summary>
namespace ConceptSqliteWASM
{
    using Microsoft.EntityFrameworkCore.Diagnostics;

    using System.Data.Common;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// </summary>
    public class WasmCommandInterceptor
        : DbCommandInterceptor
    {
        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            if (command.Connection.DataSource.EndsWith(":wasm", System.StringComparison.CurrentCultureIgnoreCase))
                InterceptionResult<int>.SuppressWithResult(42);
            return base.ScalarExecuting(command, eventData, result);
        }

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
        {
            if (command.Connection.DataSource.EndsWith(":wasm", System.StringComparison.CurrentCultureIgnoreCase))
                InterceptionResult<int>.SuppressWithResult(42);
            return base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
        }


        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override object ScalarExecuted(DbCommand command, CommandExecutedEventData eventData, object result)
        {
            return base.ScalarExecuted(command, eventData, result);
        }

        /// <summary>
        /// </summary>
        /// <param name="command"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<object> ScalarExecutedAsync(DbCommand command, CommandExecutedEventData eventData, object result, CancellationToken cancellationToken = default)
        {
            return base.ScalarExecutedAsync(command, eventData, result, cancellationToken);
        }
    }
}
