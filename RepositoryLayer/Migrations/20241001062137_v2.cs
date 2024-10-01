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
                name: "FK_FeedBacks_Post_PostId",
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
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$DVFcE.CrjVUZZ26AMtfJs.oYXsKYPGR4CuLFtR9.HrJ.Vn0saV822");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$h7X75u2KLDplfuq8MrDzJuZRjrQuqTfWZb.8akAUyiuHoaNsUAbUS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$8owZyZ9TWM2wepY1ZyBLq.DlGCrOjxYq.B1ED9iTooO94F4SgGBR.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$s038o3LCToFyBfJxq0sl3.Dvlll5f0vBOVw.9DcpKAl5iowEy7Doi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$qhOAtA1oySjDS8rSOkHDre/tePtKD59357vEmJS9u89GGZwCNw38m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$5FhXhU4kx6xPD5gnoWtvu.pNcJ1PaE5MabG208hS7nhgAMJolorlq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$upyXLWl9wkaRTdsOi9KutOjm78Vs7TxDtO63nc7OHmLh1/4e17L06");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$xMGVdiVsIT6V7LlKMyF/i.aw78dGVH7/VdLcMSSrsw2/ojsmNzGCG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$RSgoozh82WBjQi5RmRhF8u01QnBvKaMJ3Ma8rW3eN.lGnuag7tjiO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$rCtOz5uhvFDc/8M7x0tbyuo3qZKPPapSJyMoVS1P5nh4gmW8OHRxO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$lAt9Bde3wHCHWxNIm1iwlOjX8g0KxCipjz.CUXgDm6Z0mTNEvRgse");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$grM7vZLtcS3QmlA1./2WveZTn3vobukqgFFMvmfpjO.dXMBnTDsxW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$En3NF1rj0f9TcFjKWV07Xu9NJaONmoaD0VrxnwadAwqiI4y7ZqBRy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$SXtVEtX0urACeQ8692TA4ug2yM3gOyVKveKdyCvBMQzQjcWPwTyN2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$9au2iFFvy.Y8B274IdF3DO6/jGXI1m7h3Sgb8epYJyVJhheMtw5Z.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$c5UGpxurk.g3dqTRPxkRcu8yrywFnsQa1hpX2QTRC188pwNuUWxge");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$mP3Ir1qeoDbVKAOvNAD4TekXEgwETSBlbY3JBZkFP3aDec8DkEg9O");

            migrationBuilder.CreateIndex(
                name: "IX_Post_PetId",
                table: "Post",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Post_PostId",
                table: "FeedBacks",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Users_UserId",
                table: "FeedBacks",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Pets_PetId",
                table: "Post",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Post_PostId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Users_UserId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Pets_PetId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_Post_PetId",
                table: "Post");

            migrationBuilder.DropIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks");

            migrationBuilder.AlterColumn<int>(
                name: "PostId",
                table: "FeedBacks",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$LFfN8/Vo069p6DDYSzaoSePlTudPsdXCZDvtZC/wg6CyQZOEYoxX6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$6RqsgS5iUrXvruYnG5OLX.ZAVPfbIqzVC.jyYyNy1KA2sF3w2uBHS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$.ThIczEjiOnOtnO3oXjjZez/ZrlNsBf/VMIyxc9wA8Ka1KOmbAWnm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$dmOAVWB5Fn1MES7wBjwHoOdDZfIFOtryNb1Vup9zBLcjjlmyZijAu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$Zu1MG2FuDQRFHYYenAfdXeYGddMvACAQkmLyETiL6ONpiozne77Ce");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$CFkH7WNAYNd3QOXuH.Ms9e92yKcw5VPmi8h0UXxFsE7o82Nq5Hfd.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$RywSVhTNbbIvn7Vi2qT11uAiy.xY4rz6Bvria18DwS3v509WIJecG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$PJjEWAZNpS1HVKGuDZYELu0kaUpuSPQ4DGXp/5DMFmCEf1xbbMhW.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$CIbZRFlGDlDvHuGf61MjY.gu4yyZq14uFGu.gYRRlgzuJGcnSyQ8e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$.tiSSYmTB4n7Chsdtoe7pOh/UP39ptVYIbMLQTXjLZIDVsU6oAwfm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$MvkJAmTguwagTgkisaip3.cgk8.FHVo0uVxks2b/Me9a5DxSbcq9e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$ciGkKA2jlTLf0byS3gpJN./.5rv7RxnLZ22A6/cFRahB1vXhgvqFi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$qqLa7ZuPvf4XOpKIYp4eQuVJLqjD8M/UQ79WWl5KH7txLNgz6HipO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$Ziwx1rkjvI3nDKG7tdZKte6LkGV4/8Dj89ihyWoB5ds4SFT679jo6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$9Dh6a6w.8K4nj5upfFao9eAPtymmx/p8XpKBelIryh7hhbTQh58iC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$Ira0TU.aBbbwr6NCjXu80ebM3JcMDk3y.kJWxBMvieoTVaoh6oerm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$xfNvNd4V7QVvP.8ti9u4k.jJeM0yjFSmK2zKc2U.MkP1keM1eb2OC");

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Post_PostId",
                table: "FeedBacks",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id");
        }
    }
}
