using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProjectOnion.Infrastructure.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "CreateDate", "DeletedDate", "FileName", "FileType", "Status", "UpdateDate" },
                values: new object[] { new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"), new DateTime(2023, 11, 22, 15, 55, 11, 923, DateTimeKind.Local).AddTicks(9663), null, "user-images/user.png", "image/png", 0, null });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "ImageID", "CreateDate", "DeletedDate", "FileName", "FileType", "Status", "UpdateDate" },
                values: new object[] { new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"), new DateTime(2023, 11, 22, 15, 55, 11, 923, DateTimeKind.Local).AddTicks(9654), null, "project-images/defaultPortfolio.jpg", "image/jpeg", 0, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"));

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"));
        }
    }
}
