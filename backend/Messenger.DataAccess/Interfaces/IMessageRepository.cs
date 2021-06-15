using Messenger.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public interface IMessageRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAll(int chatId);
    }
}
