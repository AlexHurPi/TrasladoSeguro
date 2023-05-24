using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrasladoSeguro.Migrations
{
    /// <inheritdoc />
    public partial class ServiceRegistration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ServiceRegistrations",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClienteId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClienteIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DriverIdentification = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTypeId = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ServiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceRegistrations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ServiceRegistrations");
        }
    }
}
