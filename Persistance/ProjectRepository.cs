using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistance
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(WorktimeDbContext context) : base(context)
        {
        }

        public async Task<Project?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            return await _dbSet.FirstOrDefaultAsync(x => x.Code == code, cancellationToken);
        }


    }
}
