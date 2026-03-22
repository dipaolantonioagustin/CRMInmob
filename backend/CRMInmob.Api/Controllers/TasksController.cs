using CRMInmob.Api.Data;
using CRMInmob.Api.DTOs;
using CRMInmob.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRMInmob.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TasksController : ControllerBase
{
    private readonly ApplicationDbContext _db;

    public TasksController(ApplicationDbContext db)
    {
        _db = db;
    }

    [HttpGet("my-day/{userId}")]
    public async Task<ActionResult<IEnumerable<TaskResponse>>> GetMyDay(string userId)
    {
        var tasks = await _db.Tasks
            .Where(t => t.AssignedToUserId == userId && t.Status != TaskStatus.Completed)
            .OrderByDescending(t => t.Priority)
            .ThenBy(t => t.DueDate)
            .Select(t => new TaskResponse(
                t.Id,
                t.Title,
                t.Description,
                t.Priority,
                t.Status,
                t.DueDate,
                t.AssignedToUserId,
                t.ContactId,
                t.PropertyFolderId))
            .ToListAsync();

        return Ok(tasks);
    }

    [HttpPost]
    public async Task<ActionResult<TaskResponse>> Create(CreateTaskRequest request)
    {
        var task = new CrmTask
        {
            Title = request.Title,
            Description = request.Description,
            Priority = request.Priority,
            DueDate = request.DueDate,
            AssignedToUserId = request.AssignedToUserId,
            CreatedByUserId = request.CreatedByUserId,
            ContactId = request.ContactId,
            PropertyFolderId = request.PropertyFolderId
        };

        _db.Tasks.Add(task);
        await _db.SaveChangesAsync();

        var response = new TaskResponse(
            task.Id,
            task.Title,
            task.Description,
            task.Priority,
            task.Status,
            task.DueDate,
            task.AssignedToUserId,
            task.ContactId,
            task.PropertyFolderId);

        return CreatedAtAction(nameof(GetById), new { id = task.Id }, response);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<TaskResponse>> GetById(int id)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task is null)
        {
            return NotFound();
        }

        return Ok(new TaskResponse(
            task.Id,
            task.Title,
            task.Description,
            task.Priority,
            task.Status,
            task.DueDate,
            task.AssignedToUserId,
            task.ContactId,
            task.PropertyFolderId));
    }

    [HttpPatch("{id:int}/status")]
    public async Task<IActionResult> UpdateStatus(int id, UpdateTaskStatusRequest request)
    {
        var task = await _db.Tasks.FindAsync(id);
        if (task is null)
        {
            return NotFound();
        }

        task.Status = request.Status;
        await _db.SaveChangesAsync();

        return NoContent();
    }
}
