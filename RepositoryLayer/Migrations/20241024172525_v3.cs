using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2776), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2799), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2800), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2801), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2802), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2802), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2803), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2804), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2804), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2805), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2806), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2806), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2807), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2808), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2808), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2809), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2810), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2811), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2810), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2811), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2812), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2813), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2815), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2813), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2816), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2816), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2818), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2818), true });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2817), true });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$GIXj1zYBRuKr8TQfyFmTn.OOSqFBm357O5TSLdwjhyRScxKUd/Xee");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$WuAusPFUztbx5yFTtEVGme9yBbuJ4bDidCHAk29u1g5kDD8lPKs4y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$N.tP754xq6odRU9XS8QM2eIYZpRvSINF82kOHnaLp7UJ/V.C.1ZzO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$i5ys.TBHwt7Vigd9OYRgp.6mVAoLRJo38p2jYvQyjOn35tbVjlMTO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$2EmrYlEBChT1UkBU1lrLhOiUdzJf8Q43tlqVdf433uRLx6FX43eyO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$90SWbkgIRk9eiT8lACqE2OoP1kVKHYUHRWBmtUkGInlTZH8SqsMxi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$8bthYR0Vz14eIGU8MU3VheV1Pj9qcwuvE4npBoerpnueZkGjum6mi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$I.QEJU/j4krISgH77TOac.IT3cQzqDPv02.2BIp5V8wDxoMD/yAlG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$7DZu.WW.GUnZGJMPR2.4e.i4QcMCqkqjWg/C5Ipgp6h1Lztb7yQsy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$NmX9.b8e5ed3N1zEZgNRaeT8NcH7Su5Hyo.btic1Jr4Y92QRhSld.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$tYcU67kF0bqqwP28w7QFnOYNPtOfQGaBZZHCYQKOPSUdAlfIdQRBi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$oORlVTRVzl.oWkD34qDZee8RqFTKVYf.Qq9XRDoKlMkm90EX/g/P2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$mYFH5F2aXxdY00rgXJUWf.eBfZS.KVG0NrbQ3IBycdkVC6wovIKva");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$CDieSbkpbZoztaEEVn4ZxOuXv/vcvFxIJDOJiU6WlhlqPKkYke4Jq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$ijiZ/LmjrOp6oM134Vr8/O10NrrcJZ8.Qxah5NtBQExiEZsVxgfkC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$6xc3V6M2PnlwG2j0SkWssuJfqqPC4iNV.w3jikxEnmc09YfrA8HnC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$twUVxp6vrLAGHb2tem0bo.KyJAVR91Z/3kVlOmOZMzh8Aq.0D51EC");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5388), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5402), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5403), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5404), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5405), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5405), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5406), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5407), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5408), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5409), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5409), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5410), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5411), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5413), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5411), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5501), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5502), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5503), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5502), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5504), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5504), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5505), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5506), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5505), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5507), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5507), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5509), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5508), false });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                columns: new[] { "CreatedDate", "Status" },
                values: new object[] { new DateTime(2024, 10, 25, 0, 22, 21, 317, DateTimeKind.Utc).AddTicks(5508), false });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$FipXxt9J2umllsQuS2ZcSOnbWhCg8bF8PhXfuGLZc90ptBPNr0Nb2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$m3.p71h8JEm2AcYzTjRXMOF8kDp2ji6TzWrFnGx7mJccw8HJptE9S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$BXERY.T3cE3mC9Izydb5Lu0SrtqJCjXdoDbeKqQNGjn6bRwRuZlLe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$1zoj0vBs7.e4oz4KPT/Mk.vo9yieiu5WgHUyKds0YmnuUvqA6jy.q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$WVXoYWUHei2qk/mj0V/LJOOhBnIQMcPXmxD4xYJCJdLLOQlQmYF5K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$gSZMo.B.BIe9bAqNiJaCEu0ynu1YBCj8TVzFjic4483ruQnDvrUkK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$2r9Lc66MsZdO8ptQztyF.OsDEvbe3SNjT3.qfbd8RvpfZIUGUrATO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$16sOLojU9mSXEGKnjgoNOO15J1CGLN2m7/rGoFfsSs7ksEw499zTW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$7p4z6WLlbkM54Aq1hjQpC.DNdzEX4S6WROwMOgLAogzpl7R0ZVaDy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$TBFkpO1wPaOOMqB6ztEN7eiAF23VV/t/0Qi6RrkagS1rGAXlLiLAi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$WjJolw4nXhS7FwrVXBK1o.MkNT1VOm.qbUhSsCPkUa9.wvjnjfi5W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$eTkgDWR6eQT/ZH4TJ0atkOmaZaf.Y715iweRXzztdyRFTbYBoih0e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$CifgxnJ1KS17wgfZKoQzJ.987bjoyG/c6kdcCBom7ARPCAMn7Csii");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$7Xn0brXgseMegLgOT4/JN.xsYRP4z7mmWcnp6G4YewhgNvKHBbhTu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$Z2bFuwbYzfzszpoR.HGNd.hoGCnvhZMbSwD6KPhz2jGZ9pAHzyDRO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$yigxpJlsSDdBfUKmQVegI.cu8BP0N/TA.d1dzA0yaj3TFZup/64BO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$7AiAsFfibQjYwdaEACC5BO5IqkdA2PamUKgb.e4r5unxlshM4.9zy");
        }
    }
}
