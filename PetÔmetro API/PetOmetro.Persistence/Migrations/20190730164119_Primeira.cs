using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetOmetro.Persistence.Migrations
{
    public partial class Primeira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GeneroPet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Nome = table.Column<string>(maxLength: 32, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneroPet", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 32, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 64, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    Login = table.Column<string>(maxLength: 64, nullable: false),
                    Senha = table.Column<string>(maxLength: 256, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(maxLength: 64, nullable: false),
                    Especie = table.Column<string>(maxLength: 64, nullable: true),
                    Raca = table.Column<string>(maxLength: 64, nullable: true),
                    DtNascimento = table.Column<DateTime>(nullable: true),
                    Comentário = table.Column<string>(maxLength: 512, nullable: true),
                    UrlImagem = table.Column<string>(maxLength: 256, nullable: true),
                    IdGeneroPet = table.Column<int>(nullable: false),
                    IdUsuario = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pet_GeneroPet_IdGeneroPet",
                        column: x => x.IdGeneroPet,
                        principalTable: "GeneroPet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pet_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PetUsuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuario = table.Column<int>(nullable: false),
                    IdPet = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetUsuario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PetUsuario_Pet_IdPet",
                        column: x => x.IdPet,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_PetUsuario_Usuario_IdUsuario",
                        column: x => x.IdUsuario,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdGeneroPet",
                table: "Pet",
                column: "IdGeneroPet");

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdUsuario",
                table: "Pet",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_PetUsuario_IdPet",
                table: "PetUsuario",
                column: "IdPet");

            migrationBuilder.CreateIndex(
                name: "IX_PetUsuario_IdUsuario",
                table: "PetUsuario",
                column: "IdUsuario");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetUsuario");

            migrationBuilder.DropTable(
                name: "Pet");

            migrationBuilder.DropTable(
                name: "GeneroPet");

            migrationBuilder.DropTable(
                name: "Usuario");
        }
    }
}
