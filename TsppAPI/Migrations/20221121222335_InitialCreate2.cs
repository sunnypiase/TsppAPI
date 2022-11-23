using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TsppAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProductType",
                table: "ProductProductType");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "ProductProductType");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProductType",
                table: "ProductProductType",
                columns: new[] { "ProductsId", "TypesId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductProductType",
                table: "ProductProductType");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "ProductProductType",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductProductType",
                table: "ProductProductType",
                column: "Id");
        }
    }
}
