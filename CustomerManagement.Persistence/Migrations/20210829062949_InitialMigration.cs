using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CustomerManagement.Persistence.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customer",
                columns: table => new
                {
                    CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedBy = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customer", x => x.CustomerId);
                });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "LastName", "ModifiedBy", "ModifiedDate" },
                values: new object[] { new Guid("d96a0111-06f3-464c-bf1e-638a5801b749"), null, null, new DateTime(1986, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Agraj", "Nema", null, null });

            migrationBuilder.InsertData(
                table: "Customer",
                columns: new[] { "CustomerId", "CreatedBy", "CreatedDate", "DateOfBirth", "FirstName", "LastName", "ModifiedBy", "ModifiedDate" },
                values: new object[] { new Guid("de01cefb-6e0a-4cd0-80a7-3da849214c88"), null, null, new DateTime(1990, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Paul", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Customer");
        }
    }
}
