using Services.Models;

public interface IProjectService
{
    Task<ProjectResponse> CreateAsync(CreateProjectRequest request, CancellationToken cancellationToken = default);
    Task<IEnumerable<ProjectResponse>> GetAllAsync(CancellationToken cancellationToken = default);
    Task<ProjectResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken = default);
}