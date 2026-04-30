using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace PulsGrada.Migrations
{
    /// <inheritdoc />
    public partial class InicijalnaKreacija : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "kategorije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naziv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kategorije", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    korisnicko_ime = table.Column<string>(type: "text", nullable: false),
                    ime = table.Column<string>(type: "text", nullable: false),
                    prezime = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    lozinka = table.Column<string>(type: "text", nullable: false),
                    datum_registracije = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "kvartovi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naziv = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_kvartovi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "organizatori",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    naziv = table.Column<string>(type: "text", nullable: false),
                    opis = table.Column<string>(type: "text", nullable: false),
                    Kontakt_email = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organizatori", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "lokali",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KvartId = table.Column<int>(type: "integer", nullable: false),
                    naziv = table.Column<string>(type: "text", nullable: false),
                    adresa = table.Column<string>(type: "text", nullable: false),
                    lat = table.Column<double>(type: "double precision", nullable: false),
                    lng = table.Column<double>(type: "double precision", nullable: false),
                    radno_vrijeme = table.Column<string>(type: "text", nullable: false),
                    opis = table.Column<string>(type: "text", nullable: false),
                    ima_pusenje = table.Column<bool>(type: "boolean", nullable: false),
                    ima_biljar = table.Column<bool>(type: "boolean", nullable: false),
                    ima_pikado = table.Column<bool>(type: "boolean", nullable: false),
                    url_cjenik = table.Column<string>(type: "text", nullable: false),
                    is_premium = table.Column<bool>(type: "boolean", nullable: false),
                    url_slike = table.Column<string>(type: "text", nullable: false),
                    kategorija_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_lokali", x => x.Id);
                    table.ForeignKey(
                        name: "FK_lokali_kategorije_kategorija_id",
                        column: x => x.kategorija_id,
                        principalTable: "kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_lokali_kvartovi_KvartId",
                        column: x => x.KvartId,
                        principalTable: "kvartovi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dogadaji",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    lokal_id = table.Column<int>(type: "integer", nullable: false),
                    organizator_id = table.Column<int>(type: "integer", nullable: false),
                    kategorija_id = table.Column<int>(type: "integer", nullable: false),
                    naziv = table.Column<string>(type: "text", nullable: false),
                    vrijeme_pocetka = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    opis = table.Column<string>(type: "text", nullable: false),
                    url_slike = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_dogadaji", x => x.Id);
                    table.ForeignKey(
                        name: "FK_dogadaji_kategorije_kategorija_id",
                        column: x => x.kategorija_id,
                        principalTable: "kategorije",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dogadaji_lokali_lokal_id",
                        column: x => x.lokal_id,
                        principalTable: "lokali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_dogadaji_organizatori_organizator_id",
                        column: x => x.organizator_id,
                        principalTable: "organizatori",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "favoriti",
                columns: table => new
                {
                    korisnik_id = table.Column<int>(type: "integer", nullable: false),
                    lokal_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favoriti", x => new { x.korisnik_id, x.lokal_id });
                    table.ForeignKey(
                        name: "FK_favoriti_lokali_lokal_id",
                        column: x => x.lokal_id,
                        principalTable: "lokali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recenzije",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    korisnik_id = table.Column<int>(type: "integer", nullable: false),
                    lokal_id = table.Column<int>(type: "integer", nullable: false),
                    ocjena = table.Column<int>(type: "integer", nullable: false),
                    komentar = table.Column<string>(type: "text", nullable: false),
                    datum_objave = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_recenzije", x => x.Id);
                    table.ForeignKey(
                        name: "FK_recenzije_korisnici_korisnik_id",
                        column: x => x.korisnik_id,
                        principalTable: "korisnici",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_recenzije_lokali_lokal_id",
                        column: x => x.lokal_id,
                        principalTable: "lokali",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_dogadaji_kategorija_id",
                table: "dogadaji",
                column: "kategorija_id");

            migrationBuilder.CreateIndex(
                name: "IX_dogadaji_lokal_id",
                table: "dogadaji",
                column: "lokal_id");

            migrationBuilder.CreateIndex(
                name: "IX_dogadaji_organizator_id",
                table: "dogadaji",
                column: "organizator_id");

            migrationBuilder.CreateIndex(
                name: "IX_favoriti_lokal_id",
                table: "favoriti",
                column: "lokal_id");

            migrationBuilder.CreateIndex(
                name: "IX_lokali_kategorija_id",
                table: "lokali",
                column: "kategorija_id");

            migrationBuilder.CreateIndex(
                name: "IX_lokali_KvartId",
                table: "lokali",
                column: "KvartId");

            migrationBuilder.CreateIndex(
                name: "IX_recenzije_korisnik_id",
                table: "recenzije",
                column: "korisnik_id");

            migrationBuilder.CreateIndex(
                name: "IX_recenzije_lokal_id",
                table: "recenzije",
                column: "lokal_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dogadaji");

            migrationBuilder.DropTable(
                name: "favoriti");

            migrationBuilder.DropTable(
                name: "recenzije");

            migrationBuilder.DropTable(
                name: "organizatori");

            migrationBuilder.DropTable(
                name: "korisnici");

            migrationBuilder.DropTable(
                name: "lokali");

            migrationBuilder.DropTable(
                name: "kategorije");

            migrationBuilder.DropTable(
                name: "kvartovi");
        }
    }
}
