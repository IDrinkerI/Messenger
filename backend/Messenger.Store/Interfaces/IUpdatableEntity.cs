namespace Messenger.Data
{
    public interface IUpdatableEntity<T> where T : IEntity
    {
        void UpdateState(T newState);
    }
}
