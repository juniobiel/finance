using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Indentity.API.Data
{
    public class IdentityApplicationDbContext : IdentityDbContext
    {
        public IdentityApplicationDbContext(DbContextOptions<IdentityApplicationDbContext> options) : base(options) { }
    }
}
