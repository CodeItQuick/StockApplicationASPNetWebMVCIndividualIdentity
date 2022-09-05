#nullable disable

using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace StockApplicationASPNetWebMVCIndividualIdentity.Data.Migrations
{
    public partial class CreateShortlistTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Shortlist",
                columns: table => new {
                    Id = table.Column<long>().Annotation("SqlServer:ValueGenerationStrategy", 
                        SqlServerValueGenerationStrategy.IdentityColumn),
                    symbol = table.Column<string>(nullable: true),
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shortlist_ids", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Shortlist");
        }
    }
}
