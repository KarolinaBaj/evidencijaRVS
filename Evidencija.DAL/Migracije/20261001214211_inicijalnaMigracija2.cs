using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evidencija.DAL.Migrations
{
    /// <inheritdoc />
    public partial class inicijalnaMigracija2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "kolicina",
                table: "terapija",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_terapija_lek_id",
                table: "terapija",
                column: "lek_id");

            migrationBuilder.CreateIndex(
                name: "IX_terapija_pregled_id",
                table: "terapija",
                column: "pregled_id");

            migrationBuilder.CreateIndex(
                name: "IX_pregled_anamneza_id",
                table: "pregled",
                column: "anamneza_id");

            migrationBuilder.CreateIndex(
                name: "IX_anamneza_zivotinja_id",
                table: "anamneza",
                column: "zivotinja_id");

            migrationBuilder.AddForeignKey(
                name: "FK_anamneza_zivotinje_zivotinja_id",
                table: "anamneza",
                column: "zivotinja_id",
                principalTable: "zivotinje",
                principalColumn: "zivotinja_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_pregled_anamneza_anamneza_id",
                table: "pregled",
                column: "anamneza_id",
                principalTable: "anamneza",
                principalColumn: "anamneza_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_terapija_lek_lek_id",
                table: "terapija",
                column: "lek_id",
                principalTable: "lek",
                principalColumn: "lek_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_terapija_pregled_pregled_id",
                table: "terapija",
                column: "pregled_id",
                principalTable: "pregled",
                principalColumn: "pregled_id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_anamneza_zivotinje_zivotinja_id",
                table: "anamneza");

            migrationBuilder.DropForeignKey(
                name: "FK_pregled_anamneza_anamneza_id",
                table: "pregled");

            migrationBuilder.DropForeignKey(
                name: "FK_terapija_lek_lek_id",
                table: "terapija");

            migrationBuilder.DropForeignKey(
                name: "FK_terapija_pregled_pregled_id",
                table: "terapija");

            migrationBuilder.DropIndex(
                name: "IX_terapija_lek_id",
                table: "terapija");

            migrationBuilder.DropIndex(
                name: "IX_terapija_pregled_id",
                table: "terapija");

            migrationBuilder.DropIndex(
                name: "IX_pregled_anamneza_id",
                table: "pregled");

            migrationBuilder.DropIndex(
                name: "IX_anamneza_zivotinja_id",
                table: "anamneza");

            migrationBuilder.AlterColumn<int>(
                name: "kolicina",
                table: "terapija",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
