using Messenger.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public interface IRepository<T> where T : IEntity
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task Add(T item);
        Task Update(int id, T newState);
    }
}
