using Microsoft.EntityFrameworkCore.Migrations;

namespace RepositoryLayer.Migrations
{
    public partial class PayrollMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmployeeFormTable",
                columns: table => new
                {
                    ID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    Department = table.Column<string>(nullable: true),
                    Salary = table.Column<long>(nullable: false),
                    Notes = table.Column<string>(nullable: true),
                    EmployeeId = table.Column<long>(nullable: false),
                    UserEmployeeId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeFormTable", x => x.ID);
                    table.ForeignKey(
                        name: "FK_EmployeeFormTable_userTable_UserEmployeeId",
                        column: x => x.UserEmployeeId,
                        principalTable: "userTable",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeFormTable_UserEmployeeId",
                table: "EmployeeFormTable",
                column: "UserEmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeFormTable");
        }
    }
}
