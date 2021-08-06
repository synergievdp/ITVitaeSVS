using Microsoft.EntityFrameworkCore.Migrations;

namespace ITVitaeSVS.Infrastructure.Data.Migrations
{
    public partial class Subjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SubjectId",
                table: "Topic",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Subject",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subject", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Topic_SubjectId",
                table: "Topic",
                column: "SubjectId");

            migrationBuilder.AddForeignKey(
                name: "FK_Topic_Subject_SubjectId",
                table: "Topic",
                column: "SubjectId",
                principalTable: "Subject",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Topic_Subject_SubjectId",
                table: "Topic");

            migrationBuilder.DropTable(
                name: "Subject");

            migrationBuilder.DropIndex(
                name: "IX_Topic_SubjectId",
                table: "Topic");

            migrationBuilder.DropColumn(
                name: "SubjectId",
                table: "Topic");
        }
    }
}
