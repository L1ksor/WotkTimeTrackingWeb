using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class WorkLogRepository : BaseRepository<WorkLog>, IWorkLogRepository
    {
        public WorkLogRepository(WorktimeDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<WorkLog>> GetByDateAsync(DateOnly date, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(w => w.Task) // Подтягиваем задачу, чтобы знать её название
                .Where(w => w.WorkDate == date)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<WorkLog>> GetByDateRangeAsync(DateOnly startDate, DateOnly endDate, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Include(w => w.Task)
                .Where(w => w.WorkDate >= startDate && w.WorkDate <= endDate)
                .ToListAsync(cancellationToken);
        }

        public async Task<IEnumerable<WorkLog>> GetByTaskIdAsync(Guid taskId, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(w => w.TaskId == taskId)
                .ToListAsync(cancellationToken);
        }

        public async Task<decimal> GetTotalHoursByDateAsync(DateOnly date, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .AsNoTracking()
                .Where(w => w.WorkDate == date)
                .SumAsync(w => w.Hours, cancellationToken);
        }
    }
}
