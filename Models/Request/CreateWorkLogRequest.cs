using Services.Models;

public record CreateWorkLogRequest(Guid TaskId, decimal Hours, string Comment, DateOnly WorkDate);

