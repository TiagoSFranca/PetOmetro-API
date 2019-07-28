using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetOmetro.Persistence.Migrations
{
    public partial class Segunda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    IdGeneroPet = table.Column<int>(nullable: false),
                    Comentário = table.Column<string>(maxLength: 512, nullable: true),
                    UrlImagem = table.Column<string>(maxLength: 256, nullable: true)
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
                });

            migrationBuilder.CreateIndex(
                name: "IX_Pet_IdGeneroPet",
                table: "Pet",
                column: "IdGeneroPet");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pet");
        }
    }
}
