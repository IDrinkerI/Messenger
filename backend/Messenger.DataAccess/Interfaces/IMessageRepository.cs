using Messenger.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public interface IMessageRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        Task<IEnumerable<TEntity>> GetAll(int chatId);
    }
}
