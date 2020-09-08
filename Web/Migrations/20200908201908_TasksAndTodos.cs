using Microsoft.EntityFrameworkCore.Migrations;

namespace Web.Migrations
{
  public partial class TasksAndTodos : Migration
  {
    protected override void Up(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.CreateTable(
          name: "Tasks",
          columns: table => new
          {
            Id = table.Column<string>(nullable: false),
            Name = table.Column<string>(nullable: true),
            UserId = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Tasks", x => x.Id);
            table.ForeignKey(
                      name: "FK_Tasks_Users_UserId",
                      column: x => x.UserId,
                      principalTable: "Users",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateTable(
          name: "Todos",
          columns: table => new
          {
            Id = table.Column<string>(nullable: false),
            Name = table.Column<string>(nullable: true),
            Description = table.Column<string>(nullable: true),
            IsComplete = table.Column<bool>(nullable: false),
            TaskId = table.Column<string>(nullable: true)
          },
          constraints: table =>
          {
            table.PrimaryKey("PK_Todos", x => x.Id);
            table.ForeignKey(
                      name: "FK_Todos_Tasks_TaskId",
                      column: x => x.TaskId,
                      principalTable: "Tasks",
                      principalColumn: "Id",
                      onDelete: ReferentialAction.Restrict);
          });

      migrationBuilder.CreateIndex(
          name: "IX_Tasks_UserId",
          table: "Tasks",
          column: "UserId");

      migrationBuilder.CreateIndex(
          name: "IX_Todos_TaskId",
          table: "Todos",
          column: "TaskId");
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
      migrationBuilder.DropTable(
          name: "Todos");

      migrationBuilder.DropTable(
          name: "Tasks");
    }
  }
}
