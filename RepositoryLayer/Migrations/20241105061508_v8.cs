using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "OrderInfo",
                table: "MomoPays",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2190));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2191));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2192));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2193));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2194));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2195));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2196));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2197));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2198));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2199));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2200));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2201));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2202));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2204));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2205));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2206));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2208));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2207));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2210));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 13, 15, 7, 996, DateTimeKind.Utc).AddTicks(2209));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$T.eA41xcBJgTRHvrgV126eURjdJZBW80Vxkmbn1R4y4SnidREiXCC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$x5XZgJ8bToZPvcUTTqLEMOK6syG/r7NkIDcc6TEhZtj7rXZW1m86i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$m3u2B0xLfoJh6n1e7ERIDOswlNe9vysJLxRYLrWtIC7yx2AorfhoG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$BxeGuwyhhUhcvaDwvf1FyuOQQP7IWoaxXoqvVbtKX8jNCikCT9uoq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$bm5JYzKsbD80Uo5KQDbn/uJq1NT6ll5baiJKIYaWwbb0UiT6Gqmka");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$ks5foZUjFGyQxe7APOpkDOSTDDEWiH61wfdM2bQKeSHc2yeIghUSW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$cRiFWnA/IlCUfYSBxsb8Neo1Y17TV2/gjzOT7R7td5tcMCXEm3EfK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$ePpG1eY.SDgsSFu2r3FyKOR3ZV4aZk4fOrCW/Fvd0YQFLZUJ8a4pK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$sQpEs2e3V0UhH2UkWkJ5reL9JQLeIq7W5UksFAcbqkn2HFt4YUdJG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$pNr/iZ8ncr/.3XqmhSyavu3Llxz/rGSKnXLYtS.x7pao3.IYOXniy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$dHCakaLB0xmBYQMJGr.ZB.Vi17Ozl0S5oME63LdKL4Rb5c9kA7MKy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$mYAY6tkZgLHIYfYsOaDYrOsbnAZYQWo36NiRwLS70AlwkIQ3H6Lxa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$sAtKNkkJCsaRXN5rwYIsQubAVIVDlYbZ/eyaO5pPzDvbh4YvbewlW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$b8eT4mj9xxKmarTIweQdy.qlTATKdxfGKvHZLgJBTEMJcxoEr5OWG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$PJxx4JLZ1/v6Gr5Hm4k60OganpDjmt0CdhBdur6cxzCXCsMJglYfG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$dQEBB.LrBvdG5yW7IVJ8PuC6OqrT5FLOtD..B4zVLpFsXEyUJOcYC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$vvmEf4Io2by8MDcBrWaWF.78BrBZq7OKHBHA8pKmDfUJ6rGHac.NK");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OrderInfo",
                table: "MomoPays");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5075));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5093));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5094));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5095));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5096));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5097));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5098));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5099));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5100));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5101));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5184));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5102));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5185));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5187));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5186));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5188));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5189));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5190));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5192));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5191));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5194));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 3, 16, 31, 54, 522, DateTimeKind.Utc).AddTicks(5193));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$k9USmE31KCvk4q4OZFXR7.I.Pr8MiwjU/r0C4wnhOAYJcBTbzoXQe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$CnH2QCmLL9aRjD1Wy.0L8ewHhr6WOlvKUjXNDU5TtfCCqRz8JvN/i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Mvz.ic3OgcFgLRtcJp9bheIsx6lMpFQlHsbbcQpbgiPuROwMwoT7K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$29npKqrW1jIVP./SdNqH5Oastz3hzC2EKufhxiQPOH1B.WS4f84iy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$BxcGK/YwIVIyeCjcCh9/CeRlsbi0xjuSdZBKMOafNQ7R6MZZY.lSO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$pcM.qiWXFGnrB6IX6hvS..wD4RERo6ReLCv/pAehfnncoqtZXl2DC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$ojBue0ijCtzsxaDWHNhwqujMdH93vThhuwWpKZ8fHwANxxc4uykGm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$i236/ZynFodXAlVGLV.jhu3nV8T191h9.ABhosdVZZFEOK59k9rNG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$NsZrPeowidfW7t0yej3bQOZv5MXzOmnB2aAHDmF8xCSz5VqjUzA9K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$8wMj8HB07mEVDrfNwR8vFOtRtBszik5aegBxbGRGZbrZLK44JqKnK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$K15CvN/bswfWHHXolvQHgenna7nb429Bj/ILw/H9kZ4P5zKx7r9uO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$ME4XIfekMI0DCpyK50e8DujI222EzxNbJTD.TdSzwAN9ZrUq3Y2LC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$nF3prU6GbHsH4DR16Xv7KeVsgRkGwPFtxCdfZRIUCB95YsRz4Vwi2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$YP46vmEZXu0XDAy8SrQk3.hJzsiG8WuyscBom0/B4UF57k5T8xJ3a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$8XSM7wcXSnA1wy6pO1a63eHfj1H0Ws4MyUkbrrc0l0nrzOsm.ywtu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$fV.8c6BtPT3dUKZ12ZUWd.CSnzj4qaQX5.nlnIQv0Wa/FJtwORlaa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$tiia2QgHPG6imYIXY9fUqOY.lNsqbTgxlv0eZkJ3A5xTpnbdXZd7C");
        }
    }
}
