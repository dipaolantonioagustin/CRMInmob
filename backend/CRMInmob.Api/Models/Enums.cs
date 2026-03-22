namespace CRMInmob.Api.Models;

public enum TaskPriority
{
    Low = 1,
    Medium = 2,
    High = 3,
    Critical = 4
}

public enum TaskStatus
{
    Pending = 1,
    InProgress = 2,
    WaitingClient = 3,
    Completed = 4,
    Cancelled = 5
}

public enum LeadType
{
    Rental = 1,
    Sale = 2,
    Development = 3
}
