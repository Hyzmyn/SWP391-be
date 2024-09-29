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
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Pets_PetId",
                table: "Statuses");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Pets_PetId",
                table: "Statuses",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Pets_PetId",
                table: "Statuses");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Statuses",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Igil46NwzpLUr6WWRa1U1.c9NjRdiMey.j6ZJB.CLimq21aUnwr6a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$mmFy78YeO256a278wa4kUe6deWmoGJulLh7uEu/kkr/SR6aAS/upO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$N3w29krW1jKMT6ZRQfCZfeY5PugvbRou5LuAguOAAadB4MSadGqrW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$JsLSx/si1CK2YEiP2MtxQuoXL2G9PUMiFZnVDlJ57dNarDIj9FixC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$rhWE2d73lwIdbAJFAnUSvu68I1PFOMNOqjnnv38pm0cEm0fXgDjXu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$zWbU8VAvsLXMPIXFVYpBe.2RXEY7mrjoA7ktYOzvwx6ZKwwnMwLFG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$K9pjzPrP8W0geTU0Cx/Hj.88c1Q3RNkvS/WsYMajrwJ178U3jKu8O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$dTqw2MqjSgdBLrqsUryB5.qL0DAvauo1yUmSud50cVKJRptYGYkka");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$a1oJoDM3H7MXmgwMwxWmRezT/sK6g4rBytuaNwzr0XMdTGa0c7Jq.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$Vm06gLFB6AzkDpLdt1K7K.etT9fSZYoyeOUpdRtgx78P/jebkDpc6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$u6lqI6maZgSWrCsQ0U1S1eYJGMBlvqcGp2OFSG/e/1371XTVkjrnC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$BDFh6.GsxIGZFbSf8lzsh.B8/BxoAD/O.jTto.S.dQA.9PpAenAta");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$IB0T865NbKP6Haow9F5bXuQ5XFSK9Gxn6PsZyEXSuhLNtWmNbzyZi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$HgQzAbdRWFbZvNLRVy4WR.Qquf7LJV3vvm4vElsv2ouUZHV0MBtrG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$GrA0aDn2fnd1nvwsrY3HSOYLWvgtf0AYBsNkspYdUHWkIdhsq9gVi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$OhXN9xviW3TTLsCGITKEweCijHJHeM/RVCG4e0yT8CCMSemnACRta");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$45P9P8lUoQGS7hAr8sbLPOyOnrsVH43ngfeBPFOZGG4ItzeS.T2b.");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Pets_PetId",
                table: "Statuses",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }
    }
}
