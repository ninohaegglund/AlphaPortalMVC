using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Data.Contexts;

public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
{
    public DataContext CreateDbContext(string[] args)
    {
 
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Nackademin\ASP.NET1\AlphaAdminPortal\Data\Contexts\Database\alpha_database.mdf;Integrated Security=True;Connect Timeout=30");

        return new DataContext(optionsBuilder.Options);
    }
}
