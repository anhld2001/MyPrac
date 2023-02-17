using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prac1.Migrations
{
    public partial class AddDonHangSchema : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DonHang",
                columns: table => new
                {
                    MaDh = table.Column<Guid>(type: "char(36)", nullable: false),
                    NgayDat = table.Column<DateTime>(type: "datetime(6)", nullable: false, defaultValue: new DateTime(2023, 2, 9, 10, 49, 41, 0, DateTimeKind.Unspecified)),
                    NgayGiao = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    TinhTrangDonHang = table.Column<int>(type: "int", nullable: false),
                    NguoiNhan = table.Column<string>(type: "longtext", nullable: false),
                    DiaChi = table.Column<string>(type: "longtext", nullable: false),
                    SDT = table.Column<string>(type: "longtext", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHang", x => x.MaDh);
                });

            migrationBuilder.CreateTable(
                name: "DonHangChiTiet",
                columns: table => new
                {
                    MaHh = table.Column<Guid>(type: "char(36)", nullable: false),
                    MaDh = table.Column<Guid>(type: "char(36)", nullable: false),
                    SoLuong = table.Column<int>(type: "int", nullable: false),
                    DonGia = table.Column<double>(type: "double", nullable: false),
                    GiamGia = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DonHangChiTiet", x => new { x.MaDh, x.MaHh });
                    table.ForeignKey(
                        name: "FK_DonHangChiTiet_DonHang",
                        column: x => x.MaDh,
                        principalTable: "DonHang",
                        principalColumn: "MaDh",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DonHangChiTiet_HangHoa",
                        column: x => x.MaHh,
                        principalTable: "HangHoa",
                        principalColumn: "MaHh",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DonHangChiTiet_MaHh",
                table: "DonHangChiTiet",
                column: "MaHh");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DonHangChiTiet");

            migrationBuilder.DropTable(
                name: "DonHang");
        }
    }
}
