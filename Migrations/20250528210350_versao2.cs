﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Modulum.Api.Migrations
{
    /// <inheritdoc />
    public partial class versao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "tbl_projeto",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Versao = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_projeto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RefreshToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cpf = table.Column<string>(type: "varchar(14)", unicode: false, maxLength: 14, nullable: true),
                    RefreshTokenExpiryTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCadastroFinalizado = table.Column<bool>(type: "bit", nullable: true, defaultValue: true),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tbl_versao",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Pacote = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RequestedVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResolvedVersion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Framework = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjetoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_versao", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_versao_tbl_projeto_ProjetoId",
                        column: x => x.ProjetoId,
                        principalSchema: "dbo",
                        principalTable: "tbl_projeto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_role_claim",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_role_claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_role_claim_tbl_role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "tbl_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_table",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeTabela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeTela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CampoPK = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IdUsuario = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_table", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_table_tbl_user_IdUsuario",
                        column: x => x.IdUsuario,
                        principalSchema: "dbo",
                        principalTable: "tbl_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_two_factor",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdUser = table.Column<int>(type: "int", nullable: false),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsUsed = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_two_factor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_two_factor_tbl_user_IdUser",
                        column: x => x.IdUser,
                        principalSchema: "dbo",
                        principalTable: "tbl_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_claim",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_claim", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_user_claim_tbl_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_login",
                schema: "dbo",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_login", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_tbl_user_login_tbl_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_role",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_role", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_tbl_user_role_tbl_role_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "dbo",
                        principalTable: "tbl_role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tbl_user_role_tbl_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_user_token",
                schema: "dbo",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_user_token", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_tbl_user_token_tbl_user_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "tbl_user",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_field",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCampoBase = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NomeCampoTela = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tamanho = table.Column<int>(type: "int", nullable: true),
                    IsPrimaryKey = table.Column<bool>(type: "bit", nullable: false),
                    IsForeigeKey = table.Column<bool>(type: "bit", nullable: false),
                    IsObrigatorio = table.Column<bool>(type: "bit", nullable: false),
                    TableId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_field", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_field_tbl_table_TableId",
                        column: x => x.TableId,
                        principalSchema: "dbo",
                        principalTable: "tbl_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tbl_relationship",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TabelaOrigemId = table.Column<int>(type: "int", nullable: false),
                    TabelaDestinoId = table.Column<int>(type: "int", nullable: false),
                    CampoOrigem = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CampoDestino = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NomeConstraint = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsObrigatorio = table.Column<bool>(type: "bit", nullable: false),
                    CampoParaExibicaoRelacionamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tbl_relationship", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tbl_relationship_tbl_table_TabelaDestinoId",
                        column: x => x.TabelaDestinoId,
                        principalSchema: "dbo",
                        principalTable: "tbl_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_tbl_relationship_tbl_table_TabelaOrigemId",
                        column: x => x.TabelaOrigemId,
                        principalSchema: "dbo",
                        principalTable: "tbl_table",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tbl_field_TableId",
                schema: "dbo",
                table: "tbl_field",
                column: "TableId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_relationship_TabelaDestinoId",
                schema: "dbo",
                table: "tbl_relationship",
                column: "TabelaDestinoId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_relationship_TabelaOrigemId",
                schema: "dbo",
                table: "tbl_relationship",
                column: "TabelaOrigemId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                schema: "dbo",
                table: "tbl_role",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_role_claim_RoleId",
                schema: "dbo",
                table: "tbl_role_claim",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_table_IdUsuario",
                schema: "dbo",
                table: "tbl_table",
                column: "IdUsuario");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_two_factor_IdUser",
                schema: "dbo",
                table: "tbl_two_factor",
                column: "IdUser");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                schema: "dbo",
                table: "tbl_user",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                schema: "dbo",
                table: "tbl_user",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_claim_UserId",
                schema: "dbo",
                table: "tbl_user_claim",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_login_UserId",
                schema: "dbo",
                table: "tbl_user_login",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_user_role_RoleId",
                schema: "dbo",
                table: "tbl_user_role",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_tbl_versao_ProjetoId",
                schema: "dbo",
                table: "tbl_versao",
                column: "ProjetoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tbl_field",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_relationship",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_role_claim",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_two_factor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_user_claim",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_user_login",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_user_role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_user_token",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_versao",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_table",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_role",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_projeto",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "tbl_user",
                schema: "dbo");
        }
    }
}
