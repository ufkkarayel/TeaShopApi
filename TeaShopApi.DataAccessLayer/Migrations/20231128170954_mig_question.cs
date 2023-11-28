using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TeaShopApi.DataAccessLayer.Migrations
{
    public partial class mig_question : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AnswerDetail",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,2)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<decimal>(
                name: "AnswerDetail",
                table: "Questions",
                type: "decimal(18,2)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
