using Microsoft.EntityFrameworkCore;
using SweeftTasks.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweeftTasks.Data
{
    public class SchoolDbContext : DbContext
    {
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Pupil> Pupils { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Database=SweeftTasksDB;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Teacher>()
                .HasMany(t => t.Pupils)
                .WithMany(p => p.Teachers)
                .UsingEntity(j => j.ToTable("TeacherPupil"));
        }
    }
}
