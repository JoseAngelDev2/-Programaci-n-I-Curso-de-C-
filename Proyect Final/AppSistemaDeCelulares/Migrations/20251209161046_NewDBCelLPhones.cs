using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AppSistemaDeCelulares.Migrations
{
    /// <inheritdoc />
    public partial class NewDBCelLPhones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Address = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: true),
                    DateRegister = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Parts",
                columns: table => new
                {
                    PartId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    StockQuantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Parts", x => x.PartId);
                });

            migrationBuilder.CreateTable(
                name: "Technicians",
                columns: table => new
                {
                    TechnicianId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(45)", maxLength: 45, nullable: false),
                    Specialty = table.Column<string>(type: "nvarchar(85)", maxLength: 85, nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Technicians", x => x.TechnicianId);
                });

            migrationBuilder.CreateTable(
                name: "PhoneDevices",
                columns: table => new
                {
                    PhoneDeviceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brand = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Model = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    IMEI = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    CheckInDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PhoneDevices", x => x.PhoneDeviceId);
                    table.ForeignKey(
                        name: "FK_PhoneDevices_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Deliveries",
                columns: table => new
                {
                    DeliveryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneDeviceId = table.Column<int>(type: "int", nullable: false),
                    DeliveryDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    TotalAmount = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Notes = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deliveries", x => x.DeliveryId);
                    table.ForeignKey(
                        name: "FK_Deliveries_PhoneDevices_PhoneDeviceId",
                        column: x => x.PhoneDeviceId,
                        principalTable: "PhoneDevices",
                        principalColumn: "PhoneDeviceId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Diagnostics",
                columns: table => new
                {
                    DiagnosisId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneDeviceId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(180)", maxLength: 180, nullable: false),
                    Date = table.Column<DateTime>(type: "datetime", nullable: false),
                    EstimatedCost = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnostics", x => x.DiagnosisId);
                    table.ForeignKey(
                        name: "FK_Diagnostics_PhoneDevices_PhoneDeviceId",
                        column: x => x.PhoneDeviceId,
                        principalTable: "PhoneDevices",
                        principalColumn: "PhoneDeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Diagnostics_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Repairs",
                columns: table => new
                {
                    RepairId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PhoneDeviceId = table.Column<int>(type: "int", nullable: false),
                    TechnicianId = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    LaborCost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Repairs", x => x.RepairId);
                    table.ForeignKey(
                        name: "FK_Repairs_PhoneDevices_PhoneDeviceId",
                        column: x => x.PhoneDeviceId,
                        principalTable: "PhoneDevices",
                        principalColumn: "PhoneDeviceId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Repairs_Technicians_TechnicianId",
                        column: x => x.TechnicianId,
                        principalTable: "Technicians",
                        principalColumn: "TechnicianId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RepairDetails",
                columns: table => new
                {
                    RepairDetailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RepairId = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(80)", maxLength: 80, nullable: false),
                    PartId = table.Column<int>(type: "int", nullable: true),
                    Cost = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DiagnosticDiagnosisId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairDetails", x => x.RepairDetailId);
                    table.ForeignKey(
                        name: "FK_RepairDetails_Diagnostics_DiagnosticDiagnosisId",
                        column: x => x.DiagnosticDiagnosisId,
                        principalTable: "Diagnostics",
                        principalColumn: "DiagnosisId");
                    table.ForeignKey(
                        name: "FK_RepairDetails_Parts_PartId",
                        column: x => x.PartId,
                        principalTable: "Parts",
                        principalColumn: "PartId");
                    table.ForeignKey(
                        name: "FK_RepairDetails_Repairs_RepairId",
                        column: x => x.RepairId,
                        principalTable: "Repairs",
                        principalColumn: "RepairId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Deliveries_PhoneDeviceId",
                table: "Deliveries",
                column: "PhoneDeviceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostics_PhoneDeviceId",
                table: "Diagnostics",
                column: "PhoneDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Diagnostics_TechnicianId",
                table: "Diagnostics",
                column: "TechnicianId");

            migrationBuilder.CreateIndex(
                name: "IX_PhoneDevices_CustomerId",
                table: "PhoneDevices",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairDetails_DiagnosticDiagnosisId",
                table: "RepairDetails",
                column: "DiagnosticDiagnosisId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairDetails_PartId",
                table: "RepairDetails",
                column: "PartId");

            migrationBuilder.CreateIndex(
                name: "IX_RepairDetails_RepairId",
                table: "RepairDetails",
                column: "RepairId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_PhoneDeviceId",
                table: "Repairs",
                column: "PhoneDeviceId");

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_TechnicianId",
                table: "Repairs",
                column: "TechnicianId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Deliveries");

            migrationBuilder.DropTable(
                name: "RepairDetails");

            migrationBuilder.DropTable(
                name: "Diagnostics");

            migrationBuilder.DropTable(
                name: "Parts");

            migrationBuilder.DropTable(
                name: "Repairs");

            migrationBuilder.DropTable(
                name: "PhoneDevices");

            migrationBuilder.DropTable(
                name: "Technicians");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
