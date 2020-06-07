using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SkillTestAPI.Migrations
{
    public partial class initialcommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Contact",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FIRSTNAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    SURNAME = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    TEL = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    CELL = table.Column<string>(unicode: false, maxLength: 25, nullable: true),
                    Email = table.Column<string>(nullable: true),
                    UPDATEDDATE = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contact", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Contact");
        }
    }
}
