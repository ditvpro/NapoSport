using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NapoSport.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class removeModifyStateToBeCity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "State",
                table: "AspNetUsers",
                newName: "City");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "City",
                table: "AspNetUsers",
                newName: "State");
        }
    }
}
