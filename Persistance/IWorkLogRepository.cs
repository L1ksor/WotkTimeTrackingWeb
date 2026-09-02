using Domain;
namespace Persistance
{
    public interface IWorkLogRepository
    {
        Task<IEnumerable<WorkLog>> GetByDateAsync(DateOnly date, CancellationToken cancellationToken = default);
        Task<IEnumerable<WorkLog>> GetByDateRangeAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default);
        Task<IEnumerable<WorkLog>> GetByTaskIdAsync(Guid taskId, CancellationToken cancellationToken = default);
        Task<decimal> GetTotalHoursByDateAsync(DateOnly date, CancellationToken cancellationToken = default);
        Task CreateAsync(WorkLog workLog, CancellationToken cancellationToken = default);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
