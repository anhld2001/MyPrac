using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Prac1.Migrations
{
    public partial class DbInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HangHoa",
                columns: table => new
                {
                    MaHh = table.Column<Guid>(type: "char(36)", nullable: false),
                    TenHh = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    MoTa = table.Column<string>(type: "longtext", nullable: false),
                    DonGia = table.Column<double>(type: "double", nullable: false),
                    GiamGia = table.Column<byte>(type: "tinyint unsigned", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HangHoa", x => x.MaHh);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HangHoa");
        }
    }
}
