using CRMInmob.Api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CRMInmob.Api.Data;

public class ApplicationDbContext : IdentityDbContext<AppUser>
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<CrmTask> Tasks => Set<CrmTask>();
    public DbSet<Contact> Contacts => Set<Contact>();
    public DbSet<PropertyFolder> PropertyFolders => Set<PropertyFolder>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Contact>()
            .Property(c => c.FullName)
            .HasMaxLength(140);

        builder.Entity<PropertyFolder>()
            .HasIndex(p => p.Code)
            .IsUnique();

        builder.Entity<CrmTask>()
            .HasOne(t => t.AssignedToUser)
            .WithMany()
            .HasForeignKey(t => t.AssignedToUserId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<CrmTask>()
            .HasOne(t => t.CreatedByUser)
            .WithMany()
            .HasForeignKey(t => t.CreatedByUserId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
