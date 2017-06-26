using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using DAL;

namespace DAL.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20170626123409_alertManager")]
    partial class alertManager
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
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

            modelBuilder.Entity("Model.ArticleCategory", b =>
                {
                    b.Property<int>("ArticleId");

                    b.Property<int>("CategoryId");

                    b.HasKey("ArticleId", "CategoryId");

                    b.HasIndex("CategoryId");

                    b.ToTable("ArticleCategory");
                });

            modelBuilder.Entity("Model.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("BackGround");

                    b.Property<string>("CallIndex");

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

            modelBuilder.Entity("Model.Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime?>("AddTime");

                    b.Property<string>("Email");

                    b.Property<int?>("IsLock");

                    b.Property<string>("RealName");

                    b.Property<int?>("RoleType");

                    b.Property<string>("Telephone");

                    b.Property<string>("UserName")
                        .IsRequired();

                    b.Property<string>("UserPwd")
                        .IsRequired()
                        .HasMaxLength(100);

                    b.Property<int>("roleId");

                    b.HasKey("Id");

                    b.HasIndex("roleId");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("Model.ManagerLog", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionType");

                    b.Property<string>("LoginIp");

                    b.Property<DateTime?>("LoginTime");

                    b.Property<string>("Note");

                    b.Property<string>("UserName");

                    b.Property<int?>("userId");

                    b.HasKey("Id");

                    b.ToTable("ManagerLog");
                });

            modelBuilder.Entity("Model.ManagerRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RoleName");

                    b.Property<int?>("RoleType");

                    b.HasKey("Id");

                    b.ToTable("ManagerRole");
                });

            modelBuilder.Entity("Model.ManagerRoleValue", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ActionType");

                    b.Property<string>("ChannelName");

                    b.Property<int?>("ManagerRoleId");

                    b.Property<int?>("SysChannelId");

                    b.Property<int?>("channelId");

                    b.Property<int?>("roleId");

                    b.HasKey("Id");

                    b.HasIndex("ManagerRoleId");

                    b.HasIndex("SysChannelId");

                    b.ToTable("ManagerRoleValue");
                });

            modelBuilder.Entity("Model.SysChannel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("ImgUrl");

                    b.Property<string>("LinkUrl");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int?>("SortId")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired();

                    b.Property<int?>("parentId");

                    b.HasKey("Id");

                    b.HasIndex("parentId");

                    b.ToTable("SysChannel");
                });

            modelBuilder.Entity("Model.ArticleCategory", b =>
                {
                    b.HasOne("Model.Article", "Article")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("ArticleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Model.Category", "Category")
                        .WithMany("ArticleCategories")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.Category", b =>
                {
                    b.HasOne("Model.Category", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("Model.Manager", b =>
                {
                    b.HasOne("Model.ManagerRole", "ManagerRole")
                        .WithMany("Managers")
                        .HasForeignKey("roleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Model.ManagerRoleValue", b =>
                {
                    b.HasOne("Model.ManagerRole", "ManagerRole")
                        .WithMany("ManagerRoleValues")
                        .HasForeignKey("ManagerRoleId");

                    b.HasOne("Model.SysChannel", "SysChannel")
                        .WithMany("ManagerRoleValues")
                        .HasForeignKey("SysChannelId");
                });

            modelBuilder.Entity("Model.SysChannel", b =>
                {
                    b.HasOne("Model.SysChannel", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("parentId");
                });
        }
    }
}
