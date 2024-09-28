using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace RepositoryLayer.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase()
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Shelters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PhoneNumber = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Capaxity = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DonationAmount = table.Column<decimal>(type: "decimal(16,4)", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalDonation = table.Column<decimal>(type: "decimal(16,4)", nullable: true),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    RoleId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(16,4)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Donations_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Donations_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Notifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Pets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    ShelterID = table.Column<int>(type: "int", nullable: false),
                    UserID = table.Column<int>(type: "int", nullable: true),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Type = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Breed = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Gender = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Age = table.Column<int>(type: "int", nullable: true),
                    Size = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Color = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Description = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdoptionStatus = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    StatusId = table.Column<int>(type: "int", nullable: true),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pets_Shelters_ShelterID",
                        column: x => x.ShelterID,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pets_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Post", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Post_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "ShelterStaffs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelterStaffs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShelterStaffs_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ShelterStaffs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "UserRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRole_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRole_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventUser_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventUser_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "AdoptionRegistrationForm",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    IdentityProof = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IncomeAmount = table.Column<decimal>(type: "decimal(16,4)", nullable: false),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Condition = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdopterId = table.Column<int>(type: "int", nullable: false),
                    ShelterStaffId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdoptionRegistrationForm", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdoptionRegistrationForm_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AdoptionRegistrationForm_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Certification",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Desciption = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certification", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certification_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certification_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Disease = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vaccine = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    PetId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statuses_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedBacks_Post_PostId",
                        column: x => x.PostId,
                        principalTable: "Post",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "Name", "Status" },
                values: new object[,]
                {
                    { 1, "Admin", null },
                    { 2, "ShelterStaff", null },
                    { 3, "Donor", null },
                    { 4, "Volunteer", null },
                    { 5, "Adopter", null }
                });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Capaxity", "DonationAmount", "Email", "Location", "Name", "PhoneNumber", "Status", "Website" },
                values: new object[,]
                {
                    { 1, 20, null, "PetShelter1@email.com", "Tp. HCM", "Shelter1", "1234567890", null, null },
                    { 2, 20, null, "PetShelter2@email.com", "Ha Noi", "Shelter2", "0987654321", null, null }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Image", "Location", "Password", "Phone", "RoleId", "Status", "Token", "TotalDonation", "Username" },
                values: new object[,]
                {
                    { 1, "Admin@email.com", null, null, "$2a$11$Igil46NwzpLUr6WWRa1U1.c9NjRdiMey.j6ZJB.CLimq21aUnwr6a", null, null, null, null, null, "Admin" },
                    { 2, "Admin@email.com", null, null, "$2a$11$mmFy78YeO256a278wa4kUe6deWmoGJulLh7uEu/kkr/SR6aAS/upO", null, null, null, null, null, "Staff1" },
                    { 3, "Admin@email.com", null, null, "$2a$11$N3w29krW1jKMT6ZRQfCZfeY5PugvbRou5LuAguOAAadB4MSadGqrW", null, null, null, null, null, "Staff2" },
                    { 4, "Admin@email.com", null, null, "$2a$11$JsLSx/si1CK2YEiP2MtxQuoXL2G9PUMiFZnVDlJ57dNarDIj9FixC", null, null, null, null, null, "Staff3" },
                    { 5, "Admin@email.com", null, null, "$2a$11$rhWE2d73lwIdbAJFAnUSvu68I1PFOMNOqjnnv38pm0cEm0fXgDjXu", null, null, null, null, null, "Staff4" },
                    { 6, "Admin@email.com", null, null, "$2a$11$zWbU8VAvsLXMPIXFVYpBe.2RXEY7mrjoA7ktYOzvwx6ZKwwnMwLFG", null, null, null, null, null, "Donor1" },
                    { 7, "Admin@email.com", null, null, "$2a$11$K9pjzPrP8W0geTU0Cx/Hj.88c1Q3RNkvS/WsYMajrwJ178U3jKu8O", null, null, null, null, null, "Donor2" },
                    { 8, "Admin@email.com", null, null, "$2a$11$dTqw2MqjSgdBLrqsUryB5.qL0DAvauo1yUmSud50cVKJRptYGYkka", null, null, null, null, null, "Donor3" },
                    { 9, "Admin@email.com", null, null, "$2a$11$a1oJoDM3H7MXmgwMwxWmRezT/sK6g4rBytuaNwzr0XMdTGa0c7Jq.", null, null, null, null, null, "Donor4" },
                    { 10, "Admin@email.com", null, null, "$2a$11$Vm06gLFB6AzkDpLdt1K7K.etT9fSZYoyeOUpdRtgx78P/jebkDpc6", null, null, null, null, null, "Volunteer1" },
                    { 11, "Admin@email.com", null, null, "$2a$11$u6lqI6maZgSWrCsQ0U1S1eYJGMBlvqcGp2OFSG/e/1371XTVkjrnC", null, null, null, null, null, "Volunteer2" },
                    { 12, "Admin@email.com", null, null, "$2a$11$BDFh6.GsxIGZFbSf8lzsh.B8/BxoAD/O.jTto.S.dQA.9PpAenAta", null, null, null, null, null, "Volunteer3" },
                    { 13, "Admin@email.com", null, null, "$2a$11$IB0T865NbKP6Haow9F5bXuQ5XFSK9Gxn6PsZyEXSuhLNtWmNbzyZi", null, null, null, null, null, "Volunteer4" },
                    { 14, "Admin@email.com", null, null, "$2a$11$HgQzAbdRWFbZvNLRVy4WR.Qquf7LJV3vvm4vElsv2ouUZHV0MBtrG", null, null, null, null, null, "Adopter1" },
                    { 15, "Admin@email.com", null, null, "$2a$11$GrA0aDn2fnd1nvwsrY3HSOYLWvgtf0AYBsNkspYdUHWkIdhsq9gVi", null, null, null, null, null, "Adopter2" },
                    { 16, "Admin@email.com", null, null, "$2a$11$OhXN9xviW3TTLsCGITKEweCijHJHeM/RVCG4e0yT8CCMSemnACRta", null, null, null, null, null, "Adopter3" },
                    { 17, "Admin@email.com", null, null, "$2a$11$45P9P8lUoQGS7hAr8sbLPOyOnrsVH43ngfeBPFOZGG4ItzeS.T2b.", null, null, null, null, null, "Adopter4" }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "Age", "Breed", "Color", "Description", "Gender", "Image", "Name", "ShelterID", "Size", "Status", "StatusId", "Type", "UserID" },
                values: new object[,]
                {
                    { 1, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Dog", null },
                    { 2, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Cat", null },
                    { 3, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Dog", null },
                    { 4, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Cat", null },
                    { 5, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Dog", null },
                    { 6, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Cat", null },
                    { 7, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Dog", null },
                    { 8, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Cat", null },
                    { 9, null, null, null, null, null, null, null, "Pet", 1, null, null, null, "Dog", null },
                    { 10, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Cat", null },
                    { 11, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Dog", null },
                    { 12, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Cat", null },
                    { 13, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Dog", null },
                    { 14, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Cat", null },
                    { 15, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Dog", null },
                    { 16, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Cat", null },
                    { 18, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Dog", null },
                    { 19, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Dog", null },
                    { 20, null, null, null, null, null, null, null, "Pet", 2, null, null, null, "Dog", null }
                });

            migrationBuilder.InsertData(
                table: "ShelterStaffs",
                columns: new[] { "Id", "ShelterId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, 2 },
                    { 2, 1, null, 3 },
                    { 3, 2, null, 4 },
                    { 4, 2, null, 5 }
                });

            migrationBuilder.InsertData(
                table: "UserRole",
                columns: new[] { "Id", "RoleId", "Status", "UserId" },
                values: new object[,]
                {
                    { 1, 1, null, 1 },
                    { 2, 2, null, 2 },
                    { 3, 2, null, 3 },
                    { 4, 2, null, 4 },
                    { 5, 2, null, 5 },
                    { 6, 3, null, 6 },
                    { 7, 3, null, 7 },
                    { 8, 3, null, 8 },
                    { 9, 3, null, 9 },
                    { 10, 4, null, 10 },
                    { 11, 4, null, 11 },
                    { 12, 4, null, 12 },
                    { 13, 4, null, 13 },
                    { 14, 5, null, 14 },
                    { 15, 5, null, 15 },
                    { 16, 5, null, 16 },
                    { 17, 5, null, 17 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRegistrationForm_PetId",
                table: "AdoptionRegistrationForm",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AdoptionRegistrationForm_UserId",
                table: "AdoptionRegistrationForm",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Certification_PetId",
                table: "Certification",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certification_UserId",
                table: "Certification",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ShelterId",
                table: "Donations",
                column: "ShelterId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Donations_UserId",
                table: "Donations",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ShelterId",
                table: "Events",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventId",
                table: "EventUser",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_UserId",
                table: "EventUser",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_PostId",
                table: "FeedBacks",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_UserId",
                table: "Notifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_ShelterID",
                table: "Pets",
                column: "ShelterID");

            migrationBuilder.CreateIndex(
                name: "IX_Pets_UserID",
                table: "Pets",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_Post_UserId",
                table: "Post",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterStaffs_ShelterId",
                table: "ShelterStaffs",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelterStaffs_UserId",
                table: "ShelterStaffs",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Statuses_PetId",
                table: "Statuses",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_RoleId",
                table: "UserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRole_UserId",
                table: "UserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdoptionRegistrationForm");

            migrationBuilder.DropTable(
                name: "Certification");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "ShelterStaffs");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "UserRole");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Shelters");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Roles");
        }
    }
}
