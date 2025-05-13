using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace FancyPower3k.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitFancyPowerDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Size = table.Column<int>(type: "int", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DistributionPanels",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    MaxPowerDelivery = table.Column<double>(type: "float", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DistributionPanels", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DistributionPanels_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JobTitle = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Position = table.Column<int>(type: "int", nullable: false),
                    Salary = table.Column<double>(type: "float", nullable: false),
                    LocationId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Consumers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerConsumption = table.Column<double>(type: "float", nullable: false),
                    MaxConsumption = table.Column<double>(type: "float", nullable: false),
                    DistributionPanelId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ChangedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Consumers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Consumers_DistributionPanels_DistributionPanelId",
                        column: x => x.DistributionPanelId,
                        principalTable: "DistributionPanels",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Address", "ChangedDate", "CreatedDate", "Name", "Size" },
                values: new object[,]
                {
                    { "123e4567-e89b-12d3-a456-426614174000", "123 Toon Town Lane", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Acme Corporation HQ", 5000 },
                    { "123e4567-e89b-12d3-a456-426614174001", "456 Gotham Ave", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Wayne Enterprises", 10000 }
                });

            migrationBuilder.InsertData(
                table: "DistributionPanels",
                columns: new[] { "Id", "ChangedDate", "CreatedDate", "Description", "LocationId", "MaxPowerDelivery", "Name" },
                values: new object[,]
                {
                    { "123e4567-e89b-12d3-a456-426614174002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Primary distribution panel for Gotham", "123e4567-e89b-12d3-a456-426614174001", 10000.0, "Main Panel Gotham" },
                    { "123e4567-e89b-12d3-a456-426614174003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Backup distribution panel for Toon Town", "123e4567-e89b-12d3-a456-426614174000", 5000.0, "Backup Panel Toon" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "ChangedDate", "CreatedDate", "DateOfBirth", "FirstName", "JobTitle", "LastName", "LocationId", "Position", "Salary" },
                values: new object[,]
                {
                    { "123e4567-e89b-12d3-a456-426614174000", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1965, 7, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "CEO", "Johnson", "123e4567-e89b-12d3-a456-426614174000", 5, 101000.0 },
                    { "123e4567-e89b-12d3-a456-426614174001", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1970, 7, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jennifer", "CFO", "Williams", "123e4567-e89b-12d3-a456-426614174000", 2, 101000.0 },
                    { "123e4567-e89b-12d3-a456-426614174002", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1975, 2, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "HRManager", "Miller", "123e4567-e89b-12d3-a456-426614174000", 6, 103000.0 },
                    { "123e4567-e89b-12d3-a456-426614174003", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1996, 9, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jennifer", "Developer", "Johnson", "123e4567-e89b-12d3-a456-426614174001", 0, 80000.0 },
                    { "123e4567-e89b-12d3-a456-426614174004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1981, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "CFO", "Smith", "123e4567-e89b-12d3-a456-426614174000", 1, 52000.0 },
                    { "123e4567-e89b-12d3-a456-426614174005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1964, 3, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jennifer", "CEO", "Davis", "123e4567-e89b-12d3-a456-426614174000", 5, 64000.0 },
                    { "123e4567-e89b-12d3-a456-426614174006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1962, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "HRManager", "Miller", "123e4567-e89b-12d3-a456-426614174000", 1, 51000.0 },
                    { "123e4567-e89b-12d3-a456-426614174007", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1988, 1, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Electrician", "Smith", "123e4567-e89b-12d3-a456-426614174001", 6, 93000.0 },
                    { "123e4567-e89b-12d3-a456-426614174008", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1993, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Electrician", "Smith", "123e4567-e89b-12d3-a456-426614174001", 5, 53000.0 },
                    { "123e4567-e89b-12d3-a456-426614174009", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1975, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", "CEO", "Jones", "123e4567-e89b-12d3-a456-426614174001", 1, 93000.0 },
                    { "123e4567-e89b-12d3-a456-426614174010", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1971, 11, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "HRManager", "Jones", "123e4567-e89b-12d3-a456-426614174001", 0, 138000.0 },
                    { "123e4567-e89b-12d3-a456-426614174011", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1966, 2, 13, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "CEO", "Garcia", "123e4567-e89b-12d3-a456-426614174000", 6, 64000.0 },
                    { "123e4567-e89b-12d3-a456-426614174012", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "HRManager", "Miller", "123e4567-e89b-12d3-a456-426614174001", 5, 78000.0 },
                    { "123e4567-e89b-12d3-a456-426614174013", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1960, 5, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", "Electrician", "Davis", "123e4567-e89b-12d3-a456-426614174000", 1, 76000.0 },
                    { "123e4567-e89b-12d3-a456-426614174014", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 2, 28, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Electrician", "Miller", "123e4567-e89b-12d3-a456-426614174000", 0, 82000.0 },
                    { "123e4567-e89b-12d3-a456-426614174015", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1960, 1, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jennifer", "Accountant", "Rodriguez", "123e4567-e89b-12d3-a456-426614174001", 1, 142000.0 },
                    { "123e4567-e89b-12d3-a456-426614174016", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1985, 8, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "CEO", "Miller", "123e4567-e89b-12d3-a456-426614174000", 1, 52000.0 },
                    { "123e4567-e89b-12d3-a456-426614174017", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1991, 2, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", "Developer", "Wilson", "123e4567-e89b-12d3-a456-426614174001", 2, 105000.0 },
                    { "123e4567-e89b-12d3-a456-426614174018", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1983, 5, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jennifer", "CFO", "Johnson", "123e4567-e89b-12d3-a456-426614174000", 2, 146000.0 },
                    { "123e4567-e89b-12d3-a456-426614174019", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1992, 2, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "Electrician", "Wilson", "123e4567-e89b-12d3-a456-426614174001", 1, 144000.0 },
                    { "123e4567-e89b-12d3-a456-426614174020", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Accountant", "Miller", "123e4567-e89b-12d3-a456-426614174000", 7, 67000.0 },
                    { "123e4567-e89b-12d3-a456-426614174021", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 10, 21, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "CEO", "Davis", "123e4567-e89b-12d3-a456-426614174001", 2, 102000.0 },
                    { "123e4567-e89b-12d3-a456-426614174022", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 3, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", "Developer", "Rodriguez", "123e4567-e89b-12d3-a456-426614174000", 6, 114000.0 },
                    { "123e4567-e89b-12d3-a456-426614174023", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1995, 10, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Accountant", "Rodriguez", "123e4567-e89b-12d3-a456-426614174001", 3, 139000.0 },
                    { "123e4567-e89b-12d3-a456-426614174024", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1968, 8, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "HRManager", "Miller", "123e4567-e89b-12d3-a456-426614174000", 0, 130000.0 },
                    { "123e4567-e89b-12d3-a456-426614174025", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1968, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "ProjectManager", "Garcia", "123e4567-e89b-12d3-a456-426614174000", 1, 143000.0 },
                    { "123e4567-e89b-12d3-a456-426614174026", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1972, 3, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "CEO", "Williams", "123e4567-e89b-12d3-a456-426614174000", 7, 97000.0 },
                    { "123e4567-e89b-12d3-a456-426614174027", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 12, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "MarketingManager", "Garcia", "123e4567-e89b-12d3-a456-426614174001", 2, 68000.0 },
                    { "123e4567-e89b-12d3-a456-426614174028", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1975, 12, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "CFO", "Davis", "123e4567-e89b-12d3-a456-426614174001", 7, 81000.0 },
                    { "123e4567-e89b-12d3-a456-426614174029", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1960, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "Electrician", "Rodriguez", "123e4567-e89b-12d3-a456-426614174001", 7, 91000.0 },
                    { "123e4567-e89b-12d3-a456-426614174030", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1971, 12, 22, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "Electrician", "Wilson", "123e4567-e89b-12d3-a456-426614174000", 2, 115000.0 },
                    { "123e4567-e89b-12d3-a456-426614174031", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 5, 7, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "ProjectManager", "Miller", "123e4567-e89b-12d3-a456-426614174000", 5, 110000.0 },
                    { "123e4567-e89b-12d3-a456-426614174032", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1965, 11, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "Accountant", "Smith", "123e4567-e89b-12d3-a456-426614174001", 2, 50000.0 },
                    { "123e4567-e89b-12d3-a456-426614174033", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1967, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "Accountant", "Johnson", "123e4567-e89b-12d3-a456-426614174000", 1, 115000.0 },
                    { "123e4567-e89b-12d3-a456-426614174034", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1994, 5, 18, 0, 0, 0, 0, DateTimeKind.Unspecified), "Robert", "CFO", "Davis", "123e4567-e89b-12d3-a456-426614174001", 3, 69000.0 },
                    { "123e4567-e89b-12d3-a456-426614174035", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1986, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "Accountant", "Miller", "123e4567-e89b-12d3-a456-426614174000", 5, 72000.0 },
                    { "123e4567-e89b-12d3-a456-426614174036", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1987, 4, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "MarketingManager", "Rodriguez", "123e4567-e89b-12d3-a456-426614174001", 3, 148000.0 },
                    { "123e4567-e89b-12d3-a456-426614174037", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 6, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "ProjectManager", "Smith", "123e4567-e89b-12d3-a456-426614174001", 3, 50000.0 },
                    { "123e4567-e89b-12d3-a456-426614174038", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1979, 9, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "Electrician", "Brown", "123e4567-e89b-12d3-a456-426614174000", 1, 129000.0 },
                    { "123e4567-e89b-12d3-a456-426614174039", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1980, 3, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lisa", "Accountant", "Wilson", "123e4567-e89b-12d3-a456-426614174001", 5, 113000.0 },
                    { "123e4567-e89b-12d3-a456-426614174040", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1962, 2, 26, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "HRManager", "Brown", "123e4567-e89b-12d3-a456-426614174000", 7, 106000.0 },
                    { "123e4567-e89b-12d3-a456-426614174041", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1974, 2, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Emily", "HRManager", "Johnson", "123e4567-e89b-12d3-a456-426614174001", 0, 73000.0 },
                    { "123e4567-e89b-12d3-a456-426614174042", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1975, 8, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "MarketingManager", "Rodriguez", "123e4567-e89b-12d3-a456-426614174000", 2, 104000.0 },
                    { "123e4567-e89b-12d3-a456-426614174043", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1963, 7, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "ProjectManager", "Davis", "123e4567-e89b-12d3-a456-426614174001", 5, 140000.0 },
                    { "123e4567-e89b-12d3-a456-426614174044", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1976, 11, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "William", "MarketingManager", "Brown", "123e4567-e89b-12d3-a456-426614174001", 7, 131000.0 },
                    { "123e4567-e89b-12d3-a456-426614174045", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1997, 11, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "HRManager", "Garcia", "123e4567-e89b-12d3-a456-426614174001", 7, 130000.0 },
                    { "123e4567-e89b-12d3-a456-426614174046", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1967, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified), "David", "CEO", "Wilson", "123e4567-e89b-12d3-a456-426614174001", 4, 141000.0 },
                    { "123e4567-e89b-12d3-a456-426614174047", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1973, 11, 11, 0, 0, 0, 0, DateTimeKind.Unspecified), "John", "Electrician", "Rodriguez", "123e4567-e89b-12d3-a456-426614174001", 7, 63000.0 },
                    { "123e4567-e89b-12d3-a456-426614174048", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1961, 7, 19, 0, 0, 0, 0, DateTimeKind.Unspecified), "Sarah", "CEO", "Wilson", "123e4567-e89b-12d3-a456-426614174001", 1, 69000.0 },
                    { "123e4567-e89b-12d3-a456-426614174049", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1978, 5, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), "Jane", "Accountant", "Johnson", "123e4567-e89b-12d3-a456-426614174001", 5, 77000.0 }
                });

            migrationBuilder.InsertData(
                table: "Consumers",
                columns: new[] { "Id", "ChangedDate", "CreatedDate", "Description", "DistributionPanelId", "MaxConsumption", "Name", "PowerConsumption" },
                values: new object[,]
                {
                    { "123e4567-e89b-12d3-a456-426614174004", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Office of Bugs Bunny", "123e4567-e89b-12d3-a456-426614174003", 2000.0, "Bugs Bunny Office", 1500.0 },
                    { "123e4567-e89b-12d3-a456-426614174005", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Lab of Daffy Duck", "123e4567-e89b-12d3-a456-426614174003", 2500.0, "Daffy Duck Lab", 2000.0 },
                    { "123e4567-e89b-12d3-a456-426614174006", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secret cave of Batman", "123e4567-e89b-12d3-a456-426614174002", 7000.0, "Batman Cave", 5000.0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Consumers_DistributionPanelId",
                table: "Consumers",
                column: "DistributionPanelId");

            migrationBuilder.CreateIndex(
                name: "IX_DistributionPanels_LocationId",
                table: "DistributionPanels",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_LocationId",
                table: "Employees",
                column: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Consumers");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "DistributionPanels");

            migrationBuilder.DropTable(
                name: "Locations");
        }
    }
}
