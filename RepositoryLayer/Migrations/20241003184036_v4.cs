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
                name: "FK_Post_Pets_PetId",
                table: "Post");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Statuses");

            migrationBuilder.RenameColumn(
                name: "Image",
                table: "AdoptionRegistrationForm",
                newName: "SocialAccount");

            migrationBuilder.RenameColumn(
                name: "IdentityProof",
                table: "AdoptionRegistrationForm",
                newName: "IdentificationImageBackSide");

            migrationBuilder.RenameColumn(
                name: "Condition",
                table: "AdoptionRegistrationForm",
                newName: "IdentificationImage");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Post",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$TpT0lpwOZPN4cRu46GYtWu/9L7t1p7zfpQzMSu6vI/nkYplevbNMK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$WggndBR.hTq0Twe6cPuix.vI33.bXJvZQtznnWtbrzEswyXzqEqWi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$8OF3WHMD1pbcY24IlfT4t.jSYn5iIRHbQBct8Ty3OZ8RFf1B8bnym");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$n.mAo/07cY8wHMtJxegkVuZKj8IO0gw27f1rKwUD0C85lKVWgVQbC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$1Ub.LACBcTjRQvwkCzlPjetJ4pchyCqlbTR1s3atrPNBJNlsQAuCS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$aCCX5QY0BljcBYrnHgHFcuQcvliQmvY6aOcKl0SZRB22hRoNCznbC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$oGIxi9RF.VqppINdcdKfee8WPSVpaRAYjapvFDAqsq7/Mb5kOYfo.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$RsdHdoD3jx7C8Dh8WobMB.WHrFY54UbARc04EJ/NhITFuT5pwjQrm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$yL98zXw5eFM8OyEvUVOCNuSi8XUxg7n7i1CL67gA5p1ud1KtnKrXq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$F3Ll9mzjdJUp9d1M4zQxxukIREhkN9cAeEE5SMYg6iDKDSZ/f8lWC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$AIjBjbrrnlUR4CmvaRx6D.1FgsvPt4U118CmTEXOakwwzieTS2e3G");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$mtrOfpRahJPTIpHZm1RYP.kbBddTHa/RbAr8ST5CtkKPr/fJump.C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$Lo3P1zkS3PvpMln.Bsf2vezYiiKCAZ7XxV2Q1O0qSii1QA9sqwRm.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$KSWaVKZZMHg8QCK3fpgCBegHF7ZvFFwL0zO2HLCwT7puKJMqf5BiK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$xpg4w4zX38TpdqDmb9Q4eO98PD5LymXjZRLy2jW0FhsoMxzpqv8Ni");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$VAyT.dxONgbE388I7HeuJ.KJJUCgeBj6pYFYpd/bgWNTdOxh9iRMu");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$wWKJIS09fPDKM/J3dMOEReP9ap22Djn7llBedFdjK8NzAhNCtgyqO");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Pets_PetId",
                table: "Post",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Post_Pets_PetId",
                table: "Post");

            migrationBuilder.RenameColumn(
                name: "SocialAccount",
                table: "AdoptionRegistrationForm",
                newName: "Image");

            migrationBuilder.RenameColumn(
                name: "IdentificationImageBackSide",
                table: "AdoptionRegistrationForm",
                newName: "IdentityProof");

            migrationBuilder.RenameColumn(
                name: "IdentificationImage",
                table: "AdoptionRegistrationForm",
                newName: "Condition");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Statuses",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AlterColumn<int>(
                name: "PetId",
                table: "Post",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Canine Parvovirus");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Canine Distemper");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Rabies");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Feline Leukemia Virus");

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Feline Immunodeficiency Virus");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Pets_PetId",
                table: "Post",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
