using System.Data;

namespace Dapper.Identity
{
    /// <summary>
    /// A factory for creating instances of <see cref="IDbConnection"/>.
    /// </summary>
    public interface IDbConnectionFactory
    {
        /// <summary>
        /// The connection string to use for connecting to Microsoft SQL Server.
        /// </summary>
        string ConnectionString { get; set; }

        /// <summary>
        /// Creates a new instance of the underlying <see cref="IDbConnection"/>.
        /// </summary>
        IDbConnection Create();
    }
}