using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AgendaDeContatos.Migrations
{
    /// <inheritdoc />
    public partial class ContactManagerSystem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TblAdress");

            migrationBuilder.DropColumn(
                name: "IdCep",
                table: "TblContacts");

            migrationBuilder.RenameColumn(
                name: "Nome",
                table: "TblContacts",
                newName: "Phone");

            migrationBuilder.RenameColumn(
                name: "Celular",
                table: "TblContacts",
                newName: "Name");

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "TblContacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CEP",
                table: "TblContacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "TblContacts",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "TblContacts");

            migrationBuilder.DropColumn(
                name: "CEP",
                table: "TblContacts");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "TblContacts");

            migrationBuilder.RenameColumn(
                name: "Phone",
                table: "TblContacts",
                newName: "Nome");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TblContacts",
                newName: "Celular");

            migrationBuilder.AddColumn<int>(
                name: "IdCep",
                table: "TblContacts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "TblAdress",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TblAdress", x => x.Id);
                });
        }
    }
}
