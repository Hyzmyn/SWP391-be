using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Statuses_Pets_PetId",
                table: "Statuses");

            migrationBuilder.DropIndex(
                name: "IX_Statuses_PetId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "PetId",
                table: "Statuses");

            migrationBuilder.DropColumn(
                name: "StatusId",
                table: "Pets");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Posts",
                type: "datetime(6)",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Posts",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Notifications",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PetStatus",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetStatus", x => new { x.PetId, x.StatusId });
                    table.ForeignKey(
                        name: "FK_PetStatus_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetStatus_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "PetStatus",
                columns: new[] { "PetId", "StatusId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 4 },
                    { 3, 2 },
                    { 4, 5 },
                    { 5, 3 }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_PetStatus_StatusId",
                table: "PetStatus",
                column: "StatusId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PetStatus");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Posts");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Notifications");

            migrationBuilder.AddColumn<int>(
                name: "PetId",
                table: "Statuses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdateDate",
                table: "Posts",
                type: "datetime(6)",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime(6)",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "StatusId",
                table: "Pets",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 8,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 9,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 10,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 11,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 12,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 13,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 14,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 15,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 16,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 18,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 19,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 20,
                column: "StatusId",
                value: null);

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 1,
                column: "PetId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 2,
                column: "PetId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 3,
                column: "PetId",
                value: 5);

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 4,
                column: "PetId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Statuses",
                keyColumn: "Id",
                keyValue: 5,
                column: "PetId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$CbgxKC3XbhXpdkdhWaUhceJ2ecYPtdgx4L.vcazEF4fMaXjjjHvpG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$KqMZeuVhLV/RBRrCNWGAj.Ow7PZOhA6BGjwLmRj/3sPYC9PSnxG0C");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$4PMJIMsPTlTHeXUyJwxsd.EOTTdM/IOPIrVS/sEQAlbWnlUcKwZJ6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Zp9RNaFvYSkGKfXvZxmTeejVIzPmc.NG.Hhv.Jqe6LOz21fDb4yB.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$terg0yGYTmwPjInQBQbnBOdDAp/2GFv56RGAm1B0fZ41IMPIqGkFi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$.SlkZSt2d3JvRABIe7m3cOIuoVA0vsLs2ySIA/xYSwIcsdnLyyJgm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$RJaj74pEBU30NGU1BP.0oO2BHYhAMfLsadldFPXX.WK8iB/pA92Ma");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$0DYpAsK/vHAzWTFN.xZYju1oSzbOH8mekfyoa7zZjrwOaA86zo9o2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$dSf5HOieCKOrIgenQkT8L.wDCP8m3lEe6UaMzJAynkckC7qyKHI8W");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$nU6MXz5w2N6KLcBruePDK.P8jBd0nv1JNNFv87tVzpBSmt3ylFQhe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$ZW3Gfily8GRY8F.Oy9SxT.vBtTQjwcWc.9BVTdJfN66aPhh7JoYC2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$CwU7PoT.XZ2PPNQGJc203esyZkM00YTzP9.7Uqhm.JHNo14seLHXK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$4vljYf8KOxvudirOt0NGGO00C7UHx7rjHKzGonHqGwgLitRICz4/i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$7MU1QvhZIo1EiuhTJN63AeZIA5xYER.5eeX.eulOnMZ3T6478Rdru");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$zRlUt5evu2IZN0Svmz6VrO2sgudZ9BB9dh7Jwbu.Z6469784TsflG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$Zck8oAiKjmC5E6BEclyjse1fbQ1Cn2xa4Y2yw6RdtJfGOauUpbyZy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$yKfbgpKDTOuUzEBBYLRriuImTzhQ8JG6n5MQAxTl.oNrllg0vMTAa");

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_PetId",
                table: "Statuses",
                column: "PetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Statuses_Pets_PetId",
                table: "Statuses",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
