using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Data
{
    public class Connection : DbContext
    {
        public Connection(DbContextOptions<Connection> options) : base(options){}

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Project> Projects { get; set; }

        public void Delete(IDelete obj)
        {
            obj.IsDelete = true;
            Update(obj);
            SaveChanges();
        }

        public override EntityEntry Remove(object entity)
        {
            if (entity is IDelete obj)
            {
                Delete(obj);
            }
            return null;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne(p => p.ProjectManager)
                .WithMany(e => e.ManagedProjects)
                .HasForeignKey(p => p.ProjectManagerId)
                .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Project>()
                .HasMany(p => p.Employees)
                .WithMany(e => e.Projects)
                .UsingEntity(j => j.ToTable("ProjectEmployees"));

            modelBuilder.Entity<Employee>()
                .HasIndex(e => e.Email)
                .IsUnique();


            modelBuilder.Entity<Employee>()
                        .HasQueryFilter(e => !e.IsDelete);

            modelBuilder.Entity<Project>()
                        .HasQueryFilter(p => !p.IsDelete);

            base.OnModelCreating(modelBuilder);
        }

    }
}
