using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SA_Walks.API.Migrations
{
    public partial class SeedingDataforDifficultiesandRegions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("78d9fb01-25b7-494c-8d4b-6c389e1b1e33"), "Medium" },
                    { new Guid("cb0df157-43ac-4a7a-9cc1-d5fdfe50236b"), "Easy" },
                    { new Guid("f5241c79-fea3-4330-b7c3-2a293330be89"), "Hard" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("1bb825d9-f26f-4c5c-a319-030a55aec9fc"), "FS", "Free State", null },
                    { new Guid("1dceacbf-1d64-4fb7-a45b-daeb1505ece4"), "L", "Limpopo", null },
                    { new Guid("52757937-a2e0-46bc-bbca-8cc05a9672ba"), "EC", "Eastern Cape", "https://www.southaustralia.com/globalassets/regions/sa/sa-region.jpg" },
                    { new Guid("7fdc10db-d19b-4190-8573-64ce42cf401a"), "GP", "Western Cape", "https://www.southaustralia.com/globalassets/regions/sa/sa-region.jpg" },
                    { new Guid("97fbee3a-a04d-4ab6-ba5e-54c0ce39ebfe"), "MPA", "Mpumalanga", "https://www.southaustralia.com/globalassets/regions/sa/sa-region.jpg" },
                    { new Guid("9f36b0fd-e93a-418a-84c9-d6bd773ee215"), "KZN", "KwaZulu-Natal", "https://www.southaustralia.com/globalassets/regions/sa/sa-region.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("78d9fb01-25b7-494c-8d4b-6c389e1b1e33"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("cb0df157-43ac-4a7a-9cc1-d5fdfe50236b"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("f5241c79-fea3-4330-b7c3-2a293330be89"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1bb825d9-f26f-4c5c-a319-030a55aec9fc"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("1dceacbf-1d64-4fb7-a45b-daeb1505ece4"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("52757937-a2e0-46bc-bbca-8cc05a9672ba"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("7fdc10db-d19b-4190-8573-64ce42cf401a"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("97fbee3a-a04d-4ab6-ba5e-54c0ce39ebfe"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("9f36b0fd-e93a-418a-84c9-d6bd773ee215"));
        }
    }
}
