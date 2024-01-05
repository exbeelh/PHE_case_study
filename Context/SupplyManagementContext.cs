using Microsoft.EntityFrameworkCore;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace SupplyManagement.Models
{
    public partial class SupplyManagementContext : DbContext
    {
        public SupplyManagementContext()
        {
        }

        public SupplyManagementContext(DbContextOptions<SupplyManagementContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BusinessFields> BusinessFields { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<CompanyDetails> CompanyDetails { get; set; }
        public virtual DbSet<CompanyTypes> CompanyTypes { get; set; }
        public virtual DbSet<ProjectVendor> ProjectVendor { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Status> Status { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-JTNIE6M\\SQLEXPRESS;Database=db_supply_management;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BusinessFields>(entity =>
            {
                entity.ToTable("business_fields");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Companies>(entity =>
            {
                entity.ToTable("companies");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovalStatusId).HasColumnName("approval_status_id");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasColumnName("phone")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasColumnName("image")
                    .HasColumnType("varbinary(max)");

                entity.Property(e => e.UserId)
                    .HasColumnName("user_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.ApprovalStatus)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.ApprovalStatusId)
                    .HasConstraintName("FK__companies__appro__5629CD9C");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Companies)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__companies__user___5535A963");
            });

            modelBuilder.Entity<CompanyDetails>(entity =>
            {
                entity.HasKey(e => e.CompanyId)
                    .HasName("PK__company___3E267235A7B51251");

                entity.ToTable("company_details");

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.BusinessFieldId).HasColumnName("business_field_id");

                entity.Property(e => e.CompanyTypeId).HasColumnName("company_type_id");

                entity.HasOne(d => d.BusinessField)
                    .WithMany(p => p.CompanyDetails)
                    .HasForeignKey(d => d.BusinessFieldId)
                    .HasConstraintName("FK__company_d__busin__59FA5E80");

                entity.HasOne(d => d.Company)
                    .WithOne(p => p.CompanyDetails)
                    .HasForeignKey<CompanyDetails>(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__company_d__compa__59063A47");

                entity.HasOne(d => d.CompanyType)
                    .WithMany(p => p.CompanyDetails)
                    .HasForeignKey(d => d.CompanyTypeId)
                    .HasConstraintName("FK__company_d__compa__5AEE82B9");
            });

            modelBuilder.Entity<CompanyTypes>(entity =>
            {
                entity.ToTable("company_types");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjectVendor>(entity =>
            {
                entity.HasKey(e => e.ProjectId)
                    .HasName("PK__project___BC799E1F655A7740");

                entity.ToTable("project_vendor");

                entity.Property(e => e.ProjectId)
                    .HasColumnName("project_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.CompanyId)
                    .HasColumnName("company_id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.ProjectVendor)
                    .HasForeignKey(d => d.CompanyId)
                    .HasConstraintName("FK__project_v__compa__60A75C0F");

                entity.HasOne(d => d.Project)
                    .WithOne(p => p.ProjectVendor)
                    .HasForeignKey<ProjectVendor>(d => d.ProjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__project_v__compa__5FB337D6");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.ToTable("projects");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasColumnName("description")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Status>(entity =>
            {
                entity.ToTable("status");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Email)
                    .HasName("UQ__users__AB6E6164DF5B0268")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasMaxLength(36)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK__users__role_id__52593CB8");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
