using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TestAsp.Data.Migrations
{
    public partial class InitialCatalog : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Departement",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Filiere",
                schema: "dbo",
                columns: table => new
                {
                    CodeFil = table.Column<string>(type: "varchar(20)", maxLength: 20, nullable: false),
                    Name = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Filiere", x => x.CodeFil);
                });

            migrationBuilder.CreateTable(
                name: "Salle",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1000, 1"),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Salle", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etudiant",
                schema: "dbo",
                columns: table => new
                {
                    Matricule = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateNais = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FiliereId = table.Column<string>(type: "varchar(20)", nullable: true),
                    Nom = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Prenom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Telephone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Adresse = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etudiant", x => x.Matricule);
                    table.CheckConstraint("CK_Etudiant_ck_age", "(year(GETDATE()) - year(DateNais)) >=18");
                    table.ForeignKey(
                        name: "FK_Etudiant_Filiere_FiliereId",
                        column: x => x.FiliereId,
                        principalSchema: "dbo",
                        principalTable: "Filiere",
                        principalColumn: "CodeFil");
                });

            migrationBuilder.CreateTable(
                name: "Matiere",
                schema: "dbo",
                columns: table => new
                {
                    CodeMat = table.Column<string>(type: "varchar(15)", maxLength: 15, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    SalleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Matiere", x => x.CodeMat);
                    table.ForeignKey(
                        name: "FK_Matiere_Salle_SalleId",
                        column: x => x.SalleId,
                        principalSchema: "dbo",
                        principalTable: "Salle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Enseignant",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatePriseFonct = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MatiereId = table.Column<string>(type: "varchar(15)", nullable: true),
                    DepartementId = table.Column<int>(type: "int", nullable: false),
                    Nom = table.Column<string>(type: "varchar(25)", maxLength: 25, nullable: false),
                    Prenom = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: true),
                    Telephone = table.Column<string>(type: "varchar(50)", maxLength: 50, nullable: true),
                    Adresse = table.Column<string>(type: "varchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Enseignant", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Enseignant_Departement_DepartementId",
                        column: x => x.DepartementId,
                        principalSchema: "dbo",
                        principalTable: "Departement",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Enseignant_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalSchema: "dbo",
                        principalTable: "Matiere",
                        principalColumn: "CodeMat");
                });

            migrationBuilder.CreateTable(
                name: "Note",
                schema: "dbo",
                columns: table => new
                {
                    EtudiantId = table.Column<int>(type: "int", nullable: false),
                    MatiereId = table.Column<string>(type: "varchar(15)", nullable: false),
                    NoteEval = table.Column<double>(type: "float", nullable: false),
                    DateEval = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Note", x => new { x.EtudiantId, x.MatiereId });
                    table.CheckConstraint("CK_Note_ck_note", "NoteEval>=0 and NoteEval<=20");
                    table.ForeignKey(
                        name: "FK_Note_Etudiant_EtudiantId",
                        column: x => x.EtudiantId,
                        principalSchema: "dbo",
                        principalTable: "Etudiant",
                        principalColumn: "Matricule",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Note_Matiere_MatiereId",
                        column: x => x.MatiereId,
                        principalSchema: "dbo",
                        principalTable: "Matiere",
                        principalColumn: "CodeMat");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enseignant_DepartementId",
                schema: "dbo",
                table: "Enseignant",
                column: "DepartementId");

            migrationBuilder.CreateIndex(
                name: "IX_Enseignant_MatiereId",
                schema: "dbo",
                table: "Enseignant",
                column: "MatiereId");

            migrationBuilder.CreateIndex(
                name: "IX_Etudiant_FiliereId",
                schema: "dbo",
                table: "Etudiant",
                column: "FiliereId");

            migrationBuilder.CreateIndex(
                name: "IX_Matiere_SalleId",
                schema: "dbo",
                table: "Matiere",
                column: "SalleId");

            migrationBuilder.CreateIndex(
                name: "IX_Note_MatiereId",
                schema: "dbo",
                table: "Note",
                column: "MatiereId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Enseignant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Note",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Departement",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Etudiant",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Matiere",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Filiere",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Salle",
                schema: "dbo");
        }
    }
}
