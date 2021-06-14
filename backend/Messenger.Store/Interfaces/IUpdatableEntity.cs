using System.Threading.Tasks;


namespace Messenger.Data
{
    public interface IUpdatableEntity<T> where T : IEntity
    {
        Task UpdateState(T newState);
    }
}
