using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "UserRoles",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Status",
                table: "UserRoles",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<string>(
                name: "Vaccine",
                table: "Statuses",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Disease",
                table: "Statuses",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext")
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BankAccount",
                table: "Shelters",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 1,
                column: "BankAccount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 2,
                column: "BankAccount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 3,
                column: "BankAccount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 4,
                column: "BankAccount",
                value: null);

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "UserRoles");

            migrationBuilder.DropColumn(
                name: "BankAccount",
                table: "Shelters");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Vaccine",
                keyValue: null,
                column: "Vaccine",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Vaccine",
                table: "Statuses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Disease",
                keyValue: null,
                column: "Disease",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "Disease",
                table: "Statuses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$94ONSiIrc6ZzzgU.YdnuL.UCYT1.EufAhdgnf3qmopJ68Y4x18/vC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$UX9idfkSkMydugMnhheRReHqwEOUWADWQNUD24nB2zsGLzcI.bBoC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$.g94LmEWv3sLpgmVu6aJHeRG9mdIa7wijyB2h2RecmDsGEJJyDsVW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$7e8uswLe072aqs/gp5EI2OoplSGjB0Tfup/8l8gBYtNuO2AGfYe5m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$GdhmKTTYfTtWu1lM0w1UuO.u.zvTBvEBmsNv9QQ8/6qTGal1I6giq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$.9SltERpYVQGZXiTRl1qze/NrKsfjJSRWu2Ychb02IELh/QzS1svS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$p2PukSpo2ZRlg0IPVVNHlON15xDGVZs8goyx1uobupW9KGLpQslL.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$Ltc2/xqNyqWnMvc9I5szZuK9K1ZQthJ6gvFqOMP7HM/C1EXMxs25a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$Hzw0LQjBcU8nYXARgt.zduCFXAda7Zgg50VAT96uXkM3i2tPLVp8i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$f4rRCsxAx7q/MzCQa45fM.ELyEPGL5CBAw8q1lZbfoCo2m7OuBsrO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$MSY3uc6pnZzYRC8aiBLHV.RU6oViFeY46uH55d.A0e6Z7vIg7Vv12");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$CHKu/wVEISQqTOUiGAvh5OVMDTibcanIKg3GLBkzO0ZPhZXr22Zua");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$T8ZdPZU3rQ3E0L.RXufSu.1B/UfiyMgLIGYjOvbPJyFxz3kaRVv66");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$hc0HY.qGMkoQa98YJ8IY8.sVj3zFbTql.FLbl0S6RVAXMnKfvjdnS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$WJQL78r1jfluo3ki/LUn3.iW5q64I9MTDWeGkXd.iznyo55pgyWgi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$7RNadZ3YVMAIxzCXOoHhfuU9802gSPCdSRVEkxXrqt8TZlbRC..MC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$ZCulH3DNle33uqNZckJQEufGplEOE0NEr4xyYpPUomgPriIZoY3Ui");
        }
    }
}
