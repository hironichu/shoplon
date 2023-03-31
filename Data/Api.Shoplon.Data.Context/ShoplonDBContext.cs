using System;
using System.Collections.Generic;
using Api.Shoplon.Data.Entities.Model;
using Microsoft.EntityFrameworkCore;
using Api.Shoplon.Data.Context.Contract;

namespace Api.Shoplon.Data.Context;

public partial class ShoplonDBContext : DbContext, IShoplonContext
{
    public ShoplonDBContext()
    {
    }

    public ShoplonDBContext(DbContextOptions<ShoplonDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CartLine> CartLines { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderLine> OrderLines { get; set; }

    public virtual DbSet<OrderStatus> OrderStatuses { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=100.68.51.113;port=32768;database=Shoplon;uid=root;pwd=Admin123", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.10.2-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<CartLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ClientId, "client");

            entity.HasIndex(e => e.ProductId, "product");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ClientId)
                .HasColumnType("int(11)")
                .HasColumnName("clientID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("productID");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Client).WithMany(p => p.CartLines)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("client");

            entity.HasOne(d => d.Product).WithMany(p => p.CartLines)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("product");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Hidden).HasColumnName("hidden");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ContactId, "contactID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ContactId)
                .HasColumnType("int(11)")
                .HasColumnName("contactID");
            entity.Property(e => e.CreationDate)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnName("creationDate");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .HasColumnName("email");
            entity.Property(e => e.Password)
                .HasColumnType("text")
                .HasColumnName("password");

            entity.HasOne(d => d.Contact).WithMany(p => p.Clients)
                .HasForeignKey(d => d.ContactId)
                .HasConstraintName("contactID");
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("Contact");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.AddressLine1)
                .HasColumnType("text")
                .HasColumnName("addressLine1");
            entity.Property(e => e.AddressLine2)
                .HasColumnType("text")
                .HasColumnName("addressLine2");
            entity.Property(e => e.City)
                .HasColumnType("text")
                .HasColumnName("city");
            entity.Property(e => e.Country)
                .HasColumnType("text")
                .HasColumnName("country");
            entity.Property(e => e.FirstName)
                .HasColumnType("text")
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasColumnType("text")
                .HasColumnName("lastName");
            entity.Property(e => e.Phone)
                .HasMaxLength(255)
                .HasColumnName("phone");
            entity.Property(e => e.Zip)
                .HasMaxLength(255)
                .HasColumnName("zip");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ClientId, "clientID");

            entity.HasIndex(e => e.Status, "status");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ClientId)
                .HasColumnType("int(11)")
                .HasColumnName("client_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnName("date");
            entity.Property(e => e.Status)
                .HasColumnType("int(11)")
                .HasColumnName("status");

            entity.HasOne(d => d.Client).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("clientID");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Status)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("orderStatus");
        });

        modelBuilder.Entity<OrderLine>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.OrderId, "orderID");

            entity.HasIndex(e => e.ProductId, "productID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("orderID");
            entity.Property(e => e.PriceUnit)
                .HasColumnType("int(11)")
                .HasColumnName("priceUnit");
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("productID");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("orderID");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderLines)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("productID");
        });

        modelBuilder.Entity<OrderStatus>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("OrderStatus");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.StatusText)
                .HasColumnType("text")
                .HasColumnName("statusText");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.ClientId, "clientID");

            entity.HasIndex(e => e.OrderId, "orderID");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.ClientId)
                .HasColumnType("int(11)")
                .HasColumnName("clientID");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("current_timestamp()")
                .HasColumnName("date");
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("orderID");
            entity.Property(e => e.Total)
                .HasMaxLength(255)
                .HasColumnName("total");

            entity.HasOne(d => d.Client).WithMany(p => p.Payments)
                .HasForeignKey(d => d.ClientId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payments_ibfk_1");

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payments_ibfk_2");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.HasIndex(e => e.CategorieId, "categorieID");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CategorieId)
                .HasColumnType("int(11)")
                .HasColumnName("categorieID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Quantity)
                .HasColumnType("int(11)")
                .HasColumnName("quantity");
            entity.Property(e => e.Unitprice)
                .HasColumnType("int(11)")
                .HasColumnName("unitprice");

            entity.HasOne(d => d.Categorie).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategorieId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorieID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
