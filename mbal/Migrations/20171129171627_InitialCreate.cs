using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace mbal.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "agencies",
                columns: table => new
                {
                    AgencyID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    BanhchCode = table.Column<string>(nullable: true),
                    ConsultantName = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agencies", x => x.AgencyID);
                });

            migrationBuilder.CreateTable(
                name: "compensations",
                columns: table => new
                {
                    CompensationId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AcceptCompensation = table.Column<long>(nullable: false),
                    CompensationDate = table.Column<DateTime>(nullable: false),
                    CompensationMoney = table.Column<float>(nullable: false),
                    CustomerCode = table.Column<string>(nullable: true),
                    DateOfCompensation = table.Column<DateTime>(nullable: false),
                    InsurranceId = table.Column<long>(nullable: false),
                    Reason = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_compensations", x => x.CompensationId);
                });

            migrationBuilder.CreateTable(
                name: "customers",
                columns: table => new
                {
                    CustomerID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Cmtnd = table.Column<string>(nullable: true),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CustomerCode = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    FullName = table.Column<string>(nullable: true),
                    Phonenumber = table.Column<string>(nullable: true),
                    Sex = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_customers", x => x.CustomerID);
                });

            migrationBuilder.CreateTable(
                name: "employees",
                columns: table => new
                {
                    EmployeeID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Address = table.Column<string>(nullable: true),
                    Dob = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    EmployeeNumber = table.Column<string>(nullable: true),
                    Fullname = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_employees", x => x.EmployeeID);
                });

            migrationBuilder.CreateTable(
                name: "payments",
                columns: table => new
                {
                    PaymentId = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    AmountPayment = table.Column<float>(nullable: false),
                    CreateAt = table.Column<DateTime>(nullable: false),
                    CustomerCode = table.Column<string>(nullable: true),
                    InsurranceId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "products",
                columns: table => new
                {
                    ProductID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Money = table.Column<string>(nullable: true),
                    PayMethod = table.Column<int>(nullable: false),
                    ProductCode = table.Column<string>(nullable: true),
                    ProductName = table.Column<string>(nullable: true),
                    ProductStatus = table.Column<string>(nullable: true),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_products", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    fullname = table.Column<string>(nullable: true),
                    password = table.Column<string>(nullable: true),
                    role = table.Column<string>(nullable: true),
                    username = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "insurrances",
                columns: table => new
                {
                    InsurranceID = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BanhchCode = table.Column<string>(nullable: true),
                    ContractNumber = table.Column<string>(nullable: true),
                    CoverageRate = table.Column<string>(nullable: true),
                    Create_at = table.Column<DateTime>(nullable: false),
                    Create_by = table.Column<string>(nullable: true),
                    CustomerID = table.Column<long>(nullable: false),
                    DurationOfInsurrance = table.Column<int>(nullable: false),
                    EmployeeID = table.Column<long>(nullable: false),
                    FormOfPayment = table.Column<int>(nullable: false),
                    ProductID = table.Column<long>(nullable: false),
                    StatusContract = table.Column<string>(nullable: true),
                    StatusFee = table.Column<string>(nullable: true),
                    TimeIn = table.Column<DateTime>(nullable: false),
                    TimeOut = table.Column<DateTime>(nullable: false),
                    description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_insurrances", x => x.InsurranceID);
                    table.ForeignKey(
                        name: "FK_insurrances_customers_CustomerID",
                        column: x => x.CustomerID,
                        principalTable: "customers",
                        principalColumn: "CustomerID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insurrances_employees_EmployeeID",
                        column: x => x.EmployeeID,
                        principalTable: "employees",
                        principalColumn: "EmployeeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_insurrances_products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "products",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_insurrances_CustomerID",
                table: "insurrances",
                column: "CustomerID");

            migrationBuilder.CreateIndex(
                name: "IX_insurrances_EmployeeID",
                table: "insurrances",
                column: "EmployeeID");

            migrationBuilder.CreateIndex(
                name: "IX_insurrances_ProductID",
                table: "insurrances",
                column: "ProductID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agencies");

            migrationBuilder.DropTable(
                name: "compensations");

            migrationBuilder.DropTable(
                name: "insurrances");

            migrationBuilder.DropTable(
                name: "payments");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropTable(
                name: "customers");

            migrationBuilder.DropTable(
                name: "employees");

            migrationBuilder.DropTable(
                name: "products");
        }
    }
}
