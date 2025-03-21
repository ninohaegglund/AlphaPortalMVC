using DataTest.Entities;
using Microsoft.EntityFrameworkCore;


namespace DataTest.Contexts
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<ProjectEntity> Projects { get; set; }
    }
}
