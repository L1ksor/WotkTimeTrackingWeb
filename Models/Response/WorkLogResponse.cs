using Services.Models;

public record WorkLogResponse(Guid Id, Guid TaskId, decimal Hours, string Comment, DateOnly WorkDate);
