using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SmartWallet.DatabaseEntity.Migrations
{
    /// <inheritdoc />
    public partial class TableRename : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_tblWithdrawFundRequests",
                table: "tblWithdrawFundRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblWalletTransactions",
                table: "tblWalletTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblWallets",
                table: "tblWallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_tblAddFundRequests",
                table: "tblAddFundRequests");

            migrationBuilder.RenameTable(
                name: "tblWithdrawFundRequests",
                newName: "WithdrawFundRequests");

            migrationBuilder.RenameTable(
                name: "tblWalletTransactions",
                newName: "WalletTransactions");

            migrationBuilder.RenameTable(
                name: "tblWallets",
                newName: "Wallets");

            migrationBuilder.RenameTable(
                name: "tblAddFundRequests",
                newName: "AddFundRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WithdrawFundRequests",
                table: "WithdrawFundRequests",
                column: "WithdrawFundRequestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_WalletTransactions",
                table: "WalletTransactions",
                column: "AddWalletTransactionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets",
                column: "WalletID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AddFundRequests",
                table: "AddFundRequests",
                column: "AddFundRequestID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_WithdrawFundRequests",
                table: "WithdrawFundRequests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_WalletTransactions",
                table: "WalletTransactions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Wallets",
                table: "Wallets");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AddFundRequests",
                table: "AddFundRequests");

            migrationBuilder.RenameTable(
                name: "WithdrawFundRequests",
                newName: "tblWithdrawFundRequests");

            migrationBuilder.RenameTable(
                name: "WalletTransactions",
                newName: "tblWalletTransactions");

            migrationBuilder.RenameTable(
                name: "Wallets",
                newName: "tblWallets");

            migrationBuilder.RenameTable(
                name: "AddFundRequests",
                newName: "tblAddFundRequests");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblWithdrawFundRequests",
                table: "tblWithdrawFundRequests",
                column: "WithdrawFundRequestID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblWalletTransactions",
                table: "tblWalletTransactions",
                column: "AddWalletTransactionID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblWallets",
                table: "tblWallets",
                column: "WalletID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_tblAddFundRequests",
                table: "tblAddFundRequests",
                column: "AddFundRequestID");
        }
    }
}
