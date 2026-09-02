using Services.Models;

namespace Services;

public interface IWorkLogService
{
    Task<WorkLogResponse> CreateAsync(CreateWorkLogRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<WorkLogResponse>> GetByDateAsync(DateOnly date, CancellationToken cancellationToken = default);
    Task<DaySummaryResponse> GetDaySummaryAsync(DateOnly date, CancellationToken cancellationToken = default);
}