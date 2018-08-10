namespace RR_Models.Contracts
{
    public abstract class Entity
    {
        public long Id { get; protected set; }
        public bool IsActive { get; set; } = true;
    }
}
