namespace Services.Models;

public record DaySummaryResponse(DateOnly Date, decimal TotalHours, IReadOnlyCollection<WorkLogResponse> Worklogs);