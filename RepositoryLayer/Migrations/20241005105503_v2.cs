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
                name: "FK_Donations_Users_DonorId",
                table: "Donations");

            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Users_UserId",
                table: "Donations");

            migrationBuilder.DropIndex(
                name: "IX_Donations_UserId",
                table: "Donations");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Donations");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$HEdcESIZeg8iPt5K03YTXeHSfYsZBPJcj1nJ25Tlq80T6ZWklwW42");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$9Nt5gWqFf11TDDYCTjav/eDZebLgNUXNEOE/.4fM/NPpX0NZ6q7Ca");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$5pYWi5H0vBsxLABS10wp8eEkeWJrGDsrQA1klapzfQ3RNocbG4XMK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$.GZm40VLBsQXxXR.YNEtYO31Irgo7H.FOe4Q1qhauunpuJtd7GQYe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$.6X83ijVKZb.wIb9g5KDiO8kfk3.FiyuTay6E9yXO/nEv983d7Z1G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$dHhAQzG8//yVrbBW.dutBeRVgLeywv7xOoT4wB3pTOHs2jbZv1Ur2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$HKeHgcGgZ.TvWP7KS54lueE1l8tkeO3uOVpb.W22PKiza2h5hbks2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$xDTcaN27R4r0yGKr49NeD.8zUE/xY9b9537wfYZOkupH//3B6VS5e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$jwkggWBjlXQn9nXbNfwkYuyS.DZCI8cjHDEt8HEwmwQmo/41Ibvua");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$6I/PBwoVFxeaSl8oSPpiVebOpW27xw66uIH7uFKQAwbkBSUlCPWOa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$uypxRINCd3a4CIVtKM/2n.7wtXoq4Z6NRHSh2XIjMgMy5YhJlDIeK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$HKtpEM0OySNFfshgP1KdI.jmdjJwEqryEpnHUIftK8JsJYoAf5YVu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$vZXgc36IQd7vaxk2RSrh1.PzoRQb.rQONpW9fZ2flbF5GgiTAjG2G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$.9w3j4eodbBxu57AloCBIe3p.CbcSw/uE6WIYS3tvMzGq02vKKmzG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$DthV5SkZaYVIx/Rw1dxxY.LqsG9KZEvlSgtWPsqtpR3Frq50jDtOO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$jogTNbbwqfxZpQGoRHNiCuoR7ITPvD6FZxcPhEfk631CD1MdabCMG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$2baxGHgQJFZFofVKRrBlYevfRUUAu3YpCkAsdObQBhsXUOemxY69S");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Donations_Users_DonorId",
                table: "Donations");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "Donations",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 1,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 2,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 3,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 4,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5,
                column: "UserId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$STdin1EIgYxqXFCWdyUXVuUqbg5NdW2xYdU0hbBZQLz5wRIDpmQK2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$jYk2lHb.0edxvA2sOm94eemHKpoJN4Pnp.V/Of/wPkDzxUScGoGJO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$xPuubLniU/80g39l8TiKhe0u0Kp1KTnfRFne7089t//FyoV1bgiFS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$1wFVzF06zzI/K2n5AX89ve9mL5ZZA4OS3zIahYB5ZKNwz1VMvKCWu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$CEm8oKlutQTVK8rmpW35we1N.LVZBC216M7Rdb.lXdFsrAyOwakWC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$qz1onx6pC6Cq/8qiRF9npellXqAfS501A62AeagUa0pLVBRxS.ZSq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$OFdZkybsHfkFP06QZfQ80.B2.PPmbgxb2wx2y1u/fZy2qqbfaGzgq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$uzkxgmW7cW2T.LBy6/gXr.Um2zvAO0WQadS53BjuN1d73bktYkjQO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$.dfl2kwWixLQuBHd/hIFv.Dcz0mvuJeDwiHvbT2xvSuEnJl1W8ft6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$LqW//Z/qYdXrxtlo9CNEGeju1tmaqTrmOf.zbkCPxb18lmT1TINKO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$ZPF4AwNPTpdX/c226IOWbu5sIFqvYlhP4Fb6a/Cp0j6qFKQRd5HMG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$m9fGXqIKaRqeUR5pzeAyp.dd8jX92RnE1FxjAgkmgPX/ZmO4k2zdC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$eKOxGlOLNYtzrAU2hNRxzeqq1g4XM5QWPfwBrp0NYw2b0BYZyPl56");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$miFSJ3jANZU/9l9KnUVQLeryDh6hRN.CJZYmafNgyyFVTlRkW7gXS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$u1AN1dxAoUs2fFZzj0tHreGuwZR6km8p.bpxpgLJwsUkLyDw2V4ui");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$vE4shHAN4g3XoHhH7dYTDONqYpdWP2PXujL7WI1a2yq9Y4teoqPcK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$Fb5i7DVPE.Tx7YA7zl7LtOvTA2oUCQ9qda67sDCBR4WvdkQP91gOO");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_UserId",
                table: "Donations",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_DonorId",
                table: "Donations",
                column: "DonorId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Donations_Users_UserId",
                table: "Donations",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
