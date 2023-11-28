using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    /// <inheritdoc />
    public partial class InitialDB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserPassword = table.Column<string>(type: "Nvarchar(500)", nullable: false),
                    UserLastLogin = table.Column<DateTime>(type: "date", nullable: false),
                    UserLastLoginIpAddress = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    IsAdmin = table.Column<bool>(type: "bit", nullable: false),
                    UserSalt = table.Column<string>(type: "Nvarchar(100)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_UserId", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginUser");
        }
    }
}
