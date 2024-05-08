using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TheHandymanOfCapeCod.Infrastructure.Migrations
{
    public partial class DataSeedAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1c6c8b9b-12fe-49d0-8ad4-8df4b1e38345", 0, "18a1c7c6-00cc-4441-8521-ba9e40578d9c", "admin@mail.com", true, false, null, "ADMIN@MAIL.COM", "ADMIN@MAIL.COM", "AQAAAAEAACcQAAAAEAEC3XCAplcimf+O90A2vML35uDQ3J6MdZQ9a8RIC0mJyCmuB4VaxrngcSWQ4xDHyQ==", null, false, "1f8c7edb-f740-4409-88f9-a36e823aeae3", false, "admin@mail.com" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Title" },
                values: new object[,]
                {
                    { 1, "Clam door, best choice for your bulkhead replacement" },
                    { 2, "Full house transformation" },
                    { 3, "New Andersen bay window" },
                    { 4, "New decking" },
                    { 5, "New mahogany lattice" },
                    { 6, "New trash cans closure out of Cedar" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "1c6c8b9b-12fe-49d0-8ad4-8df4b1e38345");

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
