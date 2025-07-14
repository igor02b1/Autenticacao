using Autenticacao.Models;
using Microsoft.EntityFrameworkCore;

namespace Autenticacao.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options): base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
    }
}
