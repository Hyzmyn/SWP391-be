using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v8 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Quận 1");

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Bình Dương");

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Capaxity", "DonationAmount", "Email", "IsDelete", "Location", "Name", "PhoneNumber", "Website" },
                values: new object[,]
                {
                    { 3, 20, null, "PetShelter3@email.com", null, "Thủ Đức", "Shelter3", "821638713", null },
                    { 4, 20, null, "PetShelter4@email.com", null, "Quận 9", "Shelter4", "8437587353", null }
                });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$YoA3ySDWWelaNamiKlH.5epJxa5srYsUicfkZ.CN8AIO0qIREMtB2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$rqlkZkHMFiqkrZc2mXWsyOAQsJLsoLyLKEl6qWKwQF60tMA22PRh6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$7NFRkmp5FFkGCuGFY4CZPeV8VOyRf564FzoY2fg1UnZmfAYLt9aE2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$KcNzKWV.EVnOhdNDWF8XXu5P.TqZxpyY1Ki3U5zLYcjPtMD3oeMCm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$AKpjpq4g7gmeQ9E92q3YP.S3UZyInQUe6ul1pgiRZV7NLP9TqMgpq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$5XuY9waHnxyGxgmKTqZAROKvECXKHhE1ci5ThkmQsJJdy3fw/im1e");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$rDwwEElpDCX5iDMrPt0ts.UwzXcHhSGG8sgzHpVCmN0cEzdVILLtm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$3hMf17Mc3sN1MiKip4EGkuOkcbTiyWj./FAIwyRwR1Goq6BRUJVIK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$w0ynPwzM58QAnP4J9A9msefuVFFMHnxMu47Brjkvkzluph7bWMj92");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$kSP8r4ss384kYxH.b.x3C.47XQ4c5IDIbXtzyObCTPrAjLUkPBkd2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$ROpvI0ejFT/0KpfJbN1ZZu.OTdVp/v/yvb3ff9.gcA5vncT2rqFx2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$13N45ZoZkJRmuIgTsjy9JOT8VieVEfVLqAK3REmyoWP0buXqgTzie");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$XOGr7fN/w0kDP57QEJMGLOxzfyEJzhg55HLx..bsqf9eXHgJX5oyW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$ez0S1omNM8dTmBDoknpivOJQei2HqPxLIBrB3RXgQe2ILDR8VDbX6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$16saNhs7XushTNIdfWj2/.zNm.2DyuUQqTtSxyh5cFnu57Rcxp7MG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$TDWJEvTRHUDgNxh9FkS29uN3wVBUY/PGwtnzfW0/t0OnudwZPvTDu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$18Nk347iqsOy8xWCKuEbxOVIGWsi1wilbVjhR1oPGomSIxmIyyldW");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 1,
                column: "Location",
                value: "Tp. HCM");

            migrationBuilder.UpdateData(
                table: "Shelters",
                keyColumn: "Id",
                keyValue: 2,
                column: "Location",
                value: "Ha Noi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$6Df9REFMYfzXf.pCDHLCz.zFdbYkCoYEsNWPCzN8RirJAOtEvEoNe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$Lw./lyBFXqte0hmPbaxeruBqDnAbH4sxQ8P681M6JH6lKYypWzwqW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Vvg/B6pcanQrp9U1SI.20uw1q.GuqBNANDjbC0Sk4W0kXri0i8eBW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$GYiaq6UcFBUqZMfcKXMOf.Y3dwCOcAjKrS969xnstnGHEpdX99yIq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$duT5XcZhr7NoSoylWmFxCugPOZew95DLb4ZVp1TtLzbErHr.xqTGO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$FAZUVtHDawaY/3JtFy8kve0AWJCBCzy0XB7oo48vTPat3cUC.lc7O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$wHhdHos4n.uroORcs5RsmO.dQO/gD0irtiFaQCbDhG//GMfKfpOJ2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$I/UxYH77SZ6VzFhSlCsyR.n3rQS4rY1FQj3r2oKtClasmMYySVWPe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$T.npYc.k3b0wmwwf06xSJOcm/NRmhnqbN77eTkAaTYzc9u8wud05C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$tKLrM7SXyYWq.dOCosSr/.XfHHuJCxVzfwZ094XqbhC0mXCkjwcw.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$I5TSBc7ridTuZ1ngczmRNu0MZWBarqnQxdWDSDSw/LCqKtDJi68PC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$u.lYCJ6Sgq7jhMqkBphcheGEH3SjbxM98Kk2I/VpNppylDcApQCPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$77V8Kurtw5pSjT.MMo.JlODaEEOoSgBYFDfnWdWvGJxKdmJg0NsvO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$XIcra6blDRFQNQQSntLTTevsCDe7YGRcJx3yj6SQlyvSCrxEwpG7i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$.5p.FIzfjV/iiE/lf8FnjuEM76P2eK.hZbQzQjSUwLj61ipg8j30C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$GormX4h1yPq4y/Mfy7KLJel/LYKhokJgQQGT2d5rqiIsfB2T0VASu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$sN4d/M9akZre4pK3ahA3xu87ZBtwmn4oX6C7epU1nlbjpHxYghZwS");
        }
    }
}
