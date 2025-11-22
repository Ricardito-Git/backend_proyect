using Microsoft.EntityFrameworkCore;
using backend_proyect.Models.Entities;

namespace backend_proyect.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Todas las tablas
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Perfil> Perfiles { get; set; }
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Almacen> Almacenes { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Pasillo> Pasillos { get; set; }
        public DbSet<Rack> Racks { get; set; }
        public DbSet<TipoProducto> TiposProducto { get; set; }
        public DbSet<SubtipoProducto> SubtiposProducto { get; set; }
        public DbSet<Familia> Familias { get; set; }
        public DbSet<Presentacion> Presentacion { get; set; }
        public DbSet<ExcepcionProducto> ExcepcionesProducto { get; set; }
        public DbSet<EstadoProducto> EstadoProductos { get; set; }
        public DbSet<MotivoTraspaso> MotivosTraspaso { get; set; }
        public DbSet<ConceptoEntradaSalida> ConceptosEntradaSalida { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Usar PascalCase para coincidir con tu BD
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.ToTable("Usuarios");  // ← PascalCase
                entity.HasKey(u => u.IdUsuario);
                entity.Property(u => u.IdUsuario).HasColumnName("id_usuario");
                entity.Property(u => u.IdPerfil).HasColumnName("id_perfil");
                entity.Property(u => u.Nombre).HasColumnName("nombre");
                entity.Property(u => u.Password).HasColumnName("password");
                entity.Property(u => u.Activo).HasColumnName("activo");
                entity.Property(u => u.FechaUltMov).HasColumnName("fecha_ult_mov");
                entity.Property(u => u.UsuarioUltMov).HasColumnName("usuario_ult_mov");
                
                entity.HasOne(u => u.Perfil)
                    .WithMany(p => p.Usuarios)
                    .HasForeignKey(u => u.IdPerfil);
            });

            modelBuilder.Entity<Perfil>(entity =>
            {
                entity.ToTable("Perfiles");  // ← PascalCase
                entity.HasKey(p => p.IdPerfil);
                entity.Property(p => p.IdPerfil).HasColumnName("id_perfil");
                entity.Property(p => p.Descripcion).HasColumnName("descripcion");
                entity.Property(p => p.Activo).HasColumnName("activo");
                entity.Property(p => p.FechaUltMov).HasColumnName("fecha_ult_mov");
                entity.Property(p => p.UsuarioUltMov).HasColumnName("usuario_ult_mov");
            });

            // Todas las tablas en PascalCase
            modelBuilder.Entity<Empresa>().ToTable("Empresas").HasKey(e => e.IdEmpresa);
            modelBuilder.Entity<Almacen>().ToTable("Almacenes").HasKey(a => a.IdAlmacen);
            modelBuilder.Entity<Cliente>().ToTable("Clientes").HasKey(c => c.IdCliente);
            modelBuilder.Entity<Proveedor>().ToTable("Proveedores").HasKey(p => p.IdProveedor);
            modelBuilder.Entity<Producto>().ToTable("Productos").HasKey(p => p.IdProducto);
            modelBuilder.Entity<Pasillo>().ToTable("Pasillos").HasKey(p => p.IdPasillo);
            modelBuilder.Entity<Rack>().ToTable("Racks").HasKey(r => r.IdRack);
            modelBuilder.Entity<TipoProducto>().ToTable("TiposProducto").HasKey(t => t.IdTipo);
            modelBuilder.Entity<SubtipoProducto>().ToTable("SubtiposProducto").HasKey(s => s.IdSubtipo);
            modelBuilder.Entity<Familia>().ToTable("Familias").HasKey(f => f.IdFamilia);
            modelBuilder.Entity<Presentacion>().ToTable("Presentacion").HasKey(p => p.IdPresentacion);
            modelBuilder.Entity<ExcepcionProducto>().ToTable("ExcepcionesProducto").HasKey(e => e.IdExcepcion);
            modelBuilder.Entity<EstadoProducto>().ToTable("EstadoProductos").HasKey(e => e.IdEstado);
            modelBuilder.Entity<MotivoTraspaso>().ToTable("MotivosTraspasos").HasKey(m => m.IdMotivo);
            modelBuilder.Entity<ConceptoEntradaSalida>().ToTable("ConceptosEntradaSalida").HasKey(c => c.IdConcepto);
        }
    }
}
