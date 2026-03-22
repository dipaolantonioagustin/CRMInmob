namespace CRMInmob.Api.Models;

public class CrmTask
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public TaskPriority Priority { get; set; } = TaskPriority.Medium;
    public TaskStatus Status { get; set; } = TaskStatus.Pending;
    public DateTime DueDate { get; set; }

    public int? ContactId { get; set; }
    public Contact? Contact { get; set; }

    public int? PropertyFolderId { get; set; }
    public PropertyFolder? PropertyFolder { get; set; }

    public string AssignedToUserId { get; set; } = string.Empty;
    public AppUser? AssignedToUser { get; set; }

    public string CreatedByUserId { get; set; } = string.Empty;
    public AppUser? CreatedByUser { get; set; }
}
