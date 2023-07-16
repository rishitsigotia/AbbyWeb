using AbbyWeb.Model;
using Microsoft.EntityFrameworkCore;

namespace AbbyWeb.Data
{  
    public class ApplicationDbContext: DbContext // it will be like data layer. It should include DbContext
    {
        public DbSet<Category> Category { get; set; }
        
    }
}
