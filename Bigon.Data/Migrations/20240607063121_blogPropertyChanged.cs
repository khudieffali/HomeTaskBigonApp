using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BigonApp.Migrations
{
    /// <inheritdoc />
    public partial class blogPropertyChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BlogCategoryId1",
                table: "Blogs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedAt",
                table: "Blogs",
                type: "datetime",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PublishedBy",
                table: "Blogs",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "Blogs",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_BlogCategoryId1",
                table: "Blogs",
                column: "BlogCategoryId1");

            migrationBuilder.CreateIndex(
                name: "IX_Blogs_Slug",
                table: "Blogs",
                column: "Slug",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId1",
                table: "Blogs",
                column: "BlogCategoryId1",
                principalTable: "BlogCategories",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Blogs_BlogCategories_BlogCategoryId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_BlogCategoryId1",
                table: "Blogs");

            migrationBuilder.DropIndex(
                name: "IX_Blogs_Slug",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "BlogCategoryId1",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PublishedAt",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "PublishedBy",
                table: "Blogs");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "Blogs");
        }
    }
}
