using Exam.Domain;
using Microsoft.EntityFrameworkCore;

namespace Exam.DAL
{
    public class AppDbContext : DbContext
    {

            public DbSet<UserAccount> UserAccounts { get; set; }  
            public DbSet<PersonalInfo> PersonalInfos { get; set; }
            public DbSet<ResidentialInfo> ResidentialInfos { get; set; }
            public AppDbContext(DbContextOptions options) : base(options)  
            {
            }
    }
}
