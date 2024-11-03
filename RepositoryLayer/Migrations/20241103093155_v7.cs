using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MomoPays",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    RequestId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RequestType = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    LocalMessage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Amount = table.Column<decimal>(type: "decimal(65,30)", nullable: false),
                    PayUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Signature = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    QrCodeUrl = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Deeplink = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DeeplinkWebInApp = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreatedDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MomoPays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MomoPays_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_MomoPays_UserId",
                table: "MomoPays",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MomoPays");

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4692));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4712));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4713));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4717));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4718));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4719));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4720));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4721));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4722));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4723));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4812));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4811));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4813));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4814));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4815));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4816));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4817));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4818));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4819));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4821));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4820));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4825));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4824));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 29, 20, 28, 11, 242, DateTimeKind.Utc).AddTicks(4823));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$gnnvC5Kg9SEm28eyi01B4.Kjo/0eH0DWOxJyL9uhYmt6Dk9SP1G3C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$B07mPnPcVMQ14L5ytrMM1ev6F99jPSj/EHxx6EAkS16B10.wBt7CO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$PbHY6RlpknVidtW2lqQede29Z65d2rVFWzFML0CiToFDs8B8xuzra");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$pd0imy7W0/AZogS5UiuoLuhqLW6/tLbWHB3MSmsRzs.pUWJwTWBT2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$Nv1lGpKV.6AzrHP/myIEEebdiyqOeIKSXv0q6noMs/FSEbaIwriBW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$h0ua/do59YCneBr4F8rmfeDhKx2a1Pn9D5Vq6Y1jyNvZ9GQvl7WFy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$9944Vw6QGVm4iDaSUedvgeJyUXuz6DNHZs5tmvpNIjL1EW3veJ2vm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$J8th0DPAfEpp6eH5N8cqie0BbwUhwHATewOYM4peOQ8u/TR/zDXnW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$IHUSms72PmMa46twLHSVou2XPGdDsvc8MUM6CET3IQD7it18SguRy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$8gG6ytSpXe6mhRCniyj9FuXm8vC9rXkPQT5utmSM1H63Cb/XxIHKq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$rnGnOckAsWaTWDCrEV02HuV6rPgfpqLP3Z6b1MZJQ4ZqZylg.xK.y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$UAs6cAmVWYBEgHNFgg7SceW2RlJHU75xXHcv7K36VlLld0W0xJsyy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$TruszrY2Xmm47Tv4EziYdOg7qNIMRpIYEb5rJz4KyIQKtnWpxCo7.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$6SXZZ98BJ9rCsDoN1XND3Om7PijilKFWepPDrP76sVvB9w78aDVRi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$lvS5AAfeEdLnM2DqEeITg.z7rdlRCA2Z9qQneAXA6PN9Q3r6EFSX2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$XEKZH1xotdPzTOuLaoWZC.8ExaA2uhSYD2UylMFesJTsno6aXVSUW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$6nISWT7krico242P4owbhey7l6X0cz6CwK4cFzUanrrfjzG4UTJHe");
        }
    }
}
