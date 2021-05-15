using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShopping.Migrations
{
    public partial class DBInit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Dil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ad = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dil", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Firma",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ulke = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    website = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Firma", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Platform",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Platform", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Tag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ad = table.Column<string>(type: "varchar(30)", maxLength: 30, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tag", x => x.id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Oyun",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ad = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    cikis_tarihi = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    fiyat = table.Column<int>(type: "int", nullable: false),
                    firma_id = table.Column<int>(type: "int", nullable: false),
                    platform_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oyun", x => x.id);
                    table.ForeignKey(
                        name: "FK_Oyun_Firma_firma_id",
                        column: x => x.firma_id,
                        principalTable: "Firma",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Oyun_Platform_platform_id",
                        column: x => x.platform_id,
                        principalTable: "Platform",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OyunDil",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    oyun_id = table.Column<int>(type: "int", nullable: false),
                    dil_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OyunDil", x => x.id);
                    table.ForeignKey(
                        name: "FK_OyunDil_Oyun_oyun_id",
                        column: x => x.oyun_id,
                        principalTable: "Oyun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OyunDil_Tag_dil_id",
                        column: x => x.dil_id,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "OyunTag",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    oyun_id = table.Column<int>(type: "int", nullable: false),
                    tag_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OyunTag", x => x.id);
                    table.ForeignKey(
                        name: "FK_OyunTag_Oyun_oyun_id",
                        column: x => x.oyun_id,
                        principalTable: "Oyun",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OyunTag_Tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "Tag",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Dil",
                columns: new[] { "id", "ad" },
                values: new object[,]
                {
                    { 1, "Türkçe" },
                    { 2, "French" },
                    { 3, "Japonca" },
                    { 4, "Lazca" }
                });

            migrationBuilder.InsertData(
                table: "Firma",
                columns: new[] { "id", "ad", "ulke", "website" },
                values: new object[,]
                {
                    { 1, "Ubisoft", "Azerbaycan", "www.cum.zone" },
                    { 2, "Erzurum Game Studios", "Türkiye", "www.erzu.rum" },
                    { 3, "Rockstar", "Erzincan", "www.rock.star" }
                });

            migrationBuilder.InsertData(
                table: "Platform",
                columns: new[] { "id", "ad" },
                values: new object[,]
                {
                    { 1, "Windows" },
                    { 2, "Linux" },
                    { 3, "MacOS" }
                });

            migrationBuilder.InsertData(
                table: "Tag",
                columns: new[] { "id", "ad" },
                values: new object[,]
                {
                    { 1, "Co-Op" },
                    { 2, "Single" },
                    { 3, "Multi" },
                    { 4, "Grind" }
                });

            migrationBuilder.InsertData(
                table: "Oyun",
                columns: new[] { "id", "ad", "cikis_tarihi", "firma_id", "fiyat", "platform_id" },
                values: new object[,]
                {
                    { 1, "Fifa 2021", new DateTime(2021, 5, 15, 2, 48, 52, 650, DateTimeKind.Local).AddTicks(9501), 1, 1, 1 },
                    { 4, "Euro Drug Simulator", new DateTime(2021, 5, 15, 2, 48, 52, 652, DateTimeKind.Local).AddTicks(1183), 1, 85, 1 },
                    { 5, "Football Manager 2023", new DateTime(2021, 5, 15, 2, 48, 52, 652, DateTimeKind.Local).AddTicks(1184), 1, 200, 3 },
                    { 2, "Last Of Us", new DateTime(2021, 5, 15, 2, 48, 52, 652, DateTimeKind.Local).AddTicks(1121), 2, 100, 1 },
                    { 3, "Cyberpunk 2088", new DateTime(2021, 5, 15, 2, 48, 52, 652, DateTimeKind.Local).AddTicks(1180), 3, 55, 2 }
                });

            migrationBuilder.InsertData(
                table: "OyunDil",
                columns: new[] { "id", "dil_id", "oyun_id" },
                values: new object[,]
                {
                    { 1, 2, 1 },
                    { 3, 3, 1 },
                    { 4, 1, 4 },
                    { 2, 3, 2 },
                    { 5, 4, 3 }
                });

            migrationBuilder.InsertData(
                table: "OyunTag",
                columns: new[] { "id", "oyun_id", "tag_id" },
                values: new object[,]
                {
                    { 1, 1, 2 },
                    { 3, 1, 3 },
                    { 4, 4, 1 },
                    { 2, 2, 3 },
                    { 5, 3, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oyun_firma_id",
                table: "Oyun",
                column: "firma_id");

            migrationBuilder.CreateIndex(
                name: "IX_Oyun_platform_id",
                table: "Oyun",
                column: "platform_id");

            migrationBuilder.CreateIndex(
                name: "IX_OyunDil_dil_id",
                table: "OyunDil",
                column: "dil_id");

            migrationBuilder.CreateIndex(
                name: "IX_OyunDil_oyun_id",
                table: "OyunDil",
                column: "oyun_id");

            migrationBuilder.CreateIndex(
                name: "IX_OyunTag_oyun_id",
                table: "OyunTag",
                column: "oyun_id");

            migrationBuilder.CreateIndex(
                name: "IX_OyunTag_tag_id",
                table: "OyunTag",
                column: "tag_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Dil");

            migrationBuilder.DropTable(
                name: "OyunDil");

            migrationBuilder.DropTable(
                name: "OyunTag");

            migrationBuilder.DropTable(
                name: "Oyun");

            migrationBuilder.DropTable(
                name: "Tag");

            migrationBuilder.DropTable(
                name: "Firma");

            migrationBuilder.DropTable(
                name: "Platform");
        }
    }
}
