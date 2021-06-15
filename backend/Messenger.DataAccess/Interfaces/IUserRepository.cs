using Messenger.Data;
using System.Threading.Tasks;


namespace Messenger.DataAccess
{
    public interface IUserRepository<TEntity> : IRepository<TEntity> where TEntity : IEntity
    {
        Task<TEntity> Get(string email);
    }
}
