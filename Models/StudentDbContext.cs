using Microsoft.EntityFrameworkCore;

namespace ASPCoreWebAPICURD.Models
{
    public class StudentDbContext:DbContext
    {
        public StudentDbContext(DbContextOptions<StudentDbContext> options) :base(options)
        {
            
        }
        public DbSet<StudentAPI> StudentAPIS { get; set; }
    }
}
