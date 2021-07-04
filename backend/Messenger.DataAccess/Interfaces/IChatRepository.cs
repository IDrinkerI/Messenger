using Messenger.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public interface IChatRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetChats(int userId);
    }
}
