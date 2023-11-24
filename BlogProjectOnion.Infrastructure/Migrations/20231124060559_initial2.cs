using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlogProjectOnion.Infrastructure.Migrations
{
    public partial class initial2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "CreateDate", "DeletedDate", "Email", "EmailConfirmed", "FirstName", "ImageID", "LastName", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "Status", "TwoFactorEnabled", "UpdateDate", "UserName" },
                values: new object[,]
                {
                    { new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"), 0, "5e111b83-f79f-404e-9598-3ab81eafd5a5", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "enssfvvzi@gmail.com", false, "Admin", new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"), "User", false, null, "ENSSFVVZI@GMAIL.COM", "ENSSFVVZI@GMAIL.COM", "AQAAAAEAACcQAAAAEHpErvA2ULoc4Ir6ZV7IoxIF6MC6PTUCVMM3q68uis/A8wfLxoMsGt0j4bg7JBALCQ==", "+905439999988", false, "3a166ddc-37d4-41c3-ad22-a109bea9d4d1", 0, false, null, "enssfvvzi@gmail.com" },
                    { new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"), 0, "4b238bfe-9e22-4197-a597-941f63b7a212", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), null, "superadmin@gmail.com", true, "Enes Fevzi", new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"), "Çiçekli", false, null, "SUPERADMIN@GMAIL.COM", "SUPERADMIN@GMAIL.COM", "AQAAAAEAACcQAAAAEBYqktufEVLFNpguGebBf7/bgtMTWiTgu0DV9iKn4plpnCvRK458XjBII8ViQR69DQ==", "+905439999999", true, "b2b37655-4ff3-407b-88d6-987d97bbf388", 0, false, null, "superadmin@gmail.com" }
                });

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

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"), new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"), "AppUserRole" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "RoleId", "UserId", "Discriminator" },
                values: new object[] { new Guid("343f8370-28d4-4ade-91df-7965041b98f1"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"), "AppUserRole" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"), new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76") });

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { new Guid("343f8370-28d4-4ade-91df-7965041b98f1"), new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c") });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("b207b056-26ac-4be9-b6a5-07eb8c9e8d76"));

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: new Guid("cb94223b-ccb8-4f2f-93d7-0df96a7f065c"));

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUserRoles");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("343f8370-28d4-4ade-91df-7965041b98f1"),
                column: "ConcurrencyStamp",
                value: "45a2205b-46cb-431e-8593-34f9f320b43d");

            migrationBuilder.UpdateData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: new Guid("f0a0b477-42aa-47fd-9e01-a81da466848d"),
                column: "ConcurrencyStamp",
                value: "07f17faf-8d36-47b6-ad78-99fddfb45a5d");

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreID",
                keyValue: 1,
                column: "CreateDate",
                value: new DateTime(2023, 11, 23, 16, 6, 36, 110, DateTimeKind.Local).AddTicks(1590));

            migrationBuilder.UpdateData(
                table: "Genres",
                keyColumn: "GenreID",
                keyValue: 2,
                column: "CreateDate",
                value: new DateTime(2023, 11, 23, 16, 6, 36, 110, DateTimeKind.Local).AddTicks(1626));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("d16a6ec7-8c50-4ab0-89a5-02b9a551f0fa"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 23, 16, 6, 36, 110, DateTimeKind.Local).AddTicks(1802));

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "ImageID",
                keyValue: new Guid("f71f4b9a-aa60-461d-b398-de31001bf214"),
                column: "CreateDate",
                value: new DateTime(2023, 11, 23, 16, 6, 36, 110, DateTimeKind.Local).AddTicks(1800));
        }
    }
}
