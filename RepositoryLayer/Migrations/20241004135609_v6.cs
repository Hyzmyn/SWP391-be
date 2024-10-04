using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRegistrationForm_Pets_PetId",
                table: "AdoptionRegistrationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_AdoptionRegistrationForm_Users_UserId",
                table: "AdoptionRegistrationForm");

            migrationBuilder.DropForeignKey(
                name: "FK_Certification_Pets_PetId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Certification_Users_ShelterStaffId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_Certification_Users_UserId",
                table: "Certification");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Events_EventId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUser_Users_UserId",
                table: "EventUser");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Post_PostId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Pets_PetId",
                table: "Post");

            migrationBuilder.DropForeignKey(
                name: "FK_Post_Users_UserId",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Post",
                table: "Post");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUser",
                table: "EventUser");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certification",
                table: "Certification");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AdoptionRegistrationForm",
                table: "AdoptionRegistrationForm");

            migrationBuilder.RenameTable(
                name: "Post",
                newName: "Posts");

            migrationBuilder.RenameTable(
                name: "EventUser",
                newName: "EventUsers");

            migrationBuilder.RenameTable(
                name: "Certification",
                newName: "Certifications");

            migrationBuilder.RenameTable(
                name: "AdoptionRegistrationForm",
                newName: "Forms");

            migrationBuilder.RenameIndex(
                name: "IX_Post_UserId",
                table: "Posts",
                newName: "IX_Posts_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Post_PetId",
                table: "Posts",
                newName: "IX_Posts_PetId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_UserId",
                table: "EventUsers",
                newName: "IX_EventUsers_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUser_EventId",
                table: "EventUsers",
                newName: "IX_EventUsers_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Certification_UserId",
                table: "Certifications",
                newName: "IX_Certifications_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Certification_ShelterStaffId",
                table: "Certifications",
                newName: "IX_Certifications_ShelterStaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Certification_PetId",
                table: "Certifications",
                newName: "IX_Certifications_PetId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionRegistrationForm_UserId",
                table: "Forms",
                newName: "IX_Forms_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AdoptionRegistrationForm_PetId",
                table: "Forms",
                newName: "IX_Forms_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Posts",
                table: "Posts",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUsers",
                table: "EventUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Forms",
                table: "Forms",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "SmsMessages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    To = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    From = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsMessages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$KCtwdIF3L5YNmLQHLEZoBeUsk1UG.Mtpsbx0weAlMRpbCiVXUEzvW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$46nXei8Jtm/dwleC.2slhu6Gu.1SIWrSKFKiXHlS7wiQQU7nSWmpq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$Dwe.2zFcmGt0dNUeh7hDAui06cygYkfXZgaBLgLpQMcxQ3chVWrPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$hZn4GmUckWIs5t.YkWwBoOvq7DBbBW5Jw17rpgdPZLXAynuAqjO9K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$wwtMgLdErM5ks26R3XjVcuCfsFd7hwy8ddPNYRsTf3MZRuNFICHci");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$ri18IXLlwqPGD0tVzzxCz.F1mnPzwLzdqodjERA7KLXodR5MmpC96");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$n9Y7GS.FJiB.O3JD8oVSy.dKJMSv2ijDGkzaGSIEgRZPY942jPaN2");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$hSUEUJUNZd5mtlzLoDX8uuljegXzoNmpFj7QW6W0UcmASj0ZWD16q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$QKyqZ.YnE0az8XIDrar5ouYqEcE7C3KoA66guqxjNYOeZv3psRRJS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$0gDe09VMFaGxHSt.qh9I8el4Ah/xnFpZxqoxDUO41.NGF1aI97/V.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$w/7eRcBGDvdC25Y1gufFUefZcMu3NTGK5OYsPPB6ODaMmoRDw9eYa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$YkccyHeWTrSQyMSBgCqM5eJf2jf4R9wkdf15eh/Cs1QvQ9Y9oD6tS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$5wSEwig0F9McoVYNY/ZMIuAe3Pm1QMOiaJ.BO382PCyaWAxBkIoz.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$R3Rmd/5EzsOH2.nNxS6iqOEGWe2erJhGesDJxF/lHiIWK6u7P3emm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$mmwei.TxcXYWtkUSUrOpg.rMpvTGtnHa/dD9PnqiaJtUuZiHlrwdK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$PmXwZgoyFSpL4mdvzHFrb.vrsuMvgU5oUoICeU6XnYnNF219DZ1V.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$QBKdpBk.nhVsHkhHDOlbAeEYOQxN2YqN8P.v66D1Kf/GQk6Sq8TJe");

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Pets_PetId",
                table: "Certifications",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Users_ShelterStaffId",
                table: "Certifications",
                column: "ShelterStaffId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Certifications_Users_UserId",
                table: "Certifications",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUsers_Events_EventId",
                table: "EventUsers",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUsers_Users_UserId",
                table: "EventUsers",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Posts_PostId",
                table: "FeedBacks",
                column: "PostId",
                principalTable: "Posts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Pets_PetId",
                table: "Forms",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Forms_Users_UserId",
                table: "Forms",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Pets_PetId",
                table: "Posts",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Pets_PetId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Users_ShelterStaffId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_Certifications_Users_UserId",
                table: "Certifications");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUsers_Events_EventId",
                table: "EventUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_EventUsers_Users_UserId",
                table: "EventUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_FeedBacks_Posts_PostId",
                table: "FeedBacks");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Pets_PetId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Forms_Users_UserId",
                table: "Forms");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Pets_PetId",
                table: "Posts");

            migrationBuilder.DropForeignKey(
                name: "FK_Posts_Users_UserId",
                table: "Posts");

            migrationBuilder.DropTable(
                name: "SmsMessages");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Posts",
                table: "Posts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Forms",
                table: "Forms");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EventUsers",
                table: "EventUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Certifications",
                table: "Certifications");

            migrationBuilder.RenameTable(
                name: "Posts",
                newName: "Post");

            migrationBuilder.RenameTable(
                name: "Forms",
                newName: "AdoptionRegistrationForm");

            migrationBuilder.RenameTable(
                name: "EventUsers",
                newName: "EventUser");

            migrationBuilder.RenameTable(
                name: "Certifications",
                newName: "Certification");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_UserId",
                table: "Post",
                newName: "IX_Post_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Posts_PetId",
                table: "Post",
                newName: "IX_Post_PetId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_UserId",
                table: "AdoptionRegistrationForm",
                newName: "IX_AdoptionRegistrationForm_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Forms_PetId",
                table: "AdoptionRegistrationForm",
                newName: "IX_AdoptionRegistrationForm_PetId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUsers_UserId",
                table: "EventUser",
                newName: "IX_EventUser_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_EventUsers_EventId",
                table: "EventUser",
                newName: "IX_EventUser_EventId");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_UserId",
                table: "Certification",
                newName: "IX_Certification_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_ShelterStaffId",
                table: "Certification",
                newName: "IX_Certification_ShelterStaffId");

            migrationBuilder.RenameIndex(
                name: "IX_Certifications_PetId",
                table: "Certification",
                newName: "IX_Certification_PetId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Post",
                table: "Post",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AdoptionRegistrationForm",
                table: "AdoptionRegistrationForm",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EventUser",
                table: "EventUser",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Certification",
                table: "Certification",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$y1Uq09htuNLJwFW7EQ26IehWbL56a22TkUu.oWKZbpoSt6M3FJXkK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$eZLfw83TkLFvZom69ibiRuUZefe94ljS/eACXWTTAfC8twaFeuHby");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$VEv5Brj3JIzSQbwbMlcGp.NjS3/34IYcGt9gyFs9umqn4EbQNN9gK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$Keku.3e5RMnbzNqkMNDXaueDI4Z3rbnfZgVWQ4hOH21wEt6r3pMhe");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$6nroAxNlKJ/feSldrc8oBOeOamNdtpigHKQjcQF2PYtrM.7p6WqGK");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$y14PLYRSyyJShOwx/vKekuFBFyn5frPXQ/jzJ15vLYhS0OzF5.Zxq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$L/5nOLxpJjRg2lLj4FwJG.MdJbKR09fyZ3.HtZ7n26KJf2c55HdZG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$rriA6KDZ8JR/gZN.fV1zM.mjjV8wkp5FuK3EUTG2wZeqFgeNDwcXa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$DlZAlBqbP5vSADlgqg5zyuL4Bf3dgXrBVKqD/uDlq2cOARDiXoNwi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$KQ3WXhy.Xnsmc/VdYbLiq.mkYHdQr49wz7e6fhSqythw1ZYJM3tEi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$P1rox/ZUDKG.EeWyvlVoLexyloXKrwr1YDaJBiEr3Co0HuBmIwawa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$SYkHoYKCZsgHYl9ra4N77eU3I1l7fOjo9g4XnAreJ92is48gpQPT6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$WjXnwQQl/68CxrUfdqn3UeBnvTqWIBZrbCmN8NPvae1HLdo1tNu9i");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$cxAm0gU2Tx5KoIN7mi/QWeqQYWLPkPd4BX/zExeX9pMQrPoGWPN.q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$8DOcl5KY2hfwWRM4g2pY.OkR.03gXZwH2Hs46EzGe/ilG6cYQOiHG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$GcHT7AvEKsTtBkPmE9jIwe4vywP735TBJmI85JdmDReBQP9ru9gGa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$5ObVfAJzwoxIJhvHilZl0OlfaCNFrgUKjza6MG3JjpcDuxmtiQypq");

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRegistrationForm_Pets_PetId",
                table: "AdoptionRegistrationForm",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AdoptionRegistrationForm_Users_UserId",
                table: "AdoptionRegistrationForm",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Certification_Pets_PetId",
                table: "Certification",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Events_EventId",
                table: "EventUser",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EventUser_Users_UserId",
                table: "EventUser",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FeedBacks_Post_PostId",
                table: "FeedBacks",
                column: "PostId",
                principalTable: "Post",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Pets_PetId",
                table: "Post",
                column: "PetId",
                principalTable: "Pets",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Post_Users_UserId",
                table: "Post",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
