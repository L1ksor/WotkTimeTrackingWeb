using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    internal class TaskRepository : BaseRepository<ProjectTask>, ITaskRepository
    {


        public TaskRepository(WorktimeDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<ProjectTask>> GetTasksByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default)
        {
            return await _dbSet
                .Where(t => t.ProjectId == projectId)
                .ToListAsync(cancellationToken);
        }
    }
}
