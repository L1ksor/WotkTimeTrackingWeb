using Microsoft.AspNetCore.Mvc;
using Services.Models;
using System.Threading;

namespace WebApplication1.Controllers;


[ApiController]
[Route("api/projects")]
public class ProjectsController : ControllerBase
{
    private readonly IProjectService _projectService;

    public ProjectsController(IProjectService projectService)
    {
        _projectService = projectService;
    }

    [HttpGet("{code}")]
    public async Task<ActionResult<ProjectResponse>> GetByCodeAsync(string code, CancellationToken cancellationToken)
    {
        var response = await _projectService.GetByCodeAsync(code, cancellationToken);
        return Ok(response);
    }

    [HttpPost]
    public async Task<ActionResult<ProjectResponse>> CreateAsync([FromBody] CreateProjectRequest request, CancellationToken cancellationToken)
    {
        var respnse = await _projectService.CreateAsync(request, cancellationToken);
        return Ok(respnse);
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ProjectResponse>>> GetAllAsync(CancellationToken cancellationToken)
    {
        var respnse = await _projectService.GetAllAsync(cancellationToken);
        return Ok(respnse);
    }



}

