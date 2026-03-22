namespace CRMInmob.Api.Models;

public class PropertyFolder
{
    public int Id { get; set; }
    public string Code { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string OperationType { get; set; } = string.Empty;
    public string CurrentStatus { get; set; } = string.Empty;

    public ICollection<CrmTask> Tasks { get; set; } = new List<CrmTask>();
}
