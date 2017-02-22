namespace nTierWithMVC.DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class nTierWithMVCContext : DbContext
    {
        public nTierWithMVCContext()
            : base("name=nTierWithMVCContext")
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<StudentAssignment> StudentAssignments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Assignment>()
                .HasMany(e => e.StudentAssignments)
                .WithRequired(e => e.Assignment)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Student>()
                .HasMany(e => e.StudentAssignments)
                .WithRequired(e => e.Student)
                .WillCascadeOnDelete(false);
        }
    }
}
