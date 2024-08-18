using Microsoft.EntityFrameworkCore;

namespace Api.Verbs.Dictionary.Persistence
{
    public class EnglishVerbsContext : DbContext
    {
        public EnglishVerbsContext(DbContextOptions<EnglishVerbsContext> options) : base(options) { }

        public DbSet<Verbs.Dictionary.Models.Verbs> Verbs { get; set; }
    }
}
