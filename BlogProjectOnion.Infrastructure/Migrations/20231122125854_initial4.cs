using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProjectOnion.Infrastructure.Migrations
{
    public partial class initial4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { new Guid("343f8370-28d4-4ade-91df-7965041b98f1"), "54caaf85-01e9-4061-9e96-fe51aaa0b4ff", "Author", "AUTHOR" },
                    { new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"), "ea745170-2bed-43d9-8523-97809c7128d4", "User", "USER" }
                });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 22, 15, 58, 54, 137, DateTimeKind.Local).AddTicks(482));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 22, 15, 58, 54, 137, DateTimeKind.Local).AddTicks(472));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"));

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 22, 15, 55, 11, 923, DateTimeKind.Local).AddTicks(9663));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 22, 15, 55, 11, 923, DateTimeKind.Local).AddTicks(9654));
        }
    }
}
