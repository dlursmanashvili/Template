using Microsoft.EntityFrameworkCore;
using Template.Model.Models.AuditModel;
using Template.Model.Models.Templates;

namespace Template.Infrastructure.DataBaseHelper;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TemplateModel> Templates { get; set; }
    public DbSet<AuditModel> Audits { get; set; }
}