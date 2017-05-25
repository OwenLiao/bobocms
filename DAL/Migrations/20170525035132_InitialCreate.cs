using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    Author = table.Column<string>(nullable: true),
                    Click = table.Column<int>(nullable: false),
                    CommentCount = table.Column<int>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    DiggBad = table.Column<int>(nullable: false),
                    DiggGood = table.Column<int>(nullable: false),
                    From = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    InputAuthor = table.Column<string>(nullable: true),
                    IsAddRSS = table.Column<bool>(nullable: false),
                    IsBig = table.Column<bool>(nullable: false),
                    IsHot = table.Column<bool>(nullable: false),
                    IsLock = table.Column<bool>(nullable: false),
                    IsMsg = table.Column<bool>(nullable: false),
                    IsRed = table.Column<bool>(nullable: false),
                    IsShow = table.Column<bool>(nullable: false),
                    IsSlide = table.Column<bool>(nullable: false),
                    IsTop = table.Column<bool>(nullable: false),
                    LinkUrl = table.Column<string>(nullable: true),
                    RealClick = table.Column<int>(nullable: false),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    ShareCount = table.Column<int>(nullable: false),
                    SortId = table.Column<int>(nullable: false),
                    ThemeId = table.Column<int>(nullable: true),
                    Title = table.Column<string>(nullable: true),
                    Title1 = table.Column<string>(nullable: true),
                    UserId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    ArticleBottomWechatHtml = table.Column<string>(nullable: true),
                    BackGround = table.Column<string>(nullable: true),
                    CallIndex = table.Column<string>(nullable: true),
                    CategoryRelation = table.Column<string>(nullable: true),
                    CategoryTypeId = table.Column<int>(nullable: true),
                    ClickCount = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    GuanZhuCount = table.Column<int>(nullable: false),
                    HeadChar = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    IsDeleted = table.Column<bool>(nullable: false),
                    IsGuoYuan = table.Column<bool>(nullable: false),
                    IsLock = table.Column<bool>(nullable: false),
                    LinkUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: true),
                    NotTagShow = table.Column<bool>(nullable: false),
                    ParentId = table.Column<int>(nullable: true),
                    PlatformLoginText = table.Column<string>(nullable: true),
                    PlatformLoginUrl = table.Column<string>(nullable: true),
                    PlatformSetUpShopText = table.Column<string>(nullable: true),
                    PlatformSetUpShopUrl = table.Column<string>(nullable: true),
                    RealGuanZhuCount = table.Column<int>(nullable: false),
                    SeoDescription = table.Column<string>(nullable: true),
                    SeoKeywords = table.Column<string>(nullable: true),
                    SeoTitle = table.Column<string>(nullable: true),
                    SortId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Category_Category_ParentId",
                        column: x => x.ParentId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DetailArticleCategory",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailArticleCategory", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_DetailArticleCategory_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DetailArticleCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ListArticleCategory",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ListArticleCategory", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ListArticleCategory_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ListArticleCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Category_ParentId",
                table: "Category",
                column: "ParentId");

            migrationBuilder.CreateIndex(
                name: "IX_DetailArticleCategory_CategoryId",
                table: "DetailArticleCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListArticleCategory_CategoryId",
                table: "ListArticleCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailArticleCategory");

            migrationBuilder.DropTable(
                name: "ListArticleCategory");

            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "Category");
        }
    }
}
