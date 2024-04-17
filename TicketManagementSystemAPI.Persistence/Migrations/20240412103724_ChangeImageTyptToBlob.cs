using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TicketManagementSystemAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class ChangeImageTyptToBlob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("095d3fd9-9566-4614-9be9-1551757fbc21"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("2ba49616-c284-42c0-b883-487910d8eca0"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("85618527-db95-474e-b0fd-44de0bb11c36"));

            migrationBuilder.DeleteData(
                table: "Tickets",
                keyColumn: "TicketId",
                keyValue: new Guid("997da3fc-168a-4ebb-b8b0-f8727ddb6f34"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Events");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Events",
                type: "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                columns: new[] { "Date", "Image" },
                values: new object[] { new DateTime(2025, 2, 12, 13, 37, 23, 969, DateTimeKind.Local).AddTicks(8226), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                columns: new[] { "Date", "Image" },
                values: new object[] { new DateTime(2025, 1, 12, 13, 37, 23, 969, DateTimeKind.Local).AddTicks(8194), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                columns: new[] { "Date", "Image" },
                values: new object[] { new DateTime(2024, 8, 12, 13, 37, 23, 969, DateTimeKind.Local).AddTicks(8216), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                columns: new[] { "Date", "Image" },
                values: new object[] { new DateTime(2024, 12, 12, 13, 37, 23, 969, DateTimeKind.Local).AddTicks(8236), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                columns: new[] { "Date", "Image" },
                values: new object[] { new DateTime(2024, 8, 12, 13, 37, 23, 969, DateTimeKind.Local).AddTicks(8205), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "Date", "Image" },
                values: new object[] { new DateTime(2024, 10, 12, 13, 37, 23, 969, DateTimeKind.Local).AddTicks(8113), null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "Events");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2024, 12, 21, 16, 50, 59, 702, DateTimeKind.Local).AddTicks(7316), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/conf.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2024, 11, 21, 16, 50, 59, 702, DateTimeKind.Local).AddTicks(7290), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/michael.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2024, 6, 21, 16, 50, 59, 702, DateTimeKind.Local).AddTicks(7308), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/guitar.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2024, 10, 21, 16, 50, 59, 702, DateTimeKind.Local).AddTicks(7328), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/musical.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2024, 6, 21, 16, 50, 59, 702, DateTimeKind.Local).AddTicks(7299), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/dj.jpg" });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "Date", "ImageUrl" },
                values: new object[] { new DateTime(2024, 8, 21, 16, 50, 59, 702, DateTimeKind.Local).AddTicks(7227), "https://gillcleerenpluralsight.blob.core.windows.net/files/GloboTicket/banjo.jpg" });

            migrationBuilder.InsertData(
                table: "Tickets",
                columns: new[] { "TicketId", "EventId", "OrderId", "Price", "Quantity" },
                values: new object[,]
                {
                    { new Guid("095d3fd9-9566-4614-9be9-1551757fbc21"), new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"), new Guid("d197c147-0be8-4955-9f7a-e491bc080895"), 65, 4 },
                    { new Guid("2ba49616-c284-42c0-b883-487910d8eca0"), new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"), new Guid("742b3685-fea6-4b34-b0f1-f79e6845a44d"), 135, 1 },
                    { new Guid("85618527-db95-474e-b0fd-44de0bb11c36"), new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"), new Guid("d197c147-0be8-4955-9f7a-e491bc080895"), 400, 1 },
                    { new Guid("997da3fc-168a-4ebb-b8b0-f8727ddb6f34"), new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"), new Guid("94dc670d-da05-4777-b647-bf6530d00c74"), 85, 1 }
                });
        }
    }
}
