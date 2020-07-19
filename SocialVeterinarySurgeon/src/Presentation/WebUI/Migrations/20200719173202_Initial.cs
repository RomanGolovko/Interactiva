using Microsoft.EntityFrameworkCore.Migrations;

namespace WebUI.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Employees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    MediaInteractivaEmployee = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pets",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Type = table.Column<string>(nullable: true),
                    OwnerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Employees_OwnerId",
                        column: x => x.OwnerId,
                        principalSchema: "dbo",
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "MediaInteractivaEmployee" },
                values: new object[] { 1, "John", "Dou", true });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "MediaInteractivaEmployee" },
                values: new object[] { 2, "Sam", "Horny", false });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Employees",
                columns: new[] { "Id", "FirstName", "LastName", "MediaInteractivaEmployee" },
                values: new object[] { 3, "Splinter", "Teacher", true });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pets",
                columns: new[] { "Id", "Name", "OwnerId", "Type" },
                values: new object[] { 1, "Dick", 1, "duck" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pets",
                columns: new[] { "Id", "Name", "OwnerId", "Type" },
                values: new object[] { 2, "Pussy", 2, "cat" });

            migrationBuilder.InsertData(
                schema: "dbo",
                table: "Pets",
                columns: new[] { "Id", "Name", "OwnerId", "Type" },
                values: new object[] { 3, "Leonardo", 3, "turtle" });

            migrationBuilder.CreateIndex(
                name: "IX_Pets_OwnerId",
                schema: "dbo",
                table: "Pets",
                column: "OwnerId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pets",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Employees",
                schema: "dbo");
        }
    }
}
