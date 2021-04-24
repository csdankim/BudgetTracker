using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class BudgetTrackerDbContext:DbContext
    {
        public BudgetTrackerDbContext(DbContextOptions<BudgetTrackerDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Income> Incomes { get; set; }
        public DbSet<Expenditure> Expenditures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(ConfigureUser);
            modelBuilder.Entity<Income>(ConfigureIncome);
            modelBuilder.Entity<Expenditure>(ConfigureExpenditure);
        }

        private void ConfigureUser(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Email).HasMaxLength(50).IsRequired();
            builder.Property(u => u.Password).HasMaxLength(10).IsRequired();
            builder.Property(u => u.Fullname).HasMaxLength(50);
            builder.Property(u => u.JoinedOn);
        }

        private void ConfigureIncome(EntityTypeBuilder<Income> builder)
        {
            builder.ToTable("Incomes");
            builder.HasKey(i=> i.Id);
            builder.Property(i => i.UserId);
            builder.Property(i => i.Amount).IsRequired();
            builder.Property(i => i.Description).HasMaxLength(100);
            builder.Property(i => i.IncomeDate);
            builder.Property(i => i.Remarks).HasMaxLength(500);
            builder.HasOne(i=>i.User).WithMany(i => i.Incomes).HasForeignKey(i => i.UserId);
        }

        private void ConfigureExpenditure(EntityTypeBuilder<Expenditure> builder)
        {
            builder.ToTable("Expenditures");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.UserId);
            builder.Property(e => e.Amount).IsRequired();
            builder.Property(e => e.Description).HasMaxLength(100);
            builder.Property(e => e.ExpDate);
            builder.Property(e => e.Remarks).HasMaxLength(500);
            builder.HasOne(e => e.User).WithMany(e =>e.Expenditures).HasForeignKey(e => e.UserId);
        }
    }
}