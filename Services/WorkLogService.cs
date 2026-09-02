using Domain;
using Persistance;
using Services.Models;

namespace Services;

public class WorkLogService : IWorkLogService
{
    private readonly IWorkLogRepository _workLogRepository;
    private readonly ITaskRepository _taskRepository;

    public WorkLogService(IWorkLogRepository workLogRepository, ITaskRepository taskRepository)
    {
        _workLogRepository = workLogRepository;
        _taskRepository = taskRepository;
    }

    public async Task<WorkLogResponse> CreateAsync(CreateWorkLogRequest request, CancellationToken cancellationToken = default)
    {
        if (request.Hours <= 0)
        {
            throw new ArgumentException("Количество часов должно быть больше нуля.");
        }

        var task = await _taskRepository.GetByIdAsync(request.TaskId, cancellationToken);
        if (task == null)
        {
            throw new KeyNotFoundException($"Задача с ID {request.TaskId} не найдена.");
        }

        var workLog = new WorkLog
        {
            Id = Guid.NewGuid(),
            TaskId = request.TaskId,
            Hours = request.Hours,
            Description = request.Comment,
            WorkDate = request.WorkDate
        };
        workLog.SetCreatedOn(DateTime.UtcNow);

        await _workLogRepository.CreateAsync(workLog, cancellationToken);
        await _workLogRepository.SaveChangesAsync(cancellationToken);

        return MapToResponse(workLog);
    }

    public async Task<IEnumerable<WorkLogResponse>> GetByDateAsync(DateOnly date, CancellationToken cancellationToken = default)
    {
        var logs = await _workLogRepository.GetByDateAsync(date, cancellationToken);
        return logs.Select(MapToResponse);
    }

    public async Task<DaySummaryResponse> GetDaySummaryAsync(DateOnly date, CancellationToken cancellationToken = default)
    {
        var totalHours = await _workLogRepository.GetTotalHoursByDateAsync(date, cancellationToken);
        var logs = await _workLogRepository.GetByDateAsync(date, cancellationToken);

        var workLogResponses = logs.Select(MapToResponse).ToList();

        return new DaySummaryResponse(
            date,
            totalHours,
            workLogResponses
        );
    }

    private static WorkLogResponse MapToResponse(WorkLog workLog) => new(
        workLog.Id,
        workLog.TaskId,
        workLog.Hours,
        workLog.Description,
        workLog.WorkDate
    );
}