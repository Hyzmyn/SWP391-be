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
            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$nt2XVm.unTmvIovpno1qi.0YIoDlvrlyoKRLEx2wAouQvvyISRvHu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$13A4WJQMV9z9iP9OU6kJrOTmOIpYE3MdpbdYiyM82uRYxIgww2R0S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$CjWBDtZg8vl8NWl2JiH./eLjtlxEppII25lIEKbk55JkO6CJoLNv.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$fU4SXHKPEIhly2.vucI0Yex2Ioiw8rlgem4bqtyO4/xmr460bScfC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$NIke2bCFfClflaa3A0V1Juzt.BOLxpNW7sw5k32shhdjui5PvFyjK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$PB.u6J4NtJc3d7gtNEbeZ.caoTt9w7VsZHC68GcmL/SwZxse7SP/C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$Ciert.jgjB28AbJ6UWToTemE19IJcxfF1JuxDYUbBuj91BJ/.IpjC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$bQp7KpaA2b0ek1hVdJ2gEO4TU48mcwhr9lUirpy6DCbaX4/9fAsOO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$6oIX1SfyX0mrJu6vaeOgtODvLXetqZOCE6Va8NPcpUbwl2uab3WUO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$ZBP8pgynk06zXoqyrfQdpuvbwwhK2lT/BhgIPUVIrMtGD2LZXD.u6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$6ghGIz8F7X4d0.vDtgbdqe76LNI4YmfUEAeiQXwc6tgXRgNGDR9Lm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$no.wjKypFrmFzAYdGY0UwOS899Y97pr9kA6IVpq.DKfDWHf74jSqC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$6NuPUVRAOGkpDFCcVgL7Xump1VhBh4sAVc7jW6J8G9pyxFMbgL7kS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$vhe/FDcyJJ1/lJlcmbudAO8Gib0ULVS6svf1ioIGm4uB9M/ycUNT6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$fVN5y4BCfUY4SryUUJhKX.VELYp7uq0Q0zrk3F62PGa1CJc7RDqJe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$cA8nitmERx5wPhfSpT0wu.aHqc5EnkEfaHDkNXSq5osm9l874.tTa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$yiPJzYpg3W8WxS7Jv0Vdx.0rSBJFYjnZ5NtpLzfZfIJNeu92esvCO");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 3,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 4,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5,
                column: "Date",
                value: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$yyj4lY8lWmqYkWj8qbnl6eJ5NEn0mrF/vcD8F8xG8COxPetlRvVbe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Wp63FPUIYtDvP9N9Y1NsOeA/8sdtL.BEZeDWi9IHYFLNdCsytoz06");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$i8xuWRw3qGR50Dw8gilSreOJfB/fS/v10nX31hKzhdQPTcB.nt8DW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$5690Hl.GtsVavCUccLbqfOEhKU1GnBN2j3OjxElL3nRxtm0OZZ6yW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$ftrdAp774z9/yknsy1gS4et49OhxD5bjC9N7UzkyCMa5cqT9V9YKO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$Gkf3CbUvV9cza4grXytwleqe5RaMXV/2PHjJ361Szz1XVG8XqezCG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$JrOt89N1DFD6cJ84EhGduuxl90mGzTp.jeYO5Uq.L/e3DdBy1vWGS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$yOWlQpT4P3l4W0M0M1sbaOKhdkfZYahuaRYl4Plk0xDO4iTVz6rHm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$.jJyZOelBEWiVOLH4G1V3u6RcPTiKT3MFuG2ZRxZNjdO8XfH9GZ8q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$ty5F3AOmZHJNRUKYpm59O.8jJBTjzPTocnc9aK/vfYze8C.Gkb8SK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$YVJoDMH4X3Aa7SXxqE3NSeHfnUvhxJb87JpjpF/M9KsSMdddXuaJ2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$qPLqvz3yt99XNVcJiyP.lOho06uQA5zVqj4x46hYnbaZN95gHbLwy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$XQSL5VOAcd4o.4YA05kFWevm8wB04IDKRzU3lmQP2jz.NqutfCyfa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$ISV5PYV1iec1LJTSkWwA5.sIzy1yHX6mnuV/gALpWlEBR5jcZ/UKq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$udSeVCH4SAO/M3ZM0EEH4O692A7IqNT7f6rbOmeg0G2WtWvmkkWJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$tudIyI.WkAiYZgVJ.WblIuoJmlsTBg8XPT7L6MK2ZpTn5ZYarVOjS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$DJdznZiHAP/3vfSz3nz09.hQESbwW689TH0U9MMqSQQGu4eX58hWO");
        }
    }
}
