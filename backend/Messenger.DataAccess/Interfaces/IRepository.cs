using System.Collections.Generic;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Get(int id);
        Task<bool> Add(T item);
        Task<bool> Update(int id, T newState);
    }
}
