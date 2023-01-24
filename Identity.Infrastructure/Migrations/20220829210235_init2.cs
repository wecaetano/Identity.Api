using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Roles_DataSourceId",
                table: "Roles",
                column: "DataSourceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Roles_DataSource_DataSourceId",
                table: "Roles",
                column: "DataSourceId",
                principalTable: "DataSource",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Roles_DataSource_DataSourceId",
                table: "Roles");

            migrationBuilder.DropIndex(
                name: "IX_Roles_DataSourceId",
                table: "Roles");
        }
    }
}
