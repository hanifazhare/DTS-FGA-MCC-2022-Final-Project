using LeaveManagementWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace LeaveManagementWebAPI.Contexts
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContext) : base(dbContext)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Config Employee Model
            modelBuilder.Entity<Employee>()
                .HasIndex(model => new { model.email, model.phoneNumber })
                .IsUnique();

            modelBuilder.Entity<Employee>()
                .Property(model => model.createdAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<Employee>()
                .Property(model => model.updatedAt)
                .HasDefaultValueSql("getdate()");

            //Config User Model
            modelBuilder.Entity<User>()
                .Property(model => model.userRoleTypeId)
                .HasDefaultValue(2);

            modelBuilder.Entity<User>()
                .Property(model => model.availableLeaves)
                .HasDefaultValue(12);

            modelBuilder.Entity<User>()
                .Property(model => model.registeredAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<User>()
                .Property(model => model.updatedAt)
                .HasDefaultValueSql("getdate()");

            //Config LeaveRequest Model
            modelBuilder.Entity<LeaveRequest>()
                .Property(model => model.leaveStatusTypeId)
                .HasDefaultValue(1);

            modelBuilder.Entity<LeaveRequest>()
                .Property(model => model.createdAt)
                .HasDefaultValueSql("getdate()");

            modelBuilder.Entity<LeaveRequest>()
                .Property(model => model.updatedAt)
                .HasDefaultValueSql("getdate()");
        }

        public DbSet<UserRoleType> UserRoleTypes { get; set; }
        public DbSet<GenderType> GenderTypes { get; set; }
        public DbSet<LeaveStatusType> LeaveStatusTypes { get; set; }
        public DbSet<LeaveType> LeaveTypes { get; set; }
        public DbSet<DepartmentType> DepartmentTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<LeaveRequest> LeaveRequests { get; set; }
    }
}
