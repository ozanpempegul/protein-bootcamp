using DatabaseHomework.Models;
using Microsoft.EntityFrameworkCore;

namespace DatabaseHomework.DbProvider;

public class PatikaDbContext : DbContext
{
    public PatikaDbContext(DbContextOptions<PatikaDbContext> options) : base(options)
    {
    }
    public DbSet<Folder> Folder { get; set; }
    public DbSet<Employee> Employee { get; set; }
}