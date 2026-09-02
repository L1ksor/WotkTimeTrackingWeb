using Domain;
using Models.Response;
using Persistance;
using Services.Models;
using System.Threading.Tasks;

namespace Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public async Task<ProjectResponse> CreateAsync(CreateProjectRequest request, CancellationToken cancellationToken = default)
        {
            var existingProject = await _projectRepository.GetByCodeAsync(request.Code, cancellationToken);
            if (existingProject != null)
            {
                throw new InvalidOperationException($"Проект с кодом '{request.Code}' уже существует.");
            }

            var project = new Project
            {
                Code = request.Code,
                Name = request.Name,
                IsActive = true
            };

            await _projectRepository.CreateAsync(project, cancellationToken);
            await _projectRepository.SaveChangesAsync(cancellationToken);
            return MapToResponse(project);
        }

        public async Task<IEnumerable<ProjectResponse>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var projects = await _projectRepository.GetAllAsync(cancellationToken);
            return projects.Select(x => MapToResponse(x));
        }

        public async Task<ProjectResponse?> GetByCodeAsync(string code, CancellationToken cancellationToken = default)
        {
            var project = await _projectRepository.GetByCodeAsync(code, cancellationToken);
            return project != null ? MapToResponse(project) : null;
        }

        private static ProjectResponse MapToResponse(Project project) => new(
            project.Id,
            project.Code,
            project.Name,
            project.IsActive
            );
    }
}
