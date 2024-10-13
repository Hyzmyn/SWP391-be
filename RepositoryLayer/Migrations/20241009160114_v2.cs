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
            migrationBuilder.AlterColumn<int>(
                name: "ShelterStaffId",
                table: "Forms",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 8,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 9,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 10,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 11,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 12,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 13,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 14,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 15,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 16,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 18,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 19,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 20,
                column: "AdoptionStatus",
                value: "Avalable");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$Ua/87G7AJjH6ED84lsh8OexZqViOz5Bhwzj51q9Rgf47Qoqq5L/l6");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$HJRliw1NarAusxFJXub8..4umcr8d7o0h6r4SJH7g3KneIrEAyBEG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$d7f3DvqM9K7lXp5zLwd2ruGjv6ZOunOaNepyBXb94lsUA4MpGNBSy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$6HYI38Av899uZMP/2NV7HuB0NKL/MpBSZWgFdDG4mKQSKs9s/mNzG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$HFudrqSkBklYawxjsFCBUuBd11leZH8hwWC1rUdC1BBgiszxECpiq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$UX.K6ICT.IdqIN76DUsvLOANhuSniWXdUoUgKl/2vAPXkloJc2Eqi");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$zp36YIo.x2CJTkxOKDFlUu8hPs38T2o3t77BzssDvYO31Fil0Ut8q");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$aaX1DUVMEQ2crLfsZWk7HOER9iNv5KRuyjFEA/7G.x0uqck70xLzm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$64jaquZwk1u79tXgipGYdu9LneTSCuPjMHiEb0t5PUsXgK4TKCbPq");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$pyGpmT8B0Io0xrdUDmNv.Ou1yTejvPJr3mqRT/5jGqRjjICl4yNQ.");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$tIbFC6dy6qHIJshW3F9UD.Ue4i5jgld4NCspyPQxJ5ZrJia5Xb//K");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$cGbM0wTPt3nVanHvQNH6d.UWLkUAgq2zJ6HbQRYK.VIIhEOYji8gy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$xLVv06jSqqTFY8jBAV419.QkOtWUJrdOmugdPTt/mcGkNMLgdqVhO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$xII7FuOSrXCJt3/VrR5kf.58TWzoIcNtPoNSmVr2TInmDPp31YQtC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$SCwBRwr9zNnkWamML0ap6eFgHOohA1Yzs4DwCy8QfTdgbJUBHy/Be");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$yQauwNOu63H7qyDhExS/AOB7HFGVLPmc9ipq6ykwvc46EOnHsLJ1a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$5ufttzgIu2Mgj.RYFj9LPOPHC02O5RKKU3heCKRNO/oswhAWVolE.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ShelterStaffId",
                table: "Forms",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 1,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 2,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 3,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 4,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 5,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 6,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 7,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 8,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 9,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 10,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 11,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 12,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 13,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 14,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 15,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 16,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 18,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 19,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Pets",
                keyColumn: "Id",
                keyValue: 20,
                column: "AdoptionStatus",
                value: null);

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "$2a$11$zDBRHt1qIK9yU6VkGXLiFOdnpd9GRtJ9TZJNtat4JVmm.BdCx5OvS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "$2a$11$NhCrubYH6jdKhDgakl5K4u7PnMXbKPHB6OMnTslthhIj7qJrY3Loa");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "$2a$11$WhCqc4z00B3nZxTLmu9eNes3fSi7C.bYm/pRx4JTHVp8fn/HTRy.a");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 4,
                column: "Password",
                value: "$2a$11$PosCJfUiL1hxTldAWkphIOdgZ2mXIegTWuG4lnSaR0sS7Ppce0soy");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 5,
                column: "Password",
                value: "$2a$11$ZMj4KpQ7PN/0xOxvSom5zeT3CDUVg2MMgw46yxuIsRigPRZicks76");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 6,
                column: "Password",
                value: "$2a$11$tgl.e.qyH42EWwLlG1vhD.FXUxtDUmHRYeb6RhsB/KmWT/GX7QJZC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 7,
                column: "Password",
                value: "$2a$11$8NWTXz/ByRtAS0Lvo6.ygeP.mR5K5hzbGVeH0yUtBLKfm6DrVRPbC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 8,
                column: "Password",
                value: "$2a$11$P.ouah5VHG8kkDI9Pa6WT.5Xw433Ld1ieDboOIHo2Y6YJHXHY0G5O");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 9,
                column: "Password",
                value: "$2a$11$YR/CRLCZN.4v7Vnv7HRp6OpsEjb1/x2DkuEfuAS4fdWyPlqIzBnii");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 10,
                column: "Password",
                value: "$2a$11$bHLFdHDiVlNoAX4/W75piOQmJxQWqiHD6ewnAEW.CaPVMbD3KW4JW");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 11,
                column: "Password",
                value: "$2a$11$qtPDLT50XmDI170Pdrqmf.8HOsntLrU8d3NBOMUf.CmzeKKVD9rlS");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 12,
                column: "Password",
                value: "$2a$11$SP1lEMdb1vpmJ6dEtwx3deSFKDDtemGUHpYSTMddT4ZBzSLHe7imC");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 13,
                column: "Password",
                value: "$2a$11$OYwRJT9rLdp51vtceJab1OYpEeTEmSeunZ1kzobHRvOlwAFLoEsJm");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 14,
                column: "Password",
                value: "$2a$11$tx4i9ohn2kcvKBQCc.2jsO9BKvZLZhimrqylUuW55ChMO9Rfg5smO");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 15,
                column: "Password",
                value: "$2a$11$Yzql66DKakGyqYd/FY9ev.mdlZYVvglggQ24zHDoQ8qwRKKbk5TbG");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 16,
                column: "Password",
                value: "$2a$11$ez/NsI/lROCl20T0awwrZOSNs1QfOJP3rk4Ze5Toqb3EdoARBBZ8S");

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: 17,
                column: "Password",
                value: "$2a$11$KOIliujsHevorNCTkOQ4Hu3LIHEOSN4otsA4MXwaufrPTJ67Z834O");
        }
    }
}
