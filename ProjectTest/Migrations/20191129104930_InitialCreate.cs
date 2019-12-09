using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjectTest.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AboutMes",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Introduce = table.Column<string>(type: "ntext", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedDate = table.Column<DateTime>(defaultValueSql:"GETDATE()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: false),
                    Note = table.Column<string>(type: "ntext", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutMes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    PassWord = table.Column<string>(type: "varchar(50)", nullable: false),
                    Avartar = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    DisplayName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Phone = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CreatedBy = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(defaultValueSql: "GETDATE()", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    IsAdmin = table.Column<bool>(nullable: true),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoryPosts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    MetaTitle = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MetaKeyword = table.Column<string>(nullable: true),
                    MetaDescription = table.Column<string>(nullable: true),
                    CreatedDate = table.Column<DateTime>(defaultValueSql: "GETDATE()", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoryPosts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Contacts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contents = table.Column<string>(type: "ntext", nullable: true),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contacts", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FeedBacks",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Phone = table.Column<string>(type: "varchar(12)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Contents = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    CreatedDate = table.Column<DateTime>(defaultValueSql: "GETDATE()", nullable: true),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FeedBacks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Footers",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Contents = table.Column<string>(type: "ntext", nullable: true),
                    CreatedDate = table.Column<DateTime>(defaultValueSql: "GETDATE()", nullable: true),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Footers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Slides",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Image = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DisplayOrder = table.Column<int>(nullable: true),
                    Link = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    CreatedDate = table.Column<DateTime>(defaultValueSql: "GETDATE()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Slides", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeMenus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeMenus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(type: "nvarchar(500)", nullable: false),
                    ContentPost = table.Column<string>(type: "ntext", nullable: false),
                    MetaTitle = table.Column<string>(type: "nchar(500)", nullable: true),
                    CreatedDate = table.Column<DateTime>(defaultValueSql: "GETDATE()", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ModifiedDate = table.Column<DateTime>(nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MetaKeyword = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    MetaDescription = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ViewCount = table.Column<long>(defaultValueSql: "1",nullable: true),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: true),
                    CategoryId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Posts_CategoryPosts_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "CategoryPosts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Text = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    Link = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    DisplayOrder = table.Column<string>(nullable: false),
                    Status = table.Column<bool>(defaultValueSql: "1", nullable: false),
                    TypeID = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_TypeMenus_TypeID",
                        column: x => x.TypeID,
                        principalTable: "TypeMenus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Menus_TypeID",
                table: "Menus",
                column: "TypeID");

            migrationBuilder.CreateIndex(
                name: "IX_Posts_CategoryId",
                table: "Posts",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutMes");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Contacts");

            migrationBuilder.DropTable(
                name: "FeedBacks");

            migrationBuilder.DropTable(
                name: "Footers");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Posts");

            migrationBuilder.DropTable(
                name: "Slides");

            migrationBuilder.DropTable(
                name: "TypeMenus");

            migrationBuilder.DropTable(
                name: "CategoryPosts");
        }
    }
}
