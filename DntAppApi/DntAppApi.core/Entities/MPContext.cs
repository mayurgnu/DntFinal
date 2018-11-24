using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DntAppApi.core.Entities
{
    public partial class MPContext : DbContext
    {
        public MPContext()
        {
        }

        public MPContext(DbContextOptions<MPContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<BookClone> BookClone { get; set; }
        public virtual DbSet<Library> Library { get; set; }
        public virtual DbSet<MstCart> MstCart { get; set; }
        public virtual DbSet<TblCities> TblCities { get; set; }
        public virtual DbSet<TblOrderDetail> TblOrderDetail { get; set; }
        public virtual DbSet<TblOrderMst> TblOrderMst { get; set; }
        public virtual DbSet<TblProduct> TblProduct { get; set; }
        public virtual DbSet<TblRole> TblRole { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("data source=DESKTOP-4VG8BV2\\SQLEXPRESS; initial catalog=MP;Integrated Security=true");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.BookName)
                    .HasColumnName("Book_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dept)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LibraryId).HasColumnName("Library_Id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");
            });

            modelBuilder.Entity<BookClone>(entity =>
            {
                entity.HasKey(e => e.BookId);

                entity.ToTable("Book_Clone");

                entity.Property(e => e.BookId).HasColumnName("Book_Id");

                entity.Property(e => e.BookName)
                    .HasColumnName("Book_Name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Dept)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.LibraryId).HasColumnName("Library_Id");

                entity.Property(e => e.SubjectId).HasColumnName("Subject_Id");
            });

            modelBuilder.Entity<Library>(entity =>
            {
                entity.Property(e => e.LibraryId).HasColumnName("Library_id");

                entity.Property(e => e.Department).HasMaxLength(50);
            });

            modelBuilder.Entity<MstCart>(entity =>
            {
                entity.ToTable("MST_Cart");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.Property(e => e.UserId).HasColumnName("User_Id");
            });

            modelBuilder.Entity<TblCities>(entity =>
            {
                entity.HasKey(e => e.CityId);

                entity.ToTable("tblCities");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TblOrderDetail>(entity =>
            {
                entity.ToTable("TBL_Order_Detail");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OrderId).HasColumnName("Order_ID");

                entity.Property(e => e.ProductId).HasColumnName("Product_Id");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.TblOrderDetail)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_Order_Detail_TBL_Order_MST");
            });

            modelBuilder.Entity<TblOrderMst>(entity =>
            {
                entity.HasKey(e => e.OrderId);

                entity.ToTable("TBL_Order_MST");

                entity.Property(e => e.OrderId)
                    .HasColumnName("Order_ID")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.OrderNo)
                    .HasColumnName("Order_No")
                    .HasMaxLength(50);

                entity.Property(e => e.PayableAmount).HasMaxLength(10);

                entity.HasOne(d => d.Order)
                    .WithOne(p => p.InverseOrder)
                    .HasForeignKey<TblOrderMst>(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TBL_Order_MST_TBL_Order_MST");
            });

            modelBuilder.Entity<TblProduct>(entity =>
            {
                entity.HasKey(e => e.Productid);

                entity.ToTable("tblProduct");

                entity.Property(e => e.Productid).HasColumnName("productid");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");
            });

            modelBuilder.Entity<TblRole>(entity =>
            {
                entity.ToTable("tblRole");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Createddate)
                    .HasColumnName("createddate")
                    .HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TblUser>(entity =>
            {
                entity.ToTable("tblUser");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(100);

                entity.Property(e => e.Birthdate)
                    .HasColumnName("birthdate")
                    .HasColumnType("date");

                entity.Property(e => e.Cityid).HasColumnName("cityid");

                entity.Property(e => e.Contactno)
                    .HasColumnName("contactno")
                    .HasMaxLength(25);

                entity.Property(e => e.Countryid).HasColumnName("countryid");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(100);

                entity.Property(e => e.Firstname)
                    .HasColumnName("firstname")
                    .HasMaxLength(50);

                entity.Property(e => e.Gender).HasColumnName("gender");

                entity.Property(e => e.Isemailverified).HasColumnName("isemailverified");

                entity.Property(e => e.Isloginallowed).HasColumnName("isloginallowed");

                entity.Property(e => e.Lastname)
                    .HasColumnName("lastname")
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(50);

                entity.Property(e => e.Profilepicture)
                    .HasColumnName("profilepicture")
                    .HasMaxLength(500);

                entity.Property(e => e.Stateid).HasColumnName("stateid");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(50);
            });
        }
    }
}
