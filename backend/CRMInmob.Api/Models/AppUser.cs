using Microsoft.AspNetCore.Identity;

namespace CRMInmob.Api.Models;

public class AppUser : IdentityUser
{
    public string FullName { get; set; } = string.Empty;
}
