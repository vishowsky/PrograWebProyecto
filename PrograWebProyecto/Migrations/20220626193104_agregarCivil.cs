using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PrograWebProyecto.Migrations
{
    public partial class agregarCivil : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Password",
                table: "tblUser",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CivilId",
                table: "tblUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "IdCivil",
                table: "tblUser",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "tblCivil",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCivil", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblUser_CivilId",
                table: "tblUser",
                column: "CivilId");

            migrationBuilder.AddForeignKey(
                name: "FK_tblUser_tblCivil_CivilId",
                table: "tblUser",
                column: "CivilId",
                principalTable: "tblCivil",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblUser_tblCivil_CivilId",
                table: "tblUser");

            migrationBuilder.DropTable(
                name: "tblCivil");

            migrationBuilder.DropIndex(
                name: "IX_tblUser_CivilId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "CivilId",
                table: "tblUser");

            migrationBuilder.DropColumn(
                name: "IdCivil",
                table: "tblUser");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "tblUser",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
