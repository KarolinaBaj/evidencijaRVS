using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Evidencija.DAL.Migrations
{
    /// <inheritdoc />
    public partial class inicijalnaMigracija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "anamneza",
                columns: table => new
                {
                    anamneza_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    zivotinja_id = table.Column<int>(type: "int", nullable: false),
                    Razlogdolaska = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ishrana = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Urinistolica = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Smestaj = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    Primaolekove = table.Column<bool>(type: "bit", nullable: false),
                    kojelekove = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    ranijebolovala = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    datumunosa = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_anamneza", x => x.anamneza_id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnik",
                columns: table => new
                {
                    korisnik_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    prezime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    lozinka = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    adresa = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnik", x => x.korisnik_id);
                });

            migrationBuilder.CreateTable(
                name: "lek",
                columns: table => new
                {
                    lek_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nazivleka = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    opis = table.Column<string>(type: "nvarchar(max)", maxLength: 2147483647, nullable: false),
                    doza = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lek", x => x.lek_id);
                });

            migrationBuilder.CreateTable(
                name: "pregled",
                columns: table => new
                {
                    pregled_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    anamneza_id = table.Column<int>(type: "int", nullable: false),
                    telesna_temperatura = table.Column<decimal>(type: "decimal(4,1)", precision: 4, scale: 1, nullable: false),
                    dijagnoza = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    terapija = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    hitanslucaj = table.Column<bool>(type: "bit", nullable: false),
                    prioritetpregleda = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    datumpregleda = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_pregled", x => x.pregled_id);
                });

            migrationBuilder.CreateTable(
                name: "terapija",
                columns: table => new
                {
                    terapija_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    pregled_id = table.Column<int>(type: "int", nullable: false),
                    lek_id = table.Column<int>(type: "int", nullable: false),
                    kolicina = table.Column<int>(type: "int", nullable: false),
                    napomena = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_terapija", x => x.terapija_id);
                });

            migrationBuilder.CreateTable(
                name: "zivotinje",
                columns: table => new
                {
                    zivotinja_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    korisnik_id = table.Column<int>(type: "int", nullable: false),
                    ime = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    vrsta = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    starost = table.Column<int>(type: "int", nullable: false),
                    pol = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    status = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    namena = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zivotinje", x => x.zivotinja_id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "anamneza");

            migrationBuilder.DropTable(
                name: "Korisnik");

            migrationBuilder.DropTable(
                name: "lek");

            migrationBuilder.DropTable(
                name: "pregled");

            migrationBuilder.DropTable(
                name: "terapija");

            migrationBuilder.DropTable(
                name: "zivotinje");
        }
    }
}
