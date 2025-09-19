using CareFlowX.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace CareFlowX.Api.Data
{
    // Database context for the application, managing entity sets.
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Referral> Referrals => Set<Referral>();
    }
}
