using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DF.Webinar.GraphQL.Database.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearOfPublication = table.Column<int>(type: "int", nullable: true),
                    ArticleNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Isbn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pages = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: true),
                    AuthorId = table.Column<long>(type: "bigint", nullable: true),
                    AuthorId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Books_Authors_AuthorId1",
                        column: x => x.AuthorId1,
                        principalTable: "Authors",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "FirstName", "LastName" },
                values: new object[,]
                {
                    { 1, "Martin", "Fowler" },
                    { 2, "Robert C.", "Martin" },
                    { 3, "Erich", "Gamma" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "ArticleNumber", "AuthorId", "AuthorId1", "Description", "Isbn", "Language", "Pages", "Price", "Title", "YearOfPublication" },
                values: new object[,]
                {
                    { 1, null, 1L, null, "Improving the Design of Existing Code", null, null, null, null, "Refactoring", 2018 },
                    { 2, null, 1L, null, "A Brief Guide to the Emerging World of Polyglot Persistence", null, null, null, null, "NoSQL Distilled", 2012 },
                    { 3, null, 1L, null, "A detailed guide on implementing both internal and external DSLs", null, null, null, null, "Domain Specific Languages", 2010 },
                    { 4, null, 1L, null, "By Martin Fowler, with Dave Rice, Matthew Foemmel, Edward Hieatt, Robert Mee, and Randy Stafford", null, null, null, null, "Patterns of Enterprise Application Architecture", 2002 },
                    { 5, null, 1L, null, "Now there are quite a few XP and agile books out there, many of which focus on planning and project management issues.", null, null, null, null, "Planning Extreme Programming", 2000 },
                    { 6, null, 1L, null, "The patterns come from various domains, including health care, financial trading, and accounting.", null, null, null, null, "Analysis Patterns", 1996 },
                    { 7, null, 1L, null, "A Brief Guide to the Standard Object Modeling Language", null, null, null, null, "UML Distilled", 2003 },
                    { 8, null, 2L, null, "Applications Using the Booch Method", null, null, null, null, "Designing Object-Oriented C++", 1995 },
                    { 9, null, 2L, null, "Principles, Patterns, and Practices.", null, null, null, null, "Agile Software Development", 2002 },
                    { 10, null, 2L, null, "A Handbook of Agile Software Craftsmanship", null, null, null, null, "Clean Code", 2009 },
                    { 11, null, 2L, null, " A Craftsman's Guide to Software Structure and Design", null, null, null, null, "Clean Architecture", 2017 },
                    { 12, null, 2L, null, "Back to Basics", null, null, null, null, "Clean Agile", 2019 },
                    { 13, null, 3L, null, "Elements of Reusable Object-Oriented Software", null, null, null, null, "Design Patterns", 1997 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Books_AuthorId1",
                table: "Books",
                column: "AuthorId1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Authors");
        }
    }
}
