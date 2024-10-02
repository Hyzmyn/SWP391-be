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
            migrationBuilder.DropTable(
                name: "CertificationUser");

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShelterId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$p8madk40Bgqmtjko.2xOCOvQksbCSjFY1.l2Duxf8UyJ45ORj7MRi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$rVQLtK3rZYrtpbxdNp3k5eqoJIIRImM/2JhiS8N0W3/YbMhOusiam");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$4zpsteZBEVPcgbyceaSa1OjYYhghMB9SWF.NOGqHZYBJWdtclp7x2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$GAUR6nb43S6KrezI8Ag/8ecUNWAdHMiXLrJHBA3FTrd3FIIVL0LM.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$MTLMISjpjSdTLI/zHwaFxOKxMF7Tb.U/C9TNmIxlTy9/tl13tdVqu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$wccZaujNZgEn1oiz5pe8qecVYCGmiYPAYm2g6uELPxahWmLn4cY0.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$44s.RUVQLpqmu1viLQQMTOVLWKVuyV83IHkABHGxPZWfrYmH3Ih9i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$Ss/RBinyDCIqZSDyKWVkieB4xWDJtf3to97ajO4AbjN0C2vbplESq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$FjSWKZS13S/U6.aeBxcd8usy96GdU8Nj6siMivLianYN.OCXyqo/m");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$7Mrk6KOxA0UUMdzSkcLvcOCSo5Y2xFX0kwARXo9w7QHS5nlhqW/U.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$59KXVVGskMGNhWnQ/.ltvOUBuliqhgIOBQED.b79IpqfggM0p3vo6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$qWY8yxfx92YTWJCHI4S/.Ow.HENXquBWKsA54xEwLj5eDA/0rZJzu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$/GZNmVsGIRQ0OvMO32B0EeP3T3e/U1jDbRhWrnrmg4wCPlm8QuvxC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$EYUrjY3Ire5kOGFpNOSQEux4c/GZcRzWfoO0myOEbxHUixuV1HKiG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$O.7wBV4Xc7q4ckc1KA2i7eqEdsvM/aoBN/HBMkmJ7Jhwd2pLUzWZC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$sZ580BWxHo0au1X4XyQ7oejjj9LN9zhM7eKmJXGDmFY1DKFvFauK6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$N5Slf7CfJO.yfWUAjRXTFejJG6c3cq13yQg1br1KTJDLiPI2yGDVS");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_ShelterStaffId",
                table: "Certification",
                column: "ShelterStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_UserId",
                table: "Certification",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_Users_ShelterStaffId",
                table: "Certification",
                column: "ShelterStaffId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_Users_UserId",
                table: "Certification",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certification_Users_ShelterStaffId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Certification_Users_UserId",
                table: "Certification");

            migrationBuilder.DropIndex(
                name: "IX_Certification_ShelterStaffId",
                table: "Certification");

            migrationBuilder.DropIndex(
                name: "IX_Certification_UserId",
                table: "Certification");

            migrationBuilder.CreateTable(
                name: "CertificationUser",
                columns: table => new
                {
                    CertificationsId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CertificationUser", x => new { x.CertificationsId, x.UserId });
                    table.ForeignKey(
                        name: "FK_CertificationUser_Certification_CertificationsId",
                        column: x => x.CertificationsId,
                        principalTable: "Certification",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CertificationUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Donations",
                keyColumn: "Id",
                keyValue: 5,
                column: "ShelterId",
                value: 1);

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
                name: "IX_CertificationUser_UserId",
                table: "CertificationUser",
                column: "UserId");
        }
    }
}
