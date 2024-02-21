
using Microsoft.EntityFrameworkCore;

namespace ShopApi.Models;

public partial class ShopContext : DbContext
{
    public ShopContext()
    {
    }

    public ShopContext(DbContextOptions<ShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<DayReport> DayReports { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC079531F140");

            entity.ToTable("Customer");

            entity.Property(e => e.Dni)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Last_Name");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DayReport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DayRepor__3214EC07011AA95C");

            entity.ToTable("DayReport");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Itbs).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(18, 2)");
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Invoice__3214EC07BBD6D8AF");

            entity.ToTable("Invoice");

            entity.Property(e => e.CountProducts).HasColumnName("Count_Products");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.DueDate)
                .HasColumnType("datetime")
                .HasColumnName("Due_Date");
            entity.Property(e => e.IdUser).HasColumnName("Id_User");
            entity.Property(e => e.Itbs)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LProducts).HasColumnName("L_Products");
            entity.Property(e => e.Payment)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Subtotal)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Total)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Type).HasDefaultValue(false);

            entity.HasOne(d => d.CustomerNavigation).WithMany(p => p.InvoiceCustomerNavigations)
                .HasForeignKey(d => d.Customer)
                .HasConstraintName("FK__Invoice__Custome__4222D4EF");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.InvoiceIdUserNavigations)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK__Invoice__Id_User__412EB0B6");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC0724DB0EDB");

            entity.Property(e => e.Cost)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Price)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Type).HasDefaultValue(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC074A0926D4");

            entity.Property(e => e.Contry)
                .HasMaxLength(3)
                .IsUnicode(false)
                .HasDefaultValue("+1");
            entity.Property(e => e.Date).HasColumnType("datetime");
            entity.Property(e => e.Name)
                .HasMaxLength(80)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
