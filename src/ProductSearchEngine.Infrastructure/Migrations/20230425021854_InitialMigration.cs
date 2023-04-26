using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ProductSearchEngine.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tCategory",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tCategory", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tSite",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "TEXT", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tSite", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tProduct",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    description = table.Column<string>(type: "TEXT", maxLength: 200, nullable: true),
                    price = table.Column<string>(type: "TEXT", maxLength: 50, nullable: true),
                    img = table.Column<string>(type: "TEXT", maxLength: 300, nullable: true),
                    CategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tProduct", x => x.id);
                    table.ForeignKey(
                        name: "FK_tProduct_tCategory_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "tCategory",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SearchProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    SiteId = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SearchProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SearchProducts_tProduct_ProductId",
                        column: x => x.ProductId,
                        principalTable: "tProduct",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SearchProducts_tSite_SiteId",
                        column: x => x.SiteId,
                        principalTable: "tSite",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "tCategory",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Mobile" },
                    { 2, "Refrigerator" },
                    { 3, "Tv" }
                });

            migrationBuilder.InsertData(
                table: "tSite",
                columns: new[] { "id", "name" },
                values: new object[,]
                {
                    { 1, "Mercado Livre" },
                    { 2, "Buscapé" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_SearchProducts_ProductId",
                table: "SearchProducts",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_SearchProducts_SiteId",
                table: "SearchProducts",
                column: "SiteId");

            migrationBuilder.CreateIndex(
                name: "IX_tProduct_CategoryId",
                table: "tProduct",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SearchProducts");

            migrationBuilder.DropTable(
                name: "tProduct");

            migrationBuilder.DropTable(
                name: "tSite");

            migrationBuilder.DropTable(
                name: "tCategory");
        }
    }
}
