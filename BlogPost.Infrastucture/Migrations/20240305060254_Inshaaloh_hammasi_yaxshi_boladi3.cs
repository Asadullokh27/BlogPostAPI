using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogPost.Infrastucture.Migrations
{
    /// <inheritdoc />
    public partial class Inshaaloh_hammasi_yaxshi_boladi3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "BlogPosts",
                type: "text",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "BlogPosts");
        }
    }
}
