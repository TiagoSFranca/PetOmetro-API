using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetOmetro.Persistence.Migrations
{
    public partial class Sexta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_Usuario_IdUsuario",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_PetUsuario_Usuario_IdUsuario",
                table: "PetUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoPet_Usuario_IdUsuarioSolicitado",
                table: "SolicitacaoPet");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoPet_Usuario_IdUsuarioSolicitante",
                table: "SolicitacaoPet");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "Nome",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_AspNetUsers_IdUsuario",
                table: "Pet",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetUsuario_AspNetUsers_IdUsuario",
                table: "PetUsuario",
                column: "IdUsuario",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoPet_AspNetUsers_IdUsuarioSolicitado",
                table: "SolicitacaoPet",
                column: "IdUsuarioSolicitado",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoPet_AspNetUsers_IdUsuarioSolicitante",
                table: "SolicitacaoPet",
                column: "IdUsuarioSolicitante",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pet_AspNetUsers_IdUsuario",
                table: "Pet");

            migrationBuilder.DropForeignKey(
                name: "FK_PetUsuario_AspNetUsers_IdUsuario",
                table: "PetUsuario");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoPet_AspNetUsers_IdUsuarioSolicitado",
                table: "SolicitacaoPet");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitacaoPet_AspNetUsers_IdUsuarioSolicitante",
                table: "SolicitacaoPet");

            migrationBuilder.DropColumn(
                name: "Nome",
                table: "AspNetUsers");

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Email = table.Column<string>(maxLength: 256, nullable: false),
                    Login = table.Column<string>(maxLength: 64, nullable: false),
                    Nome = table.Column<string>(maxLength: 32, nullable: false),
                    Senha = table.Column<string>(maxLength: 256, nullable: false),
                    Sobrenome = table.Column<string>(maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Pet_Usuario_IdUsuario",
                table: "Pet",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PetUsuario_Usuario_IdUsuario",
                table: "PetUsuario",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoPet_Usuario_IdUsuarioSolicitado",
                table: "SolicitacaoPet",
                column: "IdUsuarioSolicitado",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitacaoPet_Usuario_IdUsuarioSolicitante",
                table: "SolicitacaoPet",
                column: "IdUsuarioSolicitante",
                principalTable: "Usuario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
