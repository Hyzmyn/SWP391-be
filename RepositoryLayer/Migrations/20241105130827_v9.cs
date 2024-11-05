using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Point",
                table: "Users",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "EventUser",
                type: "tinyint(1)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4868));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4889));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4890));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4891));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4892));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4893));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4894));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4895));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4896));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4897));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4898));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4899));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4900));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4901));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4902));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4903));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4905));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4904));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4906));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4908));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 11, 5, 20, 8, 27, 347, DateTimeKind.Utc).AddTicks(4907));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$e9VKoMpC093AfygPTzESAun5YpcJTlBR.9/0hftwIE69J0gkJxlaG", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$.lkGlUy.Rw4dKxW/K6KgX.HZ3htqScTYUEwWNzGXDv4.SbvMDogwO", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$lK9Dgq02GN8EzxzDNL504e1g.qg.1yqVaZims1pR/FrTpbR74fpO.", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$s0erVL3ZeylTfSZQ/RFGRePHUAhGAMc/2nPrdm8LlgkqKExKJSzD2", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$6DQV8bS5NvsLJiaNWm1zGOKPbg//JpPleTj.OR8DQWGDnBoDt5QiK", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$3NoOG1WI.IH5BSfLvvpupO1T635j4KiCtJyfxVfMjShpkPmqnp34y", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$/8ggThU/0jpZwjULt256IeAXfCd8fphNqZXu0ia.BhJhMo0LEFDWq", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$0rk1UznMq.P9rr4Izd65hu9zCZebOYPkzXbwkhBW4dn5V2BSoV5S6", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$8tVGWLOEaKVmdw4wDjp4cO.DjdNGEonRr4.GvbVb5vTKn.iDHE.7a", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$IJkjfVwF9pLdIswy8TtWY.zaWzl11bW4RJC1KcJgZfMnFfPBrmEdO", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$IYzaDIAJdKuvaoqdMt3FfeiCC23xMIuO17NBg4heY6dEInw9lBCmu", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$dxhgatg1jZMw0muYNcR0b.8HqBBUrU/NxYtjm0KgBR8n0xnqCSFOC", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$Pyl/8pRLfOALIgVOI9QHN.jejnheBfy3WqYEs9MGVjiXOxedYsOAe", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$4v0O4X5Uipa1oArohHjV0eg1ovsJKSWDLbIWxM35bnad4BhyVHg8y", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$vH.H9hnfOOoaIiUpNrB4a.BqFQDSHwREYIm.n00sHXW59Mla5y5su", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$R/xAVvb/S.YkG7MdpkD1ouG05UN6gxbDoJ/93SUlgeraTDR9OoOVy", null });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                columns: new[] { "Password", "Point" },
                values: new object[] { "$2a$11$70za1psSz7kQ4CQtbQ/mFe.VrKT49Fh.fhtzWbd8hhBtjdsGbNAeG", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Point",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "EventUser");

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
    }
}
