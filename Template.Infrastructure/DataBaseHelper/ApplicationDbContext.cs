using Microsoft.EntityFrameworkCore;
using Template.Model.Models;

namespace Template.Infrastructure.DataBaseHelper;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<TemplateModel> Templates { get; set; }
}