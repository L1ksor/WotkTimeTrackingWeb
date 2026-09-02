namespace Services.Models;

public record CreateTaskRequest(Guid ProjectId, string Name, string Description);