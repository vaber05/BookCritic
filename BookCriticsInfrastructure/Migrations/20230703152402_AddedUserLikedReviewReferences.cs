using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCriticsInfrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddedUserLikedReviewReferences : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "NumberOfLikes",
                table: "Reviews",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikedReviews_Users_UserId",
                table: "UserLikedReviews",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikedReviews_Users_UserId",
                table: "UserLikedReviews");

            migrationBuilder.DropColumn(
                name: "NumberOfLikes",
                table: "Reviews");
        }
    }
}
