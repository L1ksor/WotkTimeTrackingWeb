using Domain;

public abstract class PersistableEntity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedOn { get; private set; } = DateTime.UtcNow;
    public DateTime ModifiedOn { get; private set; } = DateTime.UtcNow;

    public void SetCreatedOn(DateTime now)
    {
        CreatedOn = now;
        ModifiedOn = now;
    }

    public void SetModifiedOn(DateTime now)
    {
        ModifiedOn = now;
    }
}

