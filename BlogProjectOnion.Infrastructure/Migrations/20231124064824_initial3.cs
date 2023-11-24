using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProjectOnion.Infrastructure.Migrations
{
    public partial class initial3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ViewCount",
                table: "Posts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "82131ca2-6d03-4792-978b-22a21e12c67d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "7f6824a8-d02d-4f2c-9424-e1aaa8555ac7");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "b81ed44d-b3e4-429e-aeba-a97c780464fd", "AQAAAAEAACcQAAAAECMrMSRrMdHU78uZdKIPJqnntoIhITS4s0jtBjTysHSq804YGCaUEbri+5suVg6Y3A==", "0b423e5e-5942-4cf8-b69e-a1ade1fd62bb" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5ddfeafc-686b-495f-8920-4629a673ada6", "AQAAAAEAACcQAAAAENpBP0KmI1UlXATwa6M8DB17dRUFxe8X86A54nbVUIJBLIxrnmeRvez2oSxBf6Ygjw==", "4e380d65-ef47-4cc1-8ca6-d4920e860802" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 11, 24, 9, 48, 24, 395, DateTimeKind.Local).AddTicks(7021));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 11, 24, 9, 48, 24, 395, DateTimeKind.Local).AddTicks(7033));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 24, 9, 48, 24, 395, DateTimeKind.Local).AddTicks(7175));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 24, 9, 48, 24, 395, DateTimeKind.Local).AddTicks(7173));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ViewCount",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "fb8f81f7-23c2-4944-80a1-0ee633ae1abc");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "b8679151-8f83-458b-bda8-59ccf6f013bb");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "5e111b83-f79f-404e-9598-3ab81eafd5a5", "AQAAAAEAACcQAAAAEHpErvA2ULoc4Ir6ZV7IoxIF6MC6PTUCVMM3q68uis/A8wfLxoMsGt0j4bg7JBALCQ==", "3a166ddc-37d4-41c3-ad22-a109bea9d4d1" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"),
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "4b238bfe-9e22-4197-a597-941f63b7a212", "AQAAAAEAACcQAAAAEBYqktufEVLFNpguGebBf7/bgtMTWiTgu0DV9iKn4plpnCvRK458XjBII8ViQR69DQ==", "b2b37655-4ff3-407b-88d6-987d97bbf388" });

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 11, 24, 9, 5, 58, 784, DateTimeKind.Local).AddTicks(9225));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 11, 24, 9, 5, 58, 784, DateTimeKind.Local).AddTicks(9234));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 24, 9, 5, 58, 784, DateTimeKind.Local).AddTicks(9443));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 24, 9, 5, 58, 784, DateTimeKind.Local).AddTicks(9440));
        }
    }
}
