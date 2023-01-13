using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace AnimalsWeb.Migrations
{
    /// <inheritdoc />
    public partial class InitDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Animals",
                columns: table => new
                {
                    AnimalId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    PictureName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animals", x => x.AnimalId);
                    table.ForeignKey(
                        name: "FK_Animals_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    CommentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalId = table.Column<int>(type: "int", nullable: false),
                    Content = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.CommentId);
                    table.ForeignKey(
                        name: "FK_Comments_Animals_AnimalId",
                        column: x => x.AnimalId,
                        principalTable: "Animals",
                        principalColumn: "AnimalId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Name" },
                values: new object[,]
                {
                    { 1, "Mamal" },
                    { 2, "Bird" },
                    { 3, "Fish" },
                    { 4, "Reptile" }
                });

            migrationBuilder.InsertData(
                table: "Animals",
                columns: new[] { "AnimalId", "Age", "CategoryId", "Description", "Name", "PictureName" },
                values: new object[,]
                {
                    { 1, 3, 1, "tiger (Felidae), rivaled only by the lion (Panthera leo) in strength and ferocity. The tiger is endangered throughout its range, which stretches from the Russian Far East through parts of North Korea, China, India, and Southeast", "Tiger", "https://upload.wikimedia.org/wikipedia/commons/3/3f/Walking_tiger_female.jpg" },
                    { 2, 4, 2, "eagle, any of many large, heavy-beaked, big-footed birds of prey belonging to the family Accipitridae (order Accipitriformes) may resemble a vulture in build and flight characteristics", "Eagale", "https://upload.wikimedia.org/wikipedia/commons/1/1a/About_to_Launch_%2826075320352%29.jpg" },
                    { 3, 5, 4, "Alligators have a long, rounded snout that has upward facing nostrils at the end; this allows breathing to occur while the rest of the body is underwater. have dark stripes on the tail. It's easy to distinguish an alligator from a crocodile by the teeth.", "Aligator", "https://upload.wikimedia.org/wikipedia/commons/thumb/f/f3/A_aligator.png/640px-A_aligator.png" },
                    { 4, 5, 1, "Wolves vary in size depending on where they live. Wolves in the north are usually larger than those in the south. The average size of a wolf. Females typically weigh 60 to 100 pounds, and males weigh 70 to 145 pounds.", "Wolf", "https://upload.wikimedia.org/wikipedia/commons/6/68/Eurasian_wolf_2.jpg" },
                    { 5, 2, 2, "The male Andean condor is a black bird with grayish white wing feathers, a white fringe of feathers around the neck, and a bare red or pinkish head, neck, and crop. Males have a large caruncle,", "Condor", "https://upload.wikimedia.org/wikipedia/commons/0/0f/Andean_condor_%28Vultur_gryphus%29_at_Colca_Canyon.jpg" }
                });

            migrationBuilder.InsertData(
                table: "Comments",
                columns: new[] { "CommentId", "AnimalId", "Content" },
                values: new object[,]
                {
                    { 1, 1, "the tiger color is beautiful" },
                    { 2, 2, " is wings are higher then me" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Animals_CategoryId",
                table: "Animals",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Comments_AnimalId",
                table: "Comments",
                column: "AnimalId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Animals");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
