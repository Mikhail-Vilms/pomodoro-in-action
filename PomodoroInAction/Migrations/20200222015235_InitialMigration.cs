using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace PomodoroInAction.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "board",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    display_name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    sort_order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_board", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "container",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    display_name = table.Column<string>(nullable: false),
                    sort_order = table.Column<int>(nullable: false),
                    board_id = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_container", x => x.id);
                    table.ForeignKey(
                        name: "FK_container_board_board_id",
                        column: x => x.board_id,
                        principalTable: "board",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ticket",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    display_name = table.Column<string>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    container_id = table.Column<int>(nullable: false),
                    sort_order = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ticket", x => x.id);
                    table.ForeignKey(
                        name: "FK_ticket_container_container_id",
                        column: x => x.container_id,
                        principalTable: "container",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_container_board_id",
                table: "container",
                column: "board_id");

            migrationBuilder.CreateIndex(
                name: "IX_ticket_container_id",
                table: "ticket",
                column: "container_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ticket");

            migrationBuilder.DropTable(
                name: "container");

            migrationBuilder.DropTable(
                name: "board");
        }
    }
}
