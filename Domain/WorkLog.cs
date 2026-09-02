namespace Domain;

public partial class WorkLog : PersistableEntity
{
    public DateOnly WorkDate { get; set; }

    public decimal Hours { get; set; }

    public string? Description { get; set; }

    public Guid TaskId { get; set; }

    public virtual ProjectTask Task { get; set; } = null!;
}
