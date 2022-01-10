using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negocio.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CategoriaTabla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCategoria = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaTabla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MarcaTabla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreMarca = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarcaTabla", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductoTabla",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    MarcaId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false),
                    Precio = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Imagen = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoTabla", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoTabla_CategoriaTabla_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriaTabla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProductoTabla_MarcaTabla_MarcaId",
                        column: x => x.MarcaId,
                        principalTable: "MarcaTabla",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTabla_CategoriaId",
                table: "ProductoTabla",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTabla_MarcaId",
                table: "ProductoTabla",
                column: "MarcaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductoTabla");

            migrationBuilder.DropTable(
                name: "CategoriaTabla");

            migrationBuilder.DropTable(
                name: "MarcaTabla");
        }
    }
}
