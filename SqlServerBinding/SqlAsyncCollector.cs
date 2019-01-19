using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;

namespace SqlServerBinding
{
    public class SqlAsyncCollector : IAsyncCollector<SqlServerModel>
    {
        private readonly SqlServerAttribute attribute;

        public SqlAsyncCollector(SqlServerAttribute attribute)
        {
            this.attribute = attribute;
        }

        public Task AddAsync(SqlServerModel item, CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }

        public Task FlushAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            throw new System.NotImplementedException();
        }
    }
}