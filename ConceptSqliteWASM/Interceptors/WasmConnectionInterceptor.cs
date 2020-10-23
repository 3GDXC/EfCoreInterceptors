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
    public class WasmConnectionInterceptor
        : DbConnectionInterceptor
    {
        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override InterceptionResult ConnectionOpening(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
        {
            if (eventData.Connection.DataSource.EndsWith(":wasm", System.StringComparison.CurrentCultureIgnoreCase))
                return InterceptionResult.Suppress();
            return base.ConnectionOpening(connection, eventData, result);
        }

        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<InterceptionResult> ConnectionOpeningAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result, CancellationToken cancellationToken = default)
        {
            if (eventData.Connection.DataSource.EndsWith(":wasm", System.StringComparison.CurrentCultureIgnoreCase))
                return Task.FromResult(InterceptionResult.Suppress());
            return base.ConnectionOpeningAsync(connection, eventData, result, cancellationToken);
        }

        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        public override void ConnectionOpened(DbConnection connection, ConnectionEndEventData eventData)
        {
            base.ConnectionOpened(connection, eventData);
        }

        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task ConnectionOpenedAsync(DbConnection connection, ConnectionEndEventData eventData, CancellationToken cancellationToken = default)
        {
            return base.ConnectionOpenedAsync(connection, eventData, cancellationToken);
        }

        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override InterceptionResult ConnectionClosing(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
        {
            return base.ConnectionClosing(connection, eventData, result);
        }

        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        /// <param name="result"></param>
        /// <returns></returns>
        public override Task<InterceptionResult> ConnectionClosingAsync(DbConnection connection, ConnectionEventData eventData, InterceptionResult result)
        {
            return base.ConnectionClosingAsync(connection, eventData, result);
        }

        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        public override void ConnectionClosed(DbConnection connection, ConnectionEndEventData eventData)
        {
            base.ConnectionClosed(connection, eventData);
        }

        /// <summary>
        /// </summary>
        /// <param name="connection"></param>
        /// <param name="eventData"></param>
        /// <returns></returns>
        public override Task ConnectionClosedAsync(DbConnection connection, ConnectionEndEventData eventData)
        {
            return base.ConnectionClosedAsync(connection, eventData);
        }
    }
}
