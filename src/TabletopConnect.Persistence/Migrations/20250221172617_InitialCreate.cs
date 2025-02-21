using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TabletopConnect.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Designers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Designers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Families",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Families", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mechanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mechanics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subcategories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Themes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Themes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BoardGames",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    YearPublished = table.Column<int>(type: "int", nullable: false),
                    GameComplexity = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: false),
                    IsReimplementation = table.Column<bool>(type: "bit", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlayTime_ManufacturerStatedPlayTime = table.Column<int>(type: "int", nullable: false),
                    PlayTime_CommunityMinPlayTime = table.Column<int>(type: "int", nullable: true),
                    PlayTime_CommunityMaxPlayTime = table.Column<int>(type: "int", nullable: true),
                    RecommendedAge_ManufacturerRecomended = table.Column<int>(type: "int", nullable: false),
                    RecommendedAge_CommunityRecomended = table.Column<int>(type: "int", nullable: true),
                    Players_MinPlayers = table.Column<int>(type: "int", nullable: false),
                    Players_MaxPlayers = table.Column<int>(type: "int", nullable: false),
                    Players_BestPlayers = table.Column<int>(type: "int", nullable: true),
                    Players__goodPlayers = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BggData_BggId = table.Column<int>(type: "int", nullable: true),
                    BggData_BggScore = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: true),
                    BggData_NumberOwned = table.Column<int>(type: "int", nullable: true),
                    BggData_NumberWanted = table.Column<int>(type: "int", nullable: true),
                    BggData_NumberWished = table.Column<int>(type: "int", nullable: true),
                    BggData_NumberWeightVotes = table.Column<int>(type: "int", nullable: true),
                    BggData_AverageRating = table.Column<double>(type: "float(18)", precision: 18, scale: 2, nullable: true),
                    BggData_RankOverall = table.Column<int>(type: "int", nullable: true),
                    LanguageDependence = table.Column<int>(type: "int", nullable: false),
                    ExpansionForId = table.Column<int>(type: "int", nullable: true),
                    FamilyId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGames", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGames_Families_FamilyId",
                        column: x => x.FamilyId,
                        principalTable: "Families",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameCategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    BggPosition = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameCategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGameCategories_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameCategories_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameDesigners",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameId = table.Column<int>(type: "int", nullable: false),
                    DesignerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameDesigners", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGameDesigners_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameDesigners_Designers_DesignerId",
                        column: x => x.DesignerId,
                        principalTable: "Designers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameMechanics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameId = table.Column<int>(type: "int", nullable: false),
                    MechanicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameMechanics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGameMechanics_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameMechanics_Mechanics_MechanicId",
                        column: x => x.MechanicId,
                        principalTable: "Mechanics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGamePublishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameId = table.Column<int>(type: "int", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGamePublishers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGamePublishers_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGamePublishers_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameSubcategories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameId = table.Column<int>(type: "int", nullable: false),
                    SubcategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameSubcategories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGameSubcategories_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameSubcategories_Subcategories_SubcategoryId",
                        column: x => x.SubcategoryId,
                        principalTable: "Subcategories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BoardGameThemes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BoardGameId = table.Column<int>(type: "int", nullable: false),
                    ThemeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoardGameThemes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BoardGameThemes_BoardGames_BoardGameId",
                        column: x => x.BoardGameId,
                        principalTable: "BoardGames",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BoardGameThemes_Themes_ThemeId",
                        column: x => x.ThemeId,
                        principalTable: "Themes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameCategories_BoardGameId",
                table: "BoardGameCategories",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameCategories_CategoryId",
                table: "BoardGameCategories",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameDesigners_BoardGameId",
                table: "BoardGameDesigners",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameDesigners_DesignerId",
                table: "BoardGameDesigners",
                column: "DesignerId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameMechanics_BoardGameId",
                table: "BoardGameMechanics",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameMechanics_MechanicId",
                table: "BoardGameMechanics",
                column: "MechanicId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGamePublishers_BoardGameId",
                table: "BoardGamePublishers",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGamePublishers_PublisherId",
                table: "BoardGamePublishers",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGames_FamilyId",
                table: "BoardGames",
                column: "FamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameSubcategories_BoardGameId",
                table: "BoardGameSubcategories",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameSubcategories_SubcategoryId",
                table: "BoardGameSubcategories",
                column: "SubcategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameThemes_BoardGameId",
                table: "BoardGameThemes",
                column: "BoardGameId");

            migrationBuilder.CreateIndex(
                name: "IX_BoardGameThemes_ThemeId",
                table: "BoardGameThemes",
                column: "ThemeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BoardGameCategories");

            migrationBuilder.DropTable(
                name: "BoardGameDesigners");

            migrationBuilder.DropTable(
                name: "BoardGameMechanics");

            migrationBuilder.DropTable(
                name: "BoardGamePublishers");

            migrationBuilder.DropTable(
                name: "BoardGameSubcategories");

            migrationBuilder.DropTable(
                name: "BoardGameThemes");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropTable(
                name: "Designers");

            migrationBuilder.DropTable(
                name: "Mechanics");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "Subcategories");

            migrationBuilder.DropTable(
                name: "BoardGames");

            migrationBuilder.DropTable(
                name: "Themes");

            migrationBuilder.DropTable(
                name: "Families");
        }
    }
}
