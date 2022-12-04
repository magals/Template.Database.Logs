using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Template.Database.Logs.DbContexts.SQLite.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogMessageEntity",
                columns: table => new
                {
                    Id = table.Column<long>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    DateTimeOffset = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    LogLevel = table.Column<string>(type: "TEXT", nullable: false),
                    Message = table.Column<string>(type: "TEXT", maxLength: 500, nullable: false),
                    ThreadId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogMessageEntity", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LogMessageEntity",
                columns: new[] { "Id", "DateTimeOffset", "LogLevel", "Message", "ThreadId" },
                values: new object[] { 1L, new DateTimeOffset(new DateTime(2022, 12, 4, 19, 58, 18, 222, DateTimeKind.Unspecified).AddTicks(6946), new TimeSpan(0, 0, 0, 0, 0)), "Information", "First Message", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogMessageEntity");
        }
    }
}
