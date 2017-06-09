using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class AddManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ManagerLog",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActionType = table.Column<string>(nullable: true),
                    LoginIp = table.Column<string>(nullable: true),
                    LoginTime = table.Column<DateTime>(nullable: true),
                    Note = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true),
                    userId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerLog", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ManagerRole",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    RoleName = table.Column<string>(nullable: true),
                    RoleType = table.Column<byte>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerRole", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SysChannel",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    Description = table.Column<string>(nullable: true),
                    ImgUrl = table.Column<string>(nullable: true),
                    LinkUrl = table.Column<string>(nullable: true),
                    Name = table.Column<string>(nullable: false),
                    SortId = table.Column<int>(nullable: false),
                    Title = table.Column<string>(nullable: false),
                    parentId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SysChannel", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SysChannel_SysChannel_parentId",
                        column: x => x.parentId,
                        principalTable: "SysChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Manager",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    AddTime = table.Column<DateTime>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    IsLock = table.Column<int>(nullable: true),
                    ManagerRoleId = table.Column<int>(nullable: true),
                    RealName = table.Column<string>(nullable: true),
                    RoleType = table.Column<int>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: false),
                    UserPwd = table.Column<string>(maxLength: 100, nullable: false),
                    roleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manager", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Manager_ManagerRole_ManagerRoleId",
                        column: x => x.ManagerRoleId,
                        principalTable: "ManagerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ManagerRoleValue",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySQL:AutoIncrement", true),
                    ActionType = table.Column<string>(nullable: true),
                    ChannelName = table.Column<string>(nullable: true),
                    ManagerRoleId = table.Column<int>(nullable: true),
                    SysChannelId = table.Column<int>(nullable: true),
                    channelId = table.Column<int>(nullable: true),
                    roleId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ManagerRoleValue", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ManagerRoleValue_ManagerRole_ManagerRoleId",
                        column: x => x.ManagerRoleId,
                        principalTable: "ManagerRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ManagerRoleValue_SysChannel_SysChannelId",
                        column: x => x.SysChannelId,
                        principalTable: "SysChannel",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ManagerRoleId",
                table: "Manager",
                column: "ManagerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerRoleValue_ManagerRoleId",
                table: "ManagerRoleValue",
                column: "ManagerRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_ManagerRoleValue_SysChannelId",
                table: "ManagerRoleValue",
                column: "SysChannelId");

            migrationBuilder.CreateIndex(
                name: "IX_SysChannel_parentId",
                table: "SysChannel",
                column: "parentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Manager");

            migrationBuilder.DropTable(
                name: "ManagerLog");

            migrationBuilder.DropTable(
                name: "ManagerRoleValue");

            migrationBuilder.DropTable(
                name: "ManagerRole");

            migrationBuilder.DropTable(
                name: "SysChannel");
        }
    }
}
