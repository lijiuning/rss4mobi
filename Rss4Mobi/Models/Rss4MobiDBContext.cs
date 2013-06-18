using System.Data.Entity;

namespace Rss4Mobi.Models
{
    public class Rss4MobiDBContext : DbContext
    {
        public DbSet<Member> Members { get; set; }
        public DbSet<PublicFeed> PublicFeeds { get; set; }
        public DbSet<PublicFeedBundle> Bundles { get; set; }
        public DbSet<PublicFeedCategory> Categories { get; set; }
    }
}