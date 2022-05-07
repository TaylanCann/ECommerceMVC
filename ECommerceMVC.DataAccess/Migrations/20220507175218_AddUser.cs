using Microsoft.EntityFrameworkCore.Migrations;

namespace ECommerceMVC.DataAccess.Migrations
{
    public partial class AddUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EMail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EMail", "FullName", "Password", "Role", "UserName" },
                values: new object[] { 1, "taylancanh@gmail.com", "Taylan Can Hardal", "123", "Admin", "T" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EMail", "FullName", "Password", "Role", "UserName" },
                values: new object[] { 2, "editorcanh2@gmail.com", "Editör Can Hardal2", "123", "Editor", "T2" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "EMail", "FullName", "Password", "Role", "UserName" },
                values: new object[] { 3, "clientcanh3@gmail.com", "Client Can Hardal3", "123", "Client", "T3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
