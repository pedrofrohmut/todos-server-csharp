using Microsoft.EntityFrameworkCore;
using TodoServer.Web.Entities;

namespace TodoServer.Web.Context
{
  public class AppDbContext : DbContext
  {
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Task> Tasks { get; set; }
    public DbSet<Todo> Todos { get; set; }
  }
}
