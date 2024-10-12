using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 4, 6 },
                    { 5, 7 },
                    { 4, 8 },
                    { 5, 8 },
                    { 3, 10 },
                    { 5, 11 },
                    { 3, 12 },
                    { 5, 12 },
                    { 3, 15 },
                    { 4, 16 },
                    { 3, 17 },
                    { 4, 17 }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$FHTXJux6f/KCYKtuI4ajB.6hLmBOFJuPhpBFoCwysumge7A7AbMwq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$HeEQrfeXNP.9lBVhcBf3BuyPxonsJLElgTydxvnE4CQH7X0tB0vd6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$OWrjdR43MpZsF54NnNkO1.5EutiX4Z/jofoP8nLSEfuJnfICNfMpa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$tSCbSDha38jp9653w/ypQOR1.cKIafncircF9PUK/YvBUxzERAJNG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$OzOUvIKzN6qlJaszjLp05ulIUrkj162.KrvaXWTi1jpgPkkIdQ2zi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Image", "Location", "Password", "Phone" },
                values: new object[] { "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/5b4c37c7-7668-4af4-af72-4dcb2ab75047.png", "HCM", "$2a$11$u5j4zSMtKtW5YZeUBraJpuY1weyk3FRAtl37fUaIHOKA6lkrWN5l6", "123456789" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$aqSKrl8FQ5wMfdePQrLFw.8MDY7AHR/EiFnz6oQ2qk9LaE.L0S15y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$v6mmWRtuQp6bTnv0tOuche4pNZVkA4vAKyUzNyiVzkm29qzRXgs9m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$z1w6Bd6rF/3jEFEmSRl6PupVaey6iZAYglkeVbk1hH.EctjX1PnwK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$PtA91N3TxNi4CCl62KwZ3OOmovena4xd8/Bq.f0teM3rxQPgbbRyu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$iZbfBW6RY.f/d6VH4x9F3.ZtmGAboT7bOE1.h59sCegYMM6Zx1RfW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$tnZ3esO7UVbRIO3H5qflrOZuHOvCyXF65FCrCBogsA6Gi4/huB2C.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$5v3KY7Uvd/CFtegDzkgSZ.3mHUpJsjIejxR9vgQRBHu8DspCooXcO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$g4OzqCrKfTu.gk9ny47RlOH0UFAA3mNMCVkv/KDD4/CkgetUDxxNe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$8toMTQugF52wi6oVpxq7heF8TcgJuGTkBjjLH4xNMBhacfMI5Jkam");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$6EEoXtxUnt4Y/kuNTF9X.OxNNUu/PzkY0Bof7eT0Mybjzv3HubOCG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$c.k1oUXslMgb5PrphgKtnOkyjnpmrMhM8TBF0EAfbWNR1OoPPxQia");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 6 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 7 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 8 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 8 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 10 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 11 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 12 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 5, 12 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 15 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 16 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 3, 17 });

            migrationBuilder.DeleteData(
                table: "UserRole",
                keyColumns: new[] { "RoleId", "UserId" },
                keyValues: new object[] { 4, 17 });

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
                columns: new[] { "Image", "Location", "Password", "Phone" },
                values: new object[] { null, null, "$2a$11$PB.u6J4NtJc3d7gtNEbeZ.caoTt9w7VsZHC68GcmL/SwZxse7SP/C", null });

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
    }
}
