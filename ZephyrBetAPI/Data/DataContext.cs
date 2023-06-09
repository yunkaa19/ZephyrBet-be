using Microsoft.EntityFrameworkCore;
using ZephyrBet.Models.Entity;

namespace ZephyrBetAPI.Data;

public class DataContext : DbContext
{
    public DataContext(DbContextOptions<DataContext> options) : base(options)
    {
        
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Player> Players { get; set; }
    
    public DbSet<Casino> Casino { get; set; }
}