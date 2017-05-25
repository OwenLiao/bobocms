using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL;

namespace DAL.Migrations
{
    [DbContext(typeof(MyDbContext))]
    partial class MyDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2");

            modelBuilder.Entity("Model.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("Author");

                    b.Property<int>("Click");

                    b.Property<int>("CommentCount");

                    b.Property<string>("Content");

                    b.Property<string>("Description");

                    b.Property<int>("DiggBad");

                    b.Property<int>("DiggGood");

                    b.Property<string>("From");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("InputAuthor");

                    b.Property<bool>("IsAddRSS");

                    b.Property<bool>("IsBig");

                    b.Property<bool>("IsHot");

                    b.Property<bool>("IsLock");

                    b.Property<bool>("IsMsg");

                    b.Property<bool>("IsRed");

                    b.Property<bool>("IsShow");

                    b.Property<bool>("IsSlide");

                    b.Property<bool>("IsTop");

                    b.Property<string>("LinkUrl");

                    b.Property<int>("RealClick");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoTitle");

                    b.Property<int>("ShareCount");

                    b.Property<int>("SortId");

                    b.Property<int?>("ThemeId");

                    b.Property<string>("Title");

                    b.Property<string>("Title1");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("ArticleBottomWechatHtml");

                    b.Property<string>("BackGround");

                    b.Property<string>("CallIndex");

                    b.Property<string>("CategoryRelation");

                    b.Property<int?>("CategoryTypeId");

                    b.Property<string>("ClickCount");

                    b.Property<string>("Content");

                    b.Property<int>("GuanZhuCount");

                    b.Property<string>("HeadChar");

                    b.Property<string>("ImgUrl");

                    b.Property<bool>("IsDeleted");

                    b.Property<bool>("IsGuoYuan");

                    b.Property<bool>("IsLock");

                    b.Property<string>("LinkUrl");

                    b.Property<string>("Name");

                    b.Property<bool>("NotTagShow");

                    b.Property<int?>("ParentId");

                    b.Property<string>("PlatformLoginText");

                    b.Property<string>("PlatformLoginUrl");

                    b.Property<string>("PlatformSetUpShopText");

                    b.Property<string>("PlatformSetUpShopUrl");

                    b.Property<int>("RealGuanZhuCount");

                    b.Property<string>("SeoDescription");

                    b.Property<string>("SeoKeywords");

                    b.Property<string>("SeoTitle");

                    b.Property<int>("SortId");

                    b.Property<string>("Title");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("Model.DetailArticleCategory", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ArticleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("DetailArticleCategory");
                });

            modelBuilder.Entity("Model.ListArticleCategory", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ArticleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ListArticleCategory");
                });

            modelBuilder.Entity("Model.Category", b =>
                {
                    b.HasOne("Model.Category", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Model.DetailArticleCategory", b =>
                {
                    b.HasOne("Model.Article", "Article")
                        .WithMany("DetailCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Category", "Category")
                        .WithMany("DetaileArticles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.ListArticleCategory", b =>
                {
                    b.HasOne("Model.Article", "Article")
                        .WithMany("ListCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Category", "Category")
                        .WithMany("ListArticles")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
