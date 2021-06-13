using Messenger.Model;
using System.Collections.Generic;


namespace Messenger.Service
{
    public interface IService<T> where T: IModel
    {
        void Add(T item);
        T Get();
        IEnumerable<T> GetAll();
        void Update(int id, T newState);
        void Delete(T item);
    }
}
