using CRMInmob.Api.Models;

namespace CRMInmob.Api.DTOs;

public record CreateTaskRequest(
    string Title,
    string Description,
    TaskPriority Priority,
    DateTime DueDate,
    string AssignedToUserId,
    string CreatedByUserId,
    int? ContactId,
    int? PropertyFolderId);

public record UpdateTaskStatusRequest(TaskStatus Status);

public record TaskResponse(
    int Id,
    string Title,
    string Description,
    TaskPriority Priority,
    TaskStatus Status,
    DateTime DueDate,
    string AssignedToUserId,
    int? ContactId,
    int? PropertyFolderId);
