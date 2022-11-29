using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CommerceProject.Migrations
{
    public partial class ModifyDB : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Donor_1s",
                columns: table => new
                {
                    DonorID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DonorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DonorAmount = table.Column<double>(type: "float", nullable: false),
                    DonorDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaymentMethod = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FundraiserTitle = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Donor_1s", x => x.DonorID);
                });

            migrationBuilder.CreateTable(
                name: "Fundraiser_1s",
                columns: table => new
                {
                    FundraiserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FundraiserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FundraiserDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FundraiserGoal = table.Column<double>(type: "float", nullable: false),
                    FundraiserCurrentAmount = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fundraiser_1s", x => x.FundraiserId);
                });





            migrationBuilder.CreateTable(
                name: "User_1s",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dob = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequrityQuestion1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequrityQuestion2 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SequrityQuestion3 = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_1s", x => x.UserId);
                });

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Donor_1s");



            migrationBuilder.DropTable(
                name: "Fundraiser_1s");



            migrationBuilder.DropTable(
                name: "User_1s");

        }
    }
}
