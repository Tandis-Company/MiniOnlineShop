using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MiniOnlineShop.Persistance.Migrations.QueryDb
{
    /// <inheritdoc />
    public partial class Add_RemoveByUserId_To_BaseEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "RemoveByUserId",
                table: "Users",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RemoveByUserId",
                table: "Users");
        }
    }
}
