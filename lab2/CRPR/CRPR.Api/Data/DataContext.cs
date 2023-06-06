using Microsoft.EntityFrameworkCore;

namespace CRPR.Api.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    
    public virtual DbSet<Book> Books { get; set; }
}