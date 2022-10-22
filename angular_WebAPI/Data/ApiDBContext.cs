using angular_WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace angular_WebAPI.Data
{
    public class ApiDBContext: DbContext
    {
        public ApiDBContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<user_table> user_table { get; set; }
    }
}
