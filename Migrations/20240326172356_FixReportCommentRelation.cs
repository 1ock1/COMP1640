using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace COMP1640.Migrations
{
    /// <inheritdoc />
    public partial class FixReportCommentRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ReportComments_ResponseForUserId",
                table: "ReportComments",
                column: "ResponseForUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_ReportComments_User_ResponseForUserId",
                table: "ReportComments",
                column: "ResponseForUserId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ReportComments_User_ResponseForUserId",
                table: "ReportComments");

            migrationBuilder.DropIndex(
                name: "IX_ReportComments_ResponseForUserId",
                table: "ReportComments");
        }
    }
}
