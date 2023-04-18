using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoIF.Migrations
{
    /// <inheritdoc />
    public partial class AddAtribuicaoUsuarioToTask : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AtribuicaoUserTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: true),
                    NomeUsuarioAtribuido = table.Column<string>(type: "varchar(100)", nullable: true),
                    TarefaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtribuicaoUserTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AtribuicaoUserTask_Tarefa_TarefaId",
                        column: x => x.TarefaId,
                        principalTable: "Tarefa",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AtribuicaoUserTask_Usuario_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuario",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtribuicaoUserTask_TarefaId",
                table: "AtribuicaoUserTask",
                column: "TarefaId");

            migrationBuilder.CreateIndex(
                name: "IX_AtribuicaoUserTask_UsuarioId",
                table: "AtribuicaoUserTask",
                column: "UsuarioId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtribuicaoUserTask");
        }
    }
}
