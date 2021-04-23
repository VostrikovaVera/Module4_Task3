using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Module4_Task3.Migrations
{
    public partial class CreateClientTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClientId",
                table: "Project",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CompanyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    FoundationDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ActvityScope = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Project_ClientId",
                table: "Project",
                column: "ClientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project",
                column: "ClientId",
                principalTable: "Client",
                principalColumn: "ClientId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.Sql(@"
                INSERT INTO Client(CompanyName, IsActive, FoundationDate, ActvityScope) VALUES('Monobank', 'true', CONVERT(DATE, '1994-08-25'), 'Banking')
                INSERT INTO Client(CompanyName, IsActive, FoundationDate, ActvityScope) VALUES('Zoom', 'true', CONVERT(DATE, '2016-01-18'), 'Communications')
                INSERT INTO Client(CompanyName, IsActive, FoundationDate, ActvityScope) VALUES('Pizzeria Neapolitano', 'true', CONVERT(DATE, '2002-02-03'), 'Food')
                INSERT INTO Client(CompanyName, IsActive, FoundationDate, ActvityScope) VALUES('Glovo', 'true', CONVERT(DATE, '2018-10-11'), 'Delivery')
                INSERT INTO Client(CompanyName, IsActive, FoundationDate, ActvityScope) VALUES('Facebook', 'true', CONVERT(DATE, '2008-11-14'), 'Social Networking')

                INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Monobank App', 200000, GETDATE(), 1)
                INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Zoom App', 200000, GETDATE(), 2)
                INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Pizzeria Neapolitano Website', 200000, GETDATE(), 3)
                INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Facebook Website', 500000, GETDATE(), 5)
                INSERT INTO Project(Name, Budget, StartedDate, ClientId) VALUES('Instagram App', 400000, GETDATE(), 5)
            ");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Project_Client_ClientId",
                table: "Project");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropIndex(
                name: "IX_Project_ClientId",
                table: "Project");

            migrationBuilder.DropColumn(
                name: "ClientId",
                table: "Project");
        }
    }
}
