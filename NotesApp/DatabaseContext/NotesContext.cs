using EnteryourWorld.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EnteryourWorld.DatabaseContext
{
    public class NotesContext : DbContext
    {

        public DbSet<Note> Notes { get; set; }

        private readonly IConfiguration _configuration;

        public NotesContext(DbContextOptions<NotesContext> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("notesDb"));
        }
    }
}
