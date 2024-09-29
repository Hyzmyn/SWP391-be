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
            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Statuses",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Notifications",
                type: "datetime(6)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "longtext")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$lS5x/jebcVbdg63hxywkc.TpITtXdHZs4bgeOrqB9IbqB1VsSvdqK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$fq.DHf8t4gpVXo/lVcKi2ehibkHELKmcZdVyfjklmN6kE33Y2CJRy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$9QZ4t9zfv7PEW.2r4VYrYOJNQM/rqHjjed.ghxlk7nZmSxi1jKqPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$CTEf6oTmm7/kmIzRu2cw5u3Tzy9fR6XIgRLLsVFKhO87XyCdbf80S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$AzHIi09nvQc0tSdXP.LL4OpwQw3oHjl5MBvcR2w37cUpAogiMWdt6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$YbRQza94rGC.7gcenYVKnOJ9oF78BT2q.BPXg4vE3n2qd5WtIBNtO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$MVoq2sTN7DgOhJiZDq02Jub4ScPFPlIHUw5YPH8jhJOt0Bw1hLfG2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$08hohXJMVCu0KFzCEpLBrO/ECVsqfHR6Pe9DBYbCrPSX36ul8fXBO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$KcntOhgRuO.wui7CSNgDoePOF.PHeFfM8QmEWJU0A8xgsggovBCtK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$MgoyApHXCpPKhLzcC/vgeODLG9WlXIPm.xj1JtN.Fe3M4q1ntsn3O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$lAdTkd0bRpTJSG8ExgX0V.2BsBBcvN0w6UF68zImsL5OXTQxS2DAK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$TJOMWRbOFXg0SgL79.l.6elZVYlt4G6HyUtZNLwTF1Z6iNoklgxf.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$lyzsX2KbPsIR29.U2QgKG.iPVO8St4UywRVJkzcBuDYrvggxqRe0C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$GZxPvUwLCRzUis4RYrEFKuRBDDfrxTlweAsylaA3HZ7LbbXN/huIO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$Q0c.W36JaicNzWP8qwdbRO/J0zvE1qt8MvsA0ak58CRyBhelLFZ2C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$Z3Sna1g2ZVRBesixfBzssOltEFhjkYjJX46JhH2tHN8gpFsNHp.lW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$Qa9/dXJ.UoKRLAzULVUWiunqUxfBTIniWkDTFpt4mu4skfzFcxUpG");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Statuses",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Notifications",
                type: "longtext",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zNPSecSg76FBJc40TrCRke5busZZjDaQhm6wYy9C0S5k6AqFU1tY6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$pivUsxxJV06OJuGLbTuIgeb5glPg9fAxDNhiaRXxzw5l9.pHgfMTO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$P2g5amyHqgbxbdxOMTGZbu6CISZ2sBfWgltb6/5H0hm/QOvmJXF/G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$iH7RyKvaW6SQB8u97I2eI.kBs/AC/SLXDlNYkk05nodobnmhAuJp6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$Abjm8bZYJIN39j2CDrq/heeqHqmBB1Xki5Ou9WIJPlKR7S7cXGp/y");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$H1PExbrz79BxmuwtZrI99Onw2Kb7ApQKtgiZkd4K2XV6xNXnvbuJK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$0deIH0t0rLYlgwPUikiafuKrc2qgdGkbDz874iv48QfDFrr3vu0He");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$qkuc86Sd0.WHYHE8pWvzZuqtor08a7/Thyo3Y3lN.e26vp3fUjRZK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$Xyv8gR70IA4/FJo4aPjDauo.QnL0/di.X5IV5fr4DM5itokxIlY1W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$x/8oc30VLQwPWiIzxPphcufIeK9c1wyteO2X6YKnYkQgNVEp2gMYq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$.A1PgV9Kgbhr4AK5QwOxXOQXDc2lo7uwentm3Kfsz8GHhmAMGymBq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$lPT.5Ai1N6oTyaCy3UNylu5AseSxSS3nTaIBIEu2X9QF8ua2y7BW2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$IFVE4lwjbKoY8ukIhEvZlO4aOH2aZOqSAu4vce8t9khueNM9pvrZq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$9Ja.87iyDCkQVJRs7z7GQOFT/KG17a3dYL/iN2si7vgucaqVz1Qg.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$bTN/GEL7Hp7q.hBI67PJqeNgtZqceMVlUnyxu2Dco/ByG79Ku/ERu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$KwO0HswA6gn0PGg7mCOa8eBSm4jePx.ysobJUC88IXtXpEM2F3lmW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$bPGW7.I.soUgnwj8OavYf.OAZA4LP1Xtedghd8fb4H9/kpz4jfbfm");
        }
    }
}
