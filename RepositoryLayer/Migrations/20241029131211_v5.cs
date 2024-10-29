using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "To",
                table: "SmsMessages",
                newName: "PhoneNumber");

            migrationBuilder.RenameColumn(
                name: "Message",
                table: "SmsMessages",
                newName: "AuthToken");

            migrationBuilder.RenameColumn(
                name: "From",
                table: "SmsMessages",
                newName: "AccountSID");

            migrationBuilder.CreateTable(
                name: "VnPayTransaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderDescription = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    OrderId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Token = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    VnPayResponseCode = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VnPayTransaction", x => x.TransactionId);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6252));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6268));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6269));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6270));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6271));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6272));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6273));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6277));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6278));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6279));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6281));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6280));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6282));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6283));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6284));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6285));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6286));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6288));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6287));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6289));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6293));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6292));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 12, 10, 909, DateTimeKind.Utc).AddTicks(6290));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$ejhw4DJ9wLRttzDD1fW9gOy0eVQIzbnVIjQeAJSwghsQUYb7D9t.y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Jd6gfXEzrMzP4U8E1QbJxuOKuBz8aDvdH9gqT96QqvSvpQvFEizXe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$BdshR.nSYgu2HNfXeKA30uEYX7wPKA/QnRkE/0OrY0fHEVqldFjN.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$sKngO0CFGzV7jKX3kKHhXedSLS50Uc2EptqApbwZPPqGcT8yTJMFq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$OiZUFS0cf0w2HOJMLfueh.p.9k6eEF2NjfK.tqX0E4Q7oOutj1aDm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$y/jFT6OouzzHvZRbhK.tc.i4qpQ3C6bqIpFNV74p4QyqsVNMXZROW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$AS/z5kcXMWz62e3sS07p2eurUfJrVg3sGKClXdPrHhR7tT.mFKvY6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$tiSVemkPL4nxZlmVbHlA4.TCzOyn6MSG6oTRZyV79SrE6jguqALvG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$zhTj.x2FvE7r5A6yREhIzO7/DPv/.Bw/dqxzrlDaDCThubFop7.3u");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$ATNWwxJOEC3mjeXFYIl8pOI3cy6Xy115lcDSsqXq4/TiD17bymsHm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$mnYuRvpfYVBFeW8xYZUEquBOnKysdDhpTCELj831q4MHlquiQRTxy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$Gf.7QHBxxKUEohJctFbAWOzLDiYmruMIlgtLjqK9EA/GoYJLI3doy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$prxGOxnoYuGDPX.rqGYuoOylpYokdRV0xnIsjlfW8KuuHSxZzpHbu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$6yPaKWYgBy.H.G6s7mxvJ.Zw/3uBx3vqXK2d9VlbgHwSTApGx6L3O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$8WhnFNC1YGiH9yR5vWlX3uo.n8YDb16WpE3xyDXaD6tqlmI9BE3wa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$Fknp2jPv3vyEqNpamJkQ7uigm6dFwTzogRbcelvn8IJ0wpR9xk69y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$73PrWkiwm7F1UowLxehf7uMwgiawl/dyTgqsDfuuMfFq4bfyDs.Xe");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VnPayTransaction");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "SmsMessages",
                newName: "To");

            migrationBuilder.RenameColumn(
                name: "AuthToken",
                table: "SmsMessages",
                newName: "Message");

            migrationBuilder.RenameColumn(
                name: "AccountSID",
                table: "SmsMessages",
                newName: "From");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5810));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5830));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5831));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5832));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5833));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5834));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5835));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5836));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5837));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5838));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5840));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5839));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5841));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5842));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5843));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5844));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5846));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5845));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5847));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5850));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5849));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 28, 11, 25, 42, 858, DateTimeKind.Utc).AddTicks(5848));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$OW5KupKTKMs4ZXuSWMw33.ZTqe7u1sCBFB9N67cnUr8cCnAyzGiAC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$07IlI2aD45mqwExMWsT47u7FoRNpR9l8p3K0ItUyMobswqsSHMWD6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$xeZIFM85jjcSAv/YPMb97etUp8ipfZgXhW4vWcxoPYXY7rB3.dBCy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$M/EqijtceEqH75aWw2hILOAX3B0LyLP0UtDL3SglJxOd5cBdYRSZm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$Kpn.oing78Ce7n.3uU31xOYB1XtA5ENHuqPln2QGlqdpTMArUneYq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$d9mYWvU7JWY7juZtJyl...bRGpHZJMe3c0rFe4VyIGl5kUf9k.wpi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$XHUvBJZsGmia5VE3yCSgHuLX/YRQbrlJxm4V1gB.AneRdGQJODTuG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$xpd0g9aLweeuVpSfMtCei.s5Dk9Slex1nBAT2Xka3A9MqbOfHRDO.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$6tMioOIIEu8fXbC6zwais.hB9Z8XE2yqHm4hr8mGg40BasgGQnpru");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$FUGWkB56esmcqRQyXC/OfuTT47ij8fCvoNFggbY.yzwKlaj5/vo5S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$xi7ho1E609TdBkir6VLDcu5stBmTWXaqU.x4NFQw1hm2bg.eUdK4y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$Hnbf84N0WUOJVsUX/Hd4deLheUoFktJcuarhI9iLjai8QuksxS2TC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$.KyPLGTOMnasq/22P5JhtOoYHghGuECso.WBBQa4frZpsTOwmh6nC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$bzbmTXHTWVV1GOyVVcXDF.tKyMM6bVVVabb9n/0K7fxI2Gk2KBSZC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$wk/KLsEB5D0ozFF2gGDMAumdKpt6Wu.3zK3sJI4uKiGKDTFQbVudK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$vL3ih5zRNZ/ms5jwuM46X.7tEBkVwdzzWQxc9/.EvmSJZ7GF/b4/e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$S.t9Kr5tDOp.pGldqlBThODrrBdE/K41unsYKbsx8XxksP5JIULS2");
        }
    }
}
