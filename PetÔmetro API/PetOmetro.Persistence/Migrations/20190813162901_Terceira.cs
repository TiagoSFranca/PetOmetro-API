using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PetOmetro.Persistence.Migrations
{
    public partial class Terceira : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitacaoAssociacaoPet");

            migrationBuilder.CreateTable(
                name: "SolicitacaoPet",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    IdUsuarioSolicitante = table.Column<int>(nullable: false),
                    IdUsuarioSolicitado = table.Column<int>(nullable: false),
                    IdPet = table.Column<int>(nullable: false),
                    IdSituacaoSolicitacao = table.Column<int>(nullable: false),
                    Visualizado = table.Column<bool>(nullable: false),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    DataFinalizacao = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoPet", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitacaoPet_Pet_IdPet",
                        column: x => x.IdPet,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoPet_SituacaoSolicitacaoPet_IdSituacaoSolicitacao",
                        column: x => x.IdSituacaoSolicitacao,
                        principalTable: "SituacaoSolicitacaoPet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoPet_Usuario_IdUsuarioSolicitado",
                        column: x => x.IdUsuarioSolicitado,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacaoPet_Usuario_IdUsuarioSolicitante",
                        column: x => x.IdUsuarioSolicitante,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoPet_IdPet",
                table: "SolicitacaoPet",
                column: "IdPet");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoPet_IdSituacaoSolicitacao",
                table: "SolicitacaoPet",
                column: "IdSituacaoSolicitacao");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoPet_IdUsuarioSolicitado",
                table: "SolicitacaoPet",
                column: "IdUsuarioSolicitado");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoPet_IdUsuarioSolicitante",
                table: "SolicitacaoPet",
                column: "IdUsuarioSolicitante");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SolicitacaoPet");

            migrationBuilder.CreateTable(
                name: "SolicitacaoAssociacaoPet",
                columns: table => new
                {
                    IdSolicitacaoAssociacaoPet = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DataFinalizacao = table.Column<DateTime>(nullable: true),
                    DataSolicitacao = table.Column<DateTime>(nullable: false),
                    IdPet = table.Column<int>(nullable: false),
                    IdSituacaoSolicitacao = table.Column<int>(nullable: false),
                    IdUsuarioSolicitado = table.Column<int>(nullable: false),
                    IdUsuarioSolicitante = table.Column<int>(nullable: false),
                    Visualizado = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitacaoAssociacaoPet", x => x.IdSolicitacaoAssociacaoPet);
                    table.ForeignKey(
                        name: "FK_SolicitacaoAssociacaoPet_Pet_IdPet",
                        column: x => x.IdPet,
                        principalTable: "Pet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoAssociacaoPet_SituacaoSolicitacaoPet_IdSituacaoSolicitacao",
                        column: x => x.IdSituacaoSolicitacao,
                        principalTable: "SituacaoSolicitacaoPet",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitacaoAssociacaoPet_Usuario_IdUsuarioSolicitado",
                        column: x => x.IdUsuarioSolicitado,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SolicitacaoAssociacaoPet_Usuario_IdUsuarioSolicitante",
                        column: x => x.IdUsuarioSolicitante,
                        principalTable: "Usuario",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoAssociacaoPet_IdPet",
                table: "SolicitacaoAssociacaoPet",
                column: "IdPet");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoAssociacaoPet_IdSituacaoSolicitacao",
                table: "SolicitacaoAssociacaoPet",
                column: "IdSituacaoSolicitacao");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoAssociacaoPet_IdUsuarioSolicitado",
                table: "SolicitacaoAssociacaoPet",
                column: "IdUsuarioSolicitado");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitacaoAssociacaoPet_IdUsuarioSolicitante",
                table: "SolicitacaoAssociacaoPet",
                column: "IdUsuarioSolicitante");
        }
    }
}
