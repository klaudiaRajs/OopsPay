using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Transactions.Migrations
{
    /// <inheritdoc />
    public partial class AddedSchemaForReceivedRequiredDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ReceiveRequiredDetails",
                newName: "ReceiveRequiredDetails",
                newSchema: "TransactionOutbox");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "ReceiveRequiredDetails",
                schema: "TransactionOutbox",
                newName: "ReceiveRequiredDetails");
        }
    }
}
