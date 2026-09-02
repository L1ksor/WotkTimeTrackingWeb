namespace Models.Response;

public record TaskResponse( Guid Id, Guid ProjectId, string Name, string Description, bool IsActive);