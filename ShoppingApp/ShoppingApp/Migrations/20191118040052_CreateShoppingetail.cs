using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ShoppingApp.Migrations
{
    public partial class CreateShoppingetail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductDetail",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductName = table.Column<string>(nullable: false),
                    ProductCode = table.Column<string>(nullable: false),
                    Manufacturer = table.Column<string>(nullable: false),
                    ShippingNo = table.Column<string>(nullable: false),
                    SerialNo = table.Column<int>(nullable: false),
                    BatchNo = table.Column<string>(nullable: false),
                    MRP = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    LastModifiedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductDetail", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductDetail");
        }
    }
}
