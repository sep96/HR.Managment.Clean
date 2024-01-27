using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HR.Managment.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class inimigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LeaveTypes",
                columns: table => new
                {
                    LeaveTypesID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveTypesName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveTypesDefaultDays = table.Column<int>(type: "int", nullable: false),
                    CreateionUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveTypes", x => x.LeaveTypesID);
                });

            migrationBuilder.CreateTable(
                name: "LeaveAllocations",
                columns: table => new
                {
                    LeaveAllocationID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveAllocationnumberOfDay = table.Column<int>(type: "int", nullable: false),
                    LeaveTypesID = table.Column<int>(type: "int", nullable: false),
                    LeaveAllocationPeriod = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreateionUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveAllocations", x => x.LeaveAllocationID);
                    table.ForeignKey(
                        name: "FK_LeaveAllocations_LeaveTypes_LeaveTypesID",
                        column: x => x.LeaveTypesID,
                        principalTable: "LeaveTypes",
                        principalColumn: "LeaveTypesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LeaveRequests",
                columns: table => new
                {
                    LeaveRequestID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LeaveRequestStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveRequestEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveTypesID = table.Column<int>(type: "int", nullable: false),
                    LeaveRequestDateRequested = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LeaveRequestRequestComments = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LeaveRequestApproved = table.Column<bool>(type: "bit", nullable: true),
                    LeaveRequestCancelled = table.Column<bool>(type: "bit", nullable: false),
                    CreateionUserID = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreationDateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDateTime = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LeaveRequests", x => x.LeaveRequestID);
                    table.ForeignKey(
                        name: "FK_LeaveRequests_LeaveTypes_LeaveTypesID",
                        column: x => x.LeaveTypesID,
                        principalTable: "LeaveTypes",
                        principalColumn: "LeaveTypesID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LeaveAllocations_LeaveTypesID",
                table: "LeaveAllocations",
                column: "LeaveTypesID");

            migrationBuilder.CreateIndex(
                name: "IX_LeaveRequests_LeaveTypesID",
                table: "LeaveRequests",
                column: "LeaveTypesID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LeaveAllocations");

            migrationBuilder.DropTable(
                name: "LeaveRequests");

            migrationBuilder.DropTable(
                name: "LeaveTypes");
        }
    }
}
