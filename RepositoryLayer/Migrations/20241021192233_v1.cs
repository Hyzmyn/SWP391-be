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
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
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
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Website = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    DonationAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Shelters", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SmsMessages", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Statuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Disease = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Vaccine = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statuses", x => x.Id);
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
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
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
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Username = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "varchar(255)", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Password = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Phone = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Location = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Token = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    TotalDonation = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    wallet = table.Column<decimal>(type: "decimal(18,4)", nullable: true),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    ShelterId = table.Column<int>(type: "int", nullable: true),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Shelters_ShelterId",
                        column: x => x.ShelterId,
                        principalTable: "Shelters",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Donations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Amount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    DonorId = table.Column<int>(type: "int", nullable: false),
                    ShelterId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
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
                        name: "FK_Donations_Users_DonorId",
                        column: x => x.DonorId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "EventUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    EventId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventUser", x => new { x.UserId, x.EventId });
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
                name: "Notifications",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Message = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
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
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
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
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Certifications",
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
                    ShelterStaffId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Certifications", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Certifications_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Certifications_Users_ShelterStaffId",
                        column: x => x.ShelterStaffId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Certifications_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Forms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    SocialAccount = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IncomeAmount = table.Column<decimal>(type: "decimal(18,4)", nullable: false),
                    IdentificationImage = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    IdentificationImageBackSide = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    AdopterId = table.Column<int>(type: "int", nullable: false),
                    ShelterStaffId = table.Column<int>(type: "int", nullable: true),
                    PetId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<bool>(type: "tinyint(1)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Forms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Forms_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Forms_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "PetStatuses",
                columns: table => new
                {
                    PetId = table.Column<int>(type: "int", nullable: false),
                    StatusId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PetStatuses", x => new { x.PetId, x.StatusId });
                    table.ForeignKey(
                        name: "FK_PetStatuses_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PetStatuses_Statuses_StatusId",
                        column: x => x.StatusId,
                        principalTable: "Statuses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Content = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Image = table.Column<string>(type: "longtext", nullable: true)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CreateDate = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime(6)", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PetId = table.Column<int>(type: "int", nullable: true),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_Pets_PetId",
                        column: x => x.PetId,
                        principalTable: "Pets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Posts_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    PostId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Date = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    IsDelete = table.Column<bool>(type: "tinyint(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FeedBacks_Posts_PostId",
                        column: x => x.PostId,
                        principalTable: "Posts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FeedBacks_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "IsDelete", "Name" },
                values: new object[,]
                {
                    { 1, null, "Admin" },
                    { 2, null, "ShelterStaff" },
                    { 3, null, "Donor" },
                    { 4, null, "Volunteer" },
                    { 5, null, "Adopter" }
                });

            migrationBuilder.InsertData(
                table: "Shelters",
                columns: new[] { "Id", "Capacity", "DonationAmount", "Email", "IsDelete", "Location", "Name", "PhoneNumber", "Website" },
                values: new object[,]
                {
                    { 1, 20, null, "PetShelter1@email.com", null, "Quận 1", "Shelter1", "1234567890", null },
                    { 2, 20, null, "PetShelter2@email.com", null, "Bình Dương", "Shelter2", "0987654321", null },
                    { 3, 20, null, "PetShelter3@email.com", null, "Thủ Đức", "Shelter3", "821638713", null },
                    { 4, 20, null, "PetShelter4@email.com", null, "Quận 9", "Shelter4", "8437587353", null }
                });

            migrationBuilder.InsertData(
                table: "Statuses",
                columns: new[] { "Id", "Date", "Disease", "IsDelete", "Vaccine" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Parvovirus Infection", null, "Parvovirus Vaccine" },
                    { 2, new DateTime(2024, 2, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Distemper Virus", null, "Distemper Vaccine" },
                    { 3, new DateTime(2024, 3, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Rabies Virus", null, "Rabies Vaccine" },
                    { 4, new DateTime(2024, 4, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "FeLV", null, "FeLV Vaccine" },
                    { 5, new DateTime(2024, 5, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "FIV", null, "None" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Image", "IsDelete", "Location", "Password", "Phone", "ShelterId", "Status", "Token", "TotalDonation", "Username", "wallet" },
                values: new object[,]
                {
                    { 1, "Admin@email.com", null, null, null, "$2a$11$94ONSiIrc6ZzzgU.YdnuL.UCYT1.EufAhdgnf3qmopJ68Y4x18/vC", null, null, null, null, null, "Admin", null },
                    { 6, "Donor1@email.com", "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "HCM", "$2a$11$.9SltERpYVQGZXiTRl1qze/NrKsfjJSRWu2Ychb02IELh/QzS1svS", "123456789", null, null, null, null, "Donor1", null },
                    { 7, "Donor2@email.com", null, null, null, "$2a$11$p2PukSpo2ZRlg0IPVVNHlON15xDGVZs8goyx1uobupW9KGLpQslL.", null, null, null, null, null, "Donor2", null },
                    { 8, "Donor3@email.com", null, null, null, "$2a$11$Ltc2/xqNyqWnMvc9I5szZuK9K1ZQthJ6gvFqOMP7HM/C1EXMxs25a", null, null, null, null, null, "Donor3", null },
                    { 9, "Donor4@email.com", null, null, null, "$2a$11$Hzw0LQjBcU8nYXARgt.zduCFXAda7Zgg50VAT96uXkM3i2tPLVp8i", null, null, null, null, null, "Donor4", null },
                    { 10, "Volunteer1@email.com", null, null, null, "$2a$11$f4rRCsxAx7q/MzCQa45fM.ELyEPGL5CBAw8q1lZbfoCo2m7OuBsrO", null, null, null, null, null, "Volunteer1", null },
                    { 11, "Volunteer2@email.com", null, null, null, "$2a$11$MSY3uc6pnZzYRC8aiBLHV.RU6oViFeY46uH55d.A0e6Z7vIg7Vv12", null, null, null, null, null, "Volunteer2", null },
                    { 12, "Volunteer3@email.com", null, null, null, "$2a$11$CHKu/wVEISQqTOUiGAvh5OVMDTibcanIKg3GLBkzO0ZPhZXr22Zua", null, null, null, null, null, "Volunteer3", null },
                    { 13, "Volunteer4@email.com", null, null, null, "$2a$11$T8ZdPZU3rQ3E0L.RXufSu.1B/UfiyMgLIGYjOvbPJyFxz3kaRVv66", null, null, null, null, null, "Volunteer4", null },
                    { 14, "Adopter1@email.com", null, null, null, "$2a$11$hc0HY.qGMkoQa98YJ8IY8.sVj3zFbTql.FLbl0S6RVAXMnKfvjdnS", null, null, null, null, null, "Adopter1", null },
                    { 15, "Adopter2@email.com", null, null, null, "$2a$11$WJQL78r1jfluo3ki/LUn3.iW5q64I9MTDWeGkXd.iznyo55pgyWgi", null, null, null, null, null, "Adopter2", null },
                    { 16, "Adopter3@email.com", null, null, null, "$2a$11$7RNadZ3YVMAIxzCXOoHhfuU9802gSPCdSRVEkxXrqt8TZlbRC..MC", null, null, null, null, null, "Adopter3", null },
                    { 17, "Adopter4@email.com", null, null, null, "$2a$11$ZCulH3DNle33uqNZckJQEufGplEOE0NEr4xyYpPUomgPriIZoY3Ui", null, null, null, null, null, "Adopter4", null }
                });

            migrationBuilder.InsertData(
                table: "Donations",
                columns: new[] { "Id", "Amount", "Date", "DonorId", "IsDelete", "ShelterId", "Status" },
                values: new object[,]
                {
                    { 1, 100000m, new DateTime(2024, 1, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 6, null, 1, false },
                    { 2, 200000m, new DateTime(2024, 2, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 1, false },
                    { 3, 543333m, new DateTime(2024, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 8, null, 2, false },
                    { 4, 632229m, new DateTime(2024, 4, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), 9, null, 2, false },
                    { 5, 760000m, new DateTime(2024, 5, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 7, null, 2, false }
                });

            migrationBuilder.InsertData(
                table: "Pets",
                columns: new[] { "Id", "AdoptionStatus", "Age", "Breed", "Color", "Description", "Gender", "Image", "IsDelete", "Name", "ShelterID", "Size", "Type", "UserID" },
                values: new object[,]
                {
                    { 1, "Adopted", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Buddy", 1, null, "Dog", 17 },
                    { 2, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Whiskers", 1, null, "Cat", null },
                    { 3, "Adopted", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Max", 1, null, "Dog", 16 },
                    { 4, "Adopted", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Luna", 1, null, "Cat", 14 },
                    { 5, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Bella", 1, null, "Dog", null },
                    { 6, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Lux", 1, null, "Cat", null },
                    { 7, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Dono", 1, null, "Dog", null },
                    { 8, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Linker", 1, null, "Cat", null },
                    { 9, "Adopted", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Dawin", 1, null, "Dog", 15 },
                    { 10, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Modor", 2, null, "Cat", null },
                    { 11, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Pingking", 2, null, "Dog", null },
                    { 12, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Seto", 2, null, "Cat", null },
                    { 13, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "kaiba", 2, null, "Dog", null },
                    { 14, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Asuka", 2, null, "Cat", null },
                    { 15, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Jax", 2, null, "Dog", null },
                    { 16, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Jihn", 2, null, "Cat", null },
                    { 18, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Kaisa", 2, null, "Dog", null },
                    { 19, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Bump", 2, null, "Dog", null },
                    { 20, "Available", null, null, null, null, null, "https://storage.googleapis.com/pawfund-e7fdd.appspot.com/0a5124ee-0def-454f-bfdb-b652f97acb3d.png", null, "Rasko", 2, null, "Dog", null }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 3, 6 },
                    { 4, 6 },
                    { 3, 7 },
                    { 5, 7 },
                    { 3, 8 },
                    { 4, 8 },
                    { 5, 8 },
                    { 3, 9 },
                    { 3, 10 },
                    { 4, 10 },
                    { 4, 11 },
                    { 5, 11 },
                    { 3, 12 },
                    { 4, 12 },
                    { 5, 12 },
                    { 4, 13 },
                    { 5, 14 },
                    { 3, 15 },
                    { 5, 15 },
                    { 4, 16 },
                    { 5, 16 },
                    { 3, 17 },
                    { 4, 17 },
                    { 5, 17 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Image", "IsDelete", "Location", "Password", "Phone", "ShelterId", "Status", "Token", "TotalDonation", "Username", "wallet" },
                values: new object[,]
                {
                    { 2, "Staff1@email.com", null, null, null, "$2a$11$UX9idfkSkMydugMnhheRReHqwEOUWADWQNUD24nB2zsGLzcI.bBoC", null, 1, null, null, null, "Staff1", null },
                    { 3, "Staff2@email.com", null, null, null, "$2a$11$.g94LmEWv3sLpgmVu6aJHeRG9mdIa7wijyB2h2RecmDsGEJJyDsVW", null, 1, null, null, null, "Staff2", null },
                    { 4, "Staff3@email.com", null, null, null, "$2a$11$7e8uswLe072aqs/gp5EI2OoplSGjB0Tfup/8l8gBYtNuO2AGfYe5m", null, 2, null, null, null, "Staff3", null },
                    { 5, "Staff4@email.com", null, null, null, "$2a$11$GdhmKTTYfTtWu1lM0w1UuO.u.zvTBvEBmsNv9QQ8/6qTGal1I6giq", null, 2, null, null, null, "Staff4", null }
                });

            migrationBuilder.InsertData(
                table: "PetStatuses",
                columns: new[] { "PetId", "StatusId" },
                values: new object[,]
                {
                    { 1, 1 },
                    { 2, 4 },
                    { 3, 2 },
                    { 4, 5 },
                    { 5, 3 }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "RoleId", "UserId" },
                values: new object[,]
                {
                    { 2, 2 },
                    { 2, 3 },
                    { 2, 4 },
                    { 2, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_PetId",
                table: "Certifications",
                column: "PetId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_ShelterStaffId",
                table: "Certifications",
                column: "ShelterStaffId");

            migrationBuilder.CreateIndex(
                name: "IX_Certifications_UserId",
                table: "Certifications",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_DonorId",
                table: "Donations",
                column: "DonorId");

            migrationBuilder.CreateIndex(
                name: "IX_Donations_ShelterId",
                table: "Donations",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ShelterId",
                table: "Events",
                column: "ShelterId");

            migrationBuilder.CreateIndex(
                name: "IX_EventUser_EventId",
                table: "EventUser",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_PostId",
                table: "FeedBacks",
                column: "PostId");

            migrationBuilder.CreateIndex(
                name: "IX_FeedBacks_UserId",
                table: "FeedBacks",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_PetId",
                table: "Forms",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Forms_UserId",
                table: "Forms",
                column: "UserId");

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
                name: "IX_PetStatuses_StatusId",
                table: "PetStatuses",
                column: "StatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_PetId",
                table: "Posts",
                column: "PetId");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_UserId",
                table: "Posts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Users_ShelterId",
                table: "Users",
                column: "ShelterId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Certifications");

            migrationBuilder.DropTable(
                name: "Donations");

            migrationBuilder.DropTable(
                name: "EventUser");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "Forms");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PetStatuses");

            migrationBuilder.DropTable(
                name: "SmsMessages");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Statuses");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Pets");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Shelters");
        }
    }
}
