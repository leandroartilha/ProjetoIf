using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoIF.Migrations
{
    /// <inheritdoc />
    public partial class AddAtribuicaoUsuarioToProject : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtribuicaoUserProject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    NomeUsuarioAtribuido = table.Column<string>(type: "varchar(100)", nullable: true),
                    ProjetoId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtribuicaoUserProject", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtribuicaoUserProject_Projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalTable: "Projeto",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AtribuicaoUserProject_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtribuicaoUserProject_ProjetoId",
                table: "AtribuicaoUserProject",
                column: "ProjetoId");

            migrationBuilder.CreateIndex(
                name: "IX_AtribuicaoUserProject_UsuarioId",
                table: "AtribuicaoUserProject",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtribuicaoUserProject");
        }
    }
}
