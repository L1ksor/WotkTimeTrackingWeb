using Domain;
using Models.Response;
using Services.Models;
using Persistance;
namespace Services;

public class TaskService : ITaskService
{
    private readonly ITaskRepository _taskRepository;
    private readonly IProjectRepository _projectRepository;

    public TaskService(ITaskRepository taskRepository, IProjectRepository projectRepository)
    {
        _taskRepository = taskRepository;
        _projectRepository = projectRepository;
    }

    public async Task<TaskResponse> CreateAsync(CreateTaskRequest request, CancellationToken cancellationToken = default)
    {
        var project = await _projectRepository.GetByIdAsync(request.ProjectId, cancellationToken);
        if (project == null)
        {
            throw new KeyNotFoundException($"Проект с ID {request.ProjectId} не найден.");
        }

        var task = new ProjectTask
        {
            ProjectId = request.ProjectId,
            Name = request.Name,
            Description = request.Description,
            IsActive = true
        };

        await _taskRepository.CreateAsync(task, cancellationToken);
        await _taskRepository.SaveChangesAsync(cancellationToken);

        return MapToResponse(task);
    }

    public async Task<IEnumerable<TaskResponse>> GetByProjectIdAsync(Guid projectId, CancellationToken cancellationToken = default)
    {
        var tasks = await _taskRepository.GetTasksByProjectIdAsync(projectId, cancellationToken);
        return tasks.Select(MapToResponse);
    }

    private static TaskResponse MapToResponse(ProjectTask task) => new(
        task.Id,
        task.ProjectId,
        task.Name,
        task.Description,
        task.IsActive
    );
}