namespace Domain;

public partial class Project : PersistableEntity
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public bool IsActive { get; set; }

    public virtual ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
}
