using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ViFit.Infrastructure.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EventLogs",
                columns: table => new
                {
                    AggregateId = table.Column<Guid>(nullable: false),
                    AggregateType = table.Column<string>(nullable: false),
                    Version = table.Column<int>(nullable: false),
                    EventType = table.Column<string>(nullable: false),
                    Data = table.Column<string>(nullable: false),
                    Created = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLogs", x => new { x.AggregateId, x.Version });
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventLogs");
        }
    }
}
