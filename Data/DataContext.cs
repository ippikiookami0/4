using LataPrzestepne.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml;

namespace LataPrzestepne.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<HistoryDB> HistoryDB { get; set; }
    }
}
