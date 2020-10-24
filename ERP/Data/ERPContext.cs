using System;
using ERP.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace ERP.Data
{
    public partial class ERPContext : DbContext
    {
        public ERPContext()
        {
        }

        public ERPContext(DbContextOptions<ERPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categoria> Categorias { get; set; }
        public virtual DbSet<Cliente> Clientes { get; set; }
        public virtual DbSet<Empleado> Empleados { get; set; }
        public virtual DbSet<LineasPedido> LineasPedidos { get; set; }
        public virtual DbSet<Pedido> Pedidos { get; set; }
        public virtual DbSet<Producto> Productos { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ERP;Trusted_Connection=True;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Address).HasMaxLength(50);

                entity.Property(e => e.City).HasMaxLength(50);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Province).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<Empleado>(entity =>
            {
                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Surname).HasMaxLength(50);
            });

            modelBuilder.Entity<LineasPedido>(entity =>
            {
                entity.HasKey(e => e.Id);

                entity.ToTable("LineasPedido");

                entity.Property(e => e.Id)
                    .ValueGeneratedNever()
                    .HasColumnName("idLinea");

                entity.Property(e => e.IdPedido).HasColumnName("idPedido");

                entity.Property(e => e.IdProducto).HasColumnName("idProducto");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithMany(p => p.LineasPedidos)
                    .HasForeignKey(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineasPedido_Pedidos");

                entity.HasOne(d => d.IdProductoNavigation)
                    .WithMany(p => p.LineasPedidos)
                    .HasForeignKey(d => d.IdProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_LineasPedido_Productos");
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AssingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("assingDate")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("createDate")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.FinishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("finishDate")
                    .HasAnnotation("Relational:ColumnType", "datetime");

                entity.Property(e => e.IdCostumer).HasColumnName("idCostumer");

                entity.Property(e => e.IdEmployee).HasColumnName("idEmployee");

                entity.Property(e => e.Priority)
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.Property(e => e.State)
                    .HasMaxLength(15)
                    .IsFixedLength(true);

                entity.HasOne(d => d.IdCostumerNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdCostumer)
                    .HasConstraintName("FK_Pedidos_Clientes");

                entity.HasOne(d => d.IdEmployeeNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.IdEmployee)
                    .HasConstraintName("FK_Pedidos_Empleados1");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.IdCategory).HasColumnName("idCategory");

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.IdCategoryNavigation)
                    .WithMany(p => p.Productos)
                    .HasForeignKey(d => d.IdCategory)
                    .HasConstraintName("FK_Productos_Categorias");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
