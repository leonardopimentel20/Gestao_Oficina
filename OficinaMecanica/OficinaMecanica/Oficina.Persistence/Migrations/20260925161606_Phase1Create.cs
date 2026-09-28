using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Oficina.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Phase1Create : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "categoria_produtos",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Ativa = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_produtos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "categoria_servicos",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(500)", maxLength: 500, nullable: true),
                    Ativa = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_categoria_servicos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "fornecedores",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UnidadeId = table.Column<Guid>(type: "uuid", nullable: false),
                    RazaoSocial = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    NomeFantasia = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Cnpj = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_fornecedores_unidades_UnidadeId",
                        column: x => x.UnidadeId,
                        principalSchema: "oficina",
                        principalTable: "unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "funcionarios",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UnidadeId = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Documento = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true),
                    Telefone = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: true),
                    PercentualComissaoPadrao = table.Column<decimal>(type: "numeric(5,2)", precision: 5, scale: 2, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_funcionarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_funcionarios_unidades_UnidadeId",
                        column: x => x.UnidadeId,
                        principalSchema: "oficina",
                        principalTable: "unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "perfis",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "permissoes",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissoes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "produtos",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriaProdutoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    UnidadeMedida = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    PrecoVenda = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    CustoMedio = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    EstoqueMinimo = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produtos_categoria_produtos_CategoriaProdutoId",
                        column: x => x.CategoriaProdutoId,
                        principalSchema: "oficina",
                        principalTable: "categoria_produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "servicos",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    CategoriaServicoId = table.Column<Guid>(type: "uuid", nullable: true),
                    Codigo = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    PrecoPadrao = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: false),
                    CustoPadrao = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_servicos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_servicos_categoria_servicos_CategoriaServicoId",
                        column: x => x.CategoriaServicoId,
                        principalSchema: "oficina",
                        principalTable: "categoria_servicos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UnidadeId = table.Column<Guid>(type: "uuid", nullable: false),
                    FuncionarioId = table.Column<Guid>(type: "uuid", nullable: true),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    SenhaHash = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false),
                    UltimoLoginEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuarios_funcionarios_FuncionarioId",
                        column: x => x.FuncionarioId,
                        principalSchema: "oficina",
                        principalTable: "funcionarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuarios_unidades_UnidadeId",
                        column: x => x.UnidadeId,
                        principalSchema: "oficina",
                        principalTable: "unidades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "perfil_permissoes",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uuid", nullable: false),
                    PermissaoId = table.Column<Guid>(type: "uuid", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_perfil_permissoes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_perfil_permissoes_perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "oficina",
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_perfil_permissoes_permissoes_PermissaoId",
                        column: x => x.PermissaoId,
                        principalSchema: "oficina",
                        principalTable: "permissoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "produto_fornecedores",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutoId = table.Column<Guid>(type: "uuid", nullable: false),
                    FornecedorId = table.Column<Guid>(type: "uuid", nullable: false),
                    CodigoFornecedor = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    PrecoUltimaCompra = table.Column<decimal>(type: "numeric(18,2)", precision: 18, scale: 2, nullable: true),
                    PrazoGarantiaDias = table.Column<int>(type: "integer", nullable: true),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_produto_fornecedores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_produto_fornecedores_fornecedores_FornecedorId",
                        column: x => x.FornecedorId,
                        principalSchema: "oficina",
                        principalTable: "fornecedores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_produto_fornecedores_produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalSchema: "oficina",
                        principalTable: "produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "usuario_perfis",
                schema: "oficina",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uuid", nullable: false),
                    CriadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: false),
                    AtualizadoEm = table.Column<DateTimeOffset>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario_perfis", x => x.Id);
                    table.ForeignKey(
                        name: "FK_usuario_perfis_perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalSchema: "oficina",
                        principalTable: "perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_usuario_perfis_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalSchema: "oficina",
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_fornecedores_UnidadeId",
                schema: "oficina",
                table: "fornecedores",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_funcionarios_UnidadeId",
                schema: "oficina",
                table: "funcionarios",
                column: "UnidadeId");

            migrationBuilder.CreateIndex(
                name: "IX_perfil_permissoes_PerfilId",
                schema: "oficina",
                table: "perfil_permissoes",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_perfil_permissoes_PermissaoId",
                schema: "oficina",
                table: "perfil_permissoes",
                column: "PermissaoId");

            migrationBuilder.CreateIndex(
                name: "IX_permissoes_Codigo",
                schema: "oficina",
                table: "permissoes",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_produto_fornecedores_FornecedorId",
                schema: "oficina",
                table: "produto_fornecedores",
                column: "FornecedorId");

            migrationBuilder.CreateIndex(
                name: "IX_produto_fornecedores_ProdutoId",
                schema: "oficina",
                table: "produto_fornecedores",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_CategoriaProdutoId",
                schema: "oficina",
                table: "produtos",
                column: "CategoriaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_produtos_Codigo",
                schema: "oficina",
                table: "produtos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_servicos_CategoriaServicoId",
                schema: "oficina",
                table: "servicos",
                column: "CategoriaServicoId");

            migrationBuilder.CreateIndex(
                name: "IX_servicos_Codigo",
                schema: "oficina",
                table: "servicos",
                column: "Codigo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfis_PerfilId",
                schema: "oficina",
                table: "usuario_perfis",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_perfis_UsuarioId",
                schema: "oficina",
                table: "usuario_perfis",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_Email",
                schema: "oficina",
                table: "usuarios",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_FuncionarioId",
                schema: "oficina",
                table: "usuarios",
                column: "FuncionarioId");

            migrationBuilder.CreateIndex(
                name: "IX_usuarios_UnidadeId",
                schema: "oficina",
                table: "usuarios",
                column: "UnidadeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "perfil_permissoes",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "produto_fornecedores",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "servicos",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "usuario_perfis",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "permissoes",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "fornecedores",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "produtos",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "categoria_servicos",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "perfis",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "usuarios",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "categoria_produtos",
                schema: "oficina");

            migrationBuilder.DropTable(
                name: "funcionarios",
                schema: "oficina");
        }
    }
}
