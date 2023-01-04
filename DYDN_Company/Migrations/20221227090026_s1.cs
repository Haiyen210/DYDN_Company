using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DYDN_Company.Migrations
{
    public partial class s1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAccount",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Gender = table.Column<bool>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAccount", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblBanner",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBanner", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblCategory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblCategory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblDepartment",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblDepartment", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblFactory",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblFactory", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "tblEmployee",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Gender = table.Column<bool>(nullable: false),
                    Birthday = table.Column<DateTime>(nullable: false),
                    Address = table.Column<string>(maxLength: 50, nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    Role = table.Column<string>(nullable: false),
                    DepartmentID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblEmployee", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblEmployee_tblDepartment_DepartmentID",
                        column: x => x.DepartmentID,
                        principalTable: "tblDepartment",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblWareHouse",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    FactoryID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWareHouse", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblWareHouse_tblFactory_FactoryID",
                        column: x => x.FactoryID,
                        principalTable: "tblFactory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblProduct",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Code = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Tax = table.Column<double>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false),
                    WareHouseID = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblProduct", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblCategory_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "tblCategory",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblProduct_tblWareHouse_WareHouseID",
                        column: x => x.WareHouseID,
                        principalTable: "tblWareHouse",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOrderDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProductID = table.Column<int>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<float>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrderDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblOrderDetail_tblProduct_ProductID",
                        column: x => x.ProductID,
                        principalTable: "tblProduct",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblOrder",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 30, nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AccountID = table.Column<int>(nullable: false),
                    TotalQuantity = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<int>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false),
                    HistoryBillID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblOrder", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblOrder_tblAccount_AccountID",
                        column: x => x.AccountID,
                        principalTable: "tblAccount",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBill",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    OrderID = table.Column<int>(nullable: false),
                    TotalPrice = table.Column<float>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblBill_tblOrder_OrderID",
                        column: x => x.OrderID,
                        principalTable: "tblOrder",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblBillDetail",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillID = table.Column<int>(nullable: false),
                    OrderDetailID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblBillDetail", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblBillDetail_tblBill_BillID",
                        column: x => x.BillID,
                        principalTable: "tblBill",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_tblBillDetail_tblOrderDetail_OrderDetailID",
                        column: x => x.OrderDetailID,
                        principalTable: "tblOrderDetail",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "tblHistoryBill",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BillID = table.Column<int>(nullable: false),
                    CreatedDate = table.Column<DateTime>(nullable: false),
                    ModifiedDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblHistoryBill", x => x.ID);
                    table.ForeignKey(
                        name: "FK_tblHistoryBill_tblBill_BillID",
                        column: x => x.BillID,
                        principalTable: "tblBill",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tblAccount_Code",
                table: "tblAccount",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblAccount_Email",
                table: "tblAccount",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblBill_OrderID",
                table: "tblBill",
                column: "OrderID");

            migrationBuilder.CreateIndex(
                name: "IX_tblBillDetail_BillID",
                table: "tblBillDetail",
                column: "BillID");

            migrationBuilder.CreateIndex(
                name: "IX_tblBillDetail_OrderDetailID",
                table: "tblBillDetail",
                column: "OrderDetailID");

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_Code",
                table: "tblCategory",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblCategory_Name",
                table: "tblCategory",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblDepartment_Code",
                table: "tblDepartment",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblDepartment_Name",
                table: "tblDepartment",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_Code",
                table: "tblEmployee",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_DepartmentID",
                table: "tblEmployee",
                column: "DepartmentID");

            migrationBuilder.CreateIndex(
                name: "IX_tblEmployee_Email",
                table: "tblEmployee",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblFactory_Code",
                table: "tblFactory",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblFactory_Name",
                table: "tblFactory",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblHistoryBill_BillID",
                table: "tblHistoryBill",
                column: "BillID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_AccountID",
                table: "tblOrder",
                column: "AccountID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_HistoryBillID",
                table: "tblOrder",
                column: "HistoryBillID");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrder_Name",
                table: "tblOrder",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblOrderDetail_ProductID",
                table: "tblOrderDetail",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_CategoryID",
                table: "tblProduct",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_Code",
                table: "tblProduct",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_Name",
                table: "tblProduct",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_tblProduct_WareHouseID",
                table: "tblProduct",
                column: "WareHouseID");

            migrationBuilder.CreateIndex(
                name: "IX_tblWareHouse_Code",
                table: "tblWareHouse",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tblWareHouse_FactoryID",
                table: "tblWareHouse",
                column: "FactoryID");

            migrationBuilder.CreateIndex(
                name: "IX_tblWareHouse_Name",
                table: "tblWareHouse",
                column: "Name",
                unique: true,
                filter: "[Name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_tblOrder_tblHistoryBill_HistoryBillID",
                table: "tblOrder",
                column: "HistoryBillID",
                principalTable: "tblHistoryBill",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tblBill_tblOrder_OrderID",
                table: "tblBill");

            migrationBuilder.DropTable(
                name: "tblBanner");

            migrationBuilder.DropTable(
                name: "tblBillDetail");

            migrationBuilder.DropTable(
                name: "tblEmployee");

            migrationBuilder.DropTable(
                name: "tblOrderDetail");

            migrationBuilder.DropTable(
                name: "tblDepartment");

            migrationBuilder.DropTable(
                name: "tblProduct");

            migrationBuilder.DropTable(
                name: "tblCategory");

            migrationBuilder.DropTable(
                name: "tblWareHouse");

            migrationBuilder.DropTable(
                name: "tblFactory");

            migrationBuilder.DropTable(
                name: "tblOrder");

            migrationBuilder.DropTable(
                name: "tblAccount");

            migrationBuilder.DropTable(
                name: "tblHistoryBill");

            migrationBuilder.DropTable(
                name: "tblBill");
        }
    }
}
