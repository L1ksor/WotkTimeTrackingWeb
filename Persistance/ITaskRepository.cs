using Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance
{
    public interface ITaskRepository
    {
        Task<ProjectTask?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IEnumerable<ProjectTask>> GetTasksByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default);
        Task CreateAsync(ProjectTask task, CancellationToken cancellationToken = default);
        Task<bool> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
