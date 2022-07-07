using banner.Models;
using Microsoft.EntityFrameworkCore;

namespace banner.Context
{
    public class BannersContext : DbContext
    {
       public BannersContext(DbContextOptions opt):base(opt){}
       public DbSet<Banner> banner { get; set; }  
       public DbSet<User> users { get; set; }
    }
}
