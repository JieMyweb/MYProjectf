using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project2.Migrations
{
    /// <inheritdoc />
    public partial class First : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tMember",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fPwd = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tMember", x => x.fId);
                });

            migrationBuilder.CreateTable(
                name: "tOrder",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fOrderGuid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fReceiver = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fEmail = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fAddress = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fDate = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tOrder", x => x.fId);
                });

            migrationBuilder.CreateTable(
                name: "tOrderDetail",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fOrderGuid = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fUserId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fPId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fPrice = table.Column<int>(type: "int", nullable: true),
                    fQty = table.Column<int>(type: "int", nullable: true),
                    fIsApproved = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tOrderDetail", x => x.fId);
                });

            migrationBuilder.CreateTable(
                name: "tProduct",
                columns: table => new
                {
                    fId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fPId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    fPrice = table.Column<int>(type: "int", nullable: true),
                    fImg = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tProduct", x => x.fId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tMember");

            migrationBuilder.DropTable(
                name: "tOrder");

            migrationBuilder.DropTable(
                name: "tOrderDetail");

            migrationBuilder.DropTable(
                name: "tProduct");
        }
    }
}
