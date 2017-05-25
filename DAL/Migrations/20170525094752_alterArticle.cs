using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class alterArticle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DetailArticleCategory");

            migrationBuilder.DropTable(
                name: "ListArticleCategory");

            migrationBuilder.DropColumn(
                name: "ArticleBottomWechatHtml",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "CategoryRelation",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "NotTagShow",
                table: "Category");

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    ArticleId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => new { x.ArticleId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Article_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Article",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArticleCategory_CategoryId",
                table: "ArticleCategory",
                column: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.AddColumn<string>(
                name: "ArticleBottomWechatHtml",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CategoryRelation",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "NotTagShow",
                table: "Category",
                nullable: false,
                defaultValue: false);

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
                name: "IX_DetailArticleCategory_CategoryId",
                table: "DetailArticleCategory",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_ListArticleCategory_CategoryId",
                table: "ListArticleCategory",
                column: "CategoryId");
        }
    }
}
