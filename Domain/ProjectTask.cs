namespace Domain;

public partial class ProjectTask : PersistableEntity
{
    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsActive { get; set; }

    public string CodeProject { get; set; } = null!;

    public Guid ProjectId { get; set; }

    public decimal Hours { get; set; }

    public virtual Project CodeProjectNavigation { get; set; } = null!;

    public virtual ICollection<WorkLog> Worklogs { get; set; } = new List<WorkLog>();

}
