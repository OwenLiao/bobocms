using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class alertManager : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_ManagerRole_ManagerRoleId",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Manager_ManagerRoleId",
                table: "Manager");

            migrationBuilder.DropColumn(
                name: "ManagerRoleId",
                table: "Manager");

            migrationBuilder.AlterColumn<int>(
                name: "RoleType",
                table: "ManagerRole",
                nullable: true,
                oldClrType: typeof(byte),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manager_roleId",
                table: "Manager",
                column: "roleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_ManagerRole_roleId",
                table: "Manager",
                column: "roleId",
                principalTable: "ManagerRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Manager_ManagerRole_roleId",
                table: "Manager");

            migrationBuilder.DropIndex(
                name: "IX_Manager_roleId",
                table: "Manager");

            migrationBuilder.AddColumn<int>(
                name: "ManagerRoleId",
                table: "Manager",
                nullable: true);

            migrationBuilder.AlterColumn<byte>(
                name: "RoleType",
                table: "ManagerRole",
                nullable: true,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Manager_ManagerRoleId",
                table: "Manager",
                column: "ManagerRoleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Manager_ManagerRole_ManagerRoleId",
                table: "Manager",
                column: "ManagerRoleId",
                principalTable: "ManagerRole",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
