using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Persistence.Contexts
{
    public class BaseDbContext : DbContext
    {
        protected IConfiguration Configuration { get; set; }
        public DbSet<ProgrammingLanguageEntity> ProgrammingLanguageEntities { get; set; }


        public BaseDbContext(DbContextOptions dbContextOptions, IConfiguration configuration) : base(dbContextOptions)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
                base.OnConfiguring(
                    optionsBuilder.UseSqlServer(Configuration.GetConnectionString("HrmsProjectConnectionString")));
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProgrammingLanguageEntity>(a =>
            {
                a.ToTable("ProgrammingLanguageEntities").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasMany(p => p.Technologies);
            });

            modelBuilder.Entity<TechnologyEntity>(a =>
            {
                a.ToTable("Technologies").HasKey(k => k.Id);
                a.Property(p => p.Id).HasColumnName("Id");
                a.Property(p => p.Name).HasColumnName("Name");
                a.HasOne(p => p.ProgrammingLanguage);
            });



            ProgrammingLanguageEntity[] programmingLanguageSeeds = { new(1, "Java"), new(2, "CSharp") };
            TechnologyEntity[] technologies = { new(1,1, "Spring"), new(2,2, "Blazor") };

            modelBuilder.Entity<TechnologyEntity>().HasData(technologies);
            modelBuilder.Entity<ProgrammingLanguageEntity>().HasData(programmingLanguageSeeds);


        }
    }
}
