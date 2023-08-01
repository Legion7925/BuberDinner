using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BubberDinner.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class hostconf : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hosts",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProfileImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AverageRating_Value = table.Column<float>(type: "real", nullable: false),
                    AverageRating_NumRatings = table.Column<int>(type: "int", nullable: false),
                    CreatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Hosts_DinnerIds",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DinnerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hosts_DinnerIds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Hosts_DinnerIds_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MenuId",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    HostMenuId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    HostId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MenuId", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MenuId_Hosts_HostId",
                        column: x => x.HostId,
                        principalTable: "Hosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Hosts_DinnerIds_HostId",
                table: "Hosts_DinnerIds",
                column: "HostId");

            migrationBuilder.CreateIndex(
                name: "IX_MenuId_HostId",
                table: "MenuId",
                column: "HostId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Hosts_DinnerIds");

            migrationBuilder.DropTable(
                name: "MenuId");

            migrationBuilder.DropTable(
                name: "Hosts");
        }
    }
}
