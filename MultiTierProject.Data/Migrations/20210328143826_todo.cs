using Microsoft.EntityFrameworkCore.Migrations;

namespace MultiTierProject.Data.Migrations
{
    public partial class todo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Cities");

            migrationBuilder.DropTable(
                name: "Regions");

            migrationBuilder.CreateTable(
                name: "Task",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Task", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 1, "First Task", true });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 2, "Second Task", true });

            migrationBuilder.InsertData(
                table: "Task",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[] { 3, "Third Task", true });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Task");

            migrationBuilder.CreateTable(
                name: "Regions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Regions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Cities",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    RegionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cities", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cities_Regions_RegionId",
                        column: x => x.RegionId,
                        principalTable: "Regions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 1, false, "Marmara" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 2, false, "Ege" });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "IsDeleted", "Name" },
                values: new object[] { 3, false, "İç Anadolu" });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsDeleted", "Name", "RegionId" },
                values: new object[] { 1, false, "İstanbul", 1 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsDeleted", "Name", "RegionId" },
                values: new object[] { 2, false, "İzmir", 2 });

            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "Id", "IsDeleted", "Name", "RegionId" },
                values: new object[] { 3, false, "Ankara", 3 });

            migrationBuilder.CreateIndex(
                name: "IX_Cities_RegionId",
                table: "Cities",
                column: "RegionId");
        }
    }
}
