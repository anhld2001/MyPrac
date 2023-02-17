using Microsoft.EntityFrameworkCore;
using Prac1.Model;

namespace Prac1.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<HangHoa> HangHoas { get; set; }
        public DbSet<Loai> Loais { get; set; }
        public DbSet<DonHang> DonHangs { get; set; }
        public DbSet<DonHangChiTiet> DonHangChiTiets { get; set; }
        #endregion
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DonHang>(e =>
            {
                e.ToTable("DonHang");
                e.HasKey(dh => dh.MaDh);
                e.Property(dh => dh.NgayDat).HasDefaultValue(DateTime.Now);
            }
            );

            modelBuilder.Entity<DonHangChiTiet>(en =>
            {
                en.ToTable("DonHangChiTiet");
                en.HasKey(e => new { e.MaDh, e.MaHh });

                en.HasOne(e => e.HangHoa)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaHh)
                .HasConstraintName("FK_DonHangChiTiet_HangHoa");

                en.HasOne(e => e.DonHang)
                .WithMany(e => e.DonHangChiTiets)
                .HasForeignKey(e => e.MaDh)
                .HasConstraintName("FK_DonHangChiTiet_DonHang");
            });
        }
    }
}
