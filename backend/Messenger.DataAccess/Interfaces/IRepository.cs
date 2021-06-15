using Messenger.Data;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public interface IRepository<T> where T : IEntity
    {
        Task Add(T item);
        Task<T> Get(int id);
        Task<IEnumerable<T>> GetAll();
        Task Update(int id, T newState);
    }
}
