using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class FixTransactionNavigation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId1",
                table: "TblT_Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UserId1",
                table: "TblT_Transaction",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_TblT_Transaction_BookId1",
                table: "TblT_Transaction",
                column: "BookId1");

            migrationBuilder.CreateIndex(
                name: "IX_TblT_Transaction_UserId1",
                table: "TblT_Transaction",
                column: "UserId1");

            migrationBuilder.AddForeignKey(
                name: "FK_TblT_Transaction_TblM_Book_BookId1",
                table: "TblT_Transaction",
                column: "BookId1",
                principalTable: "TblM_Book",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TblT_Transaction_TblM_User_UserId1",
                table: "TblT_Transaction",
                column: "UserId1",
                principalTable: "TblM_User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TblT_Transaction_TblM_Book_BookId1",
                table: "TblT_Transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_TblT_Transaction_TblM_User_UserId1",
                table: "TblT_Transaction");

            migrationBuilder.DropIndex(
                name: "IX_TblT_Transaction_BookId1",
                table: "TblT_Transaction");

            migrationBuilder.DropIndex(
                name: "IX_TblT_Transaction_UserId1",
                table: "TblT_Transaction");

            migrationBuilder.DropColumn(
                name: "BookId1",
                table: "TblT_Transaction");

            migrationBuilder.DropColumn(
                name: "UserId1",
                table: "TblT_Transaction");
        }
    }
}
