using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Negocio.Migrations
{
    public partial class inicial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Marca",
                table: "ProductoTabla",
                newName: "MarcaId");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "ProductoTabla",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "ProductoTabla",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "ProductoTabla",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "CategoriaId",
                table: "ProductoTabla",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Imagen",
                table: "ProductoTabla",
                type: "nvarchar(1000)",
                maxLength: 1000,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTabla_CategoriaId",
                table: "ProductoTabla",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoTabla_MarcaId",
                table: "ProductoTabla",
                column: "MarcaId");

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoTabla_CategoriaTabla_CategoriaId",
                table: "ProductoTabla",
                column: "CategoriaId",
                principalTable: "CategoriaTabla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ProductoTabla_MarcaTabla_MarcaId",
                table: "ProductoTabla",
                column: "MarcaId",
                principalTable: "MarcaTabla",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProductoTabla_CategoriaTabla_CategoriaId",
                table: "ProductoTabla");

            migrationBuilder.DropForeignKey(
                name: "FK_ProductoTabla_MarcaTabla_MarcaId",
                table: "ProductoTabla");

            migrationBuilder.DropTable(
                name: "CategoriaTabla");

            migrationBuilder.DropTable(
                name: "MarcaTabla");

            migrationBuilder.DropIndex(
                name: "IX_ProductoTabla_CategoriaId",
                table: "ProductoTabla");

            migrationBuilder.DropIndex(
                name: "IX_ProductoTabla_MarcaId",
                table: "ProductoTabla");

            migrationBuilder.DropColumn(
                name: "CategoriaId",
                table: "ProductoTabla");

            migrationBuilder.DropColumn(
                name: "Imagen",
                table: "ProductoTabla");

            migrationBuilder.RenameColumn(
                name: "MarcaId",
                table: "ProductoTabla",
                newName: "Marca");

            migrationBuilder.AlterColumn<decimal>(
                name: "Precio",
                table: "ProductoTabla",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");

            migrationBuilder.AlterColumn<string>(
                name: "Nombre",
                table: "ProductoTabla",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(250)",
                oldMaxLength: 250);

            migrationBuilder.AlterColumn<string>(
                name: "Descripcion",
                table: "ProductoTabla",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);
        }
    }
}
