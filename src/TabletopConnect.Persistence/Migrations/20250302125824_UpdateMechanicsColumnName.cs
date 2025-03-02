using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabletopConnect.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMechanicsColumnName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameMechanics_Mechanics_MechanicId",
                table: "BoardGameMechanics");

            migrationBuilder.RenameColumn(
                name: "MechanicId",
                table: "BoardGameMechanics",
                newName: "MechanicsId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGameMechanics_MechanicId",
                table: "BoardGameMechanics",
                newName: "IX_BoardGameMechanics_MechanicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameMechanics_Mechanics_MechanicsId",
                table: "BoardGameMechanics",
                column: "MechanicsId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BoardGameMechanics_Mechanics_MechanicsId",
                table: "BoardGameMechanics");

            migrationBuilder.RenameColumn(
                name: "MechanicsId",
                table: "BoardGameMechanics",
                newName: "MechanicId");

            migrationBuilder.RenameIndex(
                name: "IX_BoardGameMechanics_MechanicsId",
                table: "BoardGameMechanics",
                newName: "IX_BoardGameMechanics_MechanicId");

            migrationBuilder.AddForeignKey(
                name: "FK_BoardGameMechanics_Mechanics_MechanicId",
                table: "BoardGameMechanics",
                column: "MechanicId",
                principalTable: "Mechanics",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
