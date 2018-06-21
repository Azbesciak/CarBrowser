namespace Kups.CarBrowser.BO
{
    public abstract class Entity
    {
        protected Entity(long id)
        {
            Id = id;
        }

        public long Id { get; }
    }
}