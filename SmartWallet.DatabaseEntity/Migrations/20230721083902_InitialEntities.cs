using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWallet.DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class InitialEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tblAddFundRequests",
                columns: table => new
                {
                    AddFundRequestID = table.Column<Guid>(type: "uuid", nullable: false),
                    WalletID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestType = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByID = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblAddFundRequests", x => x.AddFundRequestID);
                });

            migrationBuilder.CreateTable(
                name: "tblWallets",
                columns: table => new
                {
                    WalletID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    WalletBalance = table.Column<decimal>(type: "numeric", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedBy = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedBy = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWallets", x => x.WalletID);
                });

            migrationBuilder.CreateTable(
                name: "tblWalletTransactions",
                columns: table => new
                {
                    AddWalletTransactionID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    WalletID = table.Column<Guid>(type: "uuid", nullable: false),
                    FundRequestID = table.Column<Guid>(type: "uuid", nullable: false),
                    TransactionNumber = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    TrackingID = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    TransactionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    BankRefNo = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    PaymentMode = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Description = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Status = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    TransactionType = table.Column<string>(type: "text", nullable: false),
                    Remark = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByID = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWalletTransactions", x => x.AddWalletTransactionID);
                });

            migrationBuilder.CreateTable(
                name: "tblWithdrawFundRequests",
                columns: table => new
                {
                    WithdrawFundRequestID = table.Column<Guid>(type: "uuid", nullable: false),
                    WalletID = table.Column<Guid>(type: "uuid", nullable: false),
                    UserID = table.Column<Guid>(type: "uuid", nullable: false),
                    RequestType = table.Column<string>(type: "text", nullable: false),
                    RequestDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Amount = table.Column<decimal>(type: "numeric", nullable: false),
                    Currency = table.Column<string>(type: "text", nullable: false),
                    Remark = table.Column<string>(type: "text", nullable: false),
                    ProcessedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedByID = table.Column<Guid>(type: "uuid", nullable: false),
                    ModifiedByID = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tblWithdrawFundRequests", x => x.WithdrawFundRequestID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tblAddFundRequests");

            migrationBuilder.DropTable(
                name: "tblWallets");

            migrationBuilder.DropTable(
                name: "tblWalletTransactions");

            migrationBuilder.DropTable(
                name: "tblWithdrawFundRequests");
        }
    }
}
