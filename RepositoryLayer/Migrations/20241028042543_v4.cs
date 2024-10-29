using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Posts_PostId",
                table: "FeedBacks");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "FeedBacks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

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

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Posts_PostId",
                table: "FeedBacks",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Posts_PostId",
                table: "FeedBacks");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "FeedBacks",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 1, 1 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2776));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 2 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2799));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 3 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2800));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 4 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2801));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 2, 5 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2802));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2803));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2804));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2805));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2806));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 9 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2807));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 10 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2808));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2809));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2810));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2811));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 13 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2812));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 14 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2815));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 15 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2813));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 16 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2816));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2818));

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 17 },
                column: "CreatedDate",
                value: new DateTime(2024, 10, 25, 0, 25, 25, 265, DateTimeKind.Utc).AddTicks(2817));

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

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Posts_PostId",
                table: "FeedBacks",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
