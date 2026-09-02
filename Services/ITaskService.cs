using Models.Response;
using Services.Models;

namespace Services;

public interface ITaskService
{
    Task<TaskResponse> CreateAsync(CreateTaskRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<TaskResponse>> GetByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default);
}