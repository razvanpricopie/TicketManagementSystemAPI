using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TicketManagementSystemAPI.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationPropertyToEvent : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Events",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                columns: new[] { "Date", "Location" },
                values: new object[] { new DateTime(2024, 9, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6842), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                columns: new[] { "Date", "Location" },
                values: new object[] { new DateTime(2024, 8, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6777), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                columns: new[] { "Date", "Location" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6812), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                columns: new[] { "Date", "Location" },
                values: new object[] { new DateTime(2024, 7, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6861), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                columns: new[] { "Date", "Location" },
                values: new object[] { new DateTime(2024, 3, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6796), null });

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                columns: new[] { "Date", "Location" },
                values: new object[] { new DateTime(2024, 5, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6609), null });

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "Date",
                value: new DateTime(2023, 11, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6944));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "Date",
                value: new DateTime(2023, 11, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6930));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "Date",
                value: new DateTime(2023, 11, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6895));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "Date",
                value: new DateTime(2023, 11, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6915));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "Date",
                value: new DateTime(2023, 11, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6989));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "Date",
                value: new DateTime(2023, 11, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6959));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "Date",
                value: new DateTime(2023, 11, 26, 15, 11, 23, 955, DateTimeKind.Local).AddTicks(6974));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Location",
                table: "Events");

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("1babd057-e980-4cb3-9cd2-7fdd9e525668"),
                column: "Date",
                value: new DateTime(2024, 8, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6779));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("3448d5a4-0f72-4dd7-bf15-c14a46b26c00"),
                column: "Date",
                value: new DateTime(2024, 7, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6753));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("62787623-4c52-43fe-b0c9-b7044fb5929b"),
                column: "Date",
                value: new DateTime(2024, 2, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6770));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("adc42c09-08c1-4d2c-9f96-2d15bb1af299"),
                column: "Date",
                value: new DateTime(2024, 6, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6814));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("b419a7ca-3321-4f38-be8e-4d7b6a529319"),
                column: "Date",
                value: new DateTime(2024, 2, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6762));

            migrationBuilder.UpdateData(
                table: "Events",
                keyColumn: "EventId",
                keyValue: new Guid("ee272f8b-6096-4cb6-8625-bb4bb2d89e8b"),
                column: "Date",
                value: new DateTime(2024, 4, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6682));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("3dcb3ea0-80b1-4781-b5c0-4d85c41e55a6"),
                column: "Date",
                value: new DateTime(2023, 10, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6857));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("771cca4b-066c-4ac7-b3df-4d12837fe7e0"),
                column: "Date",
                value: new DateTime(2023, 10, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6849));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("7e94bc5b-71a5-4c8c-bc3b-71bb7976237e"),
                column: "Date",
                value: new DateTime(2023, 10, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6829));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("86d3a045-b42d-4854-8150-d6a374948b6e"),
                column: "Date",
                value: new DateTime(2023, 10, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6840));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("ba0eb0ef-b69b-46fd-b8e2-41b4178ae7cb"),
                column: "Date",
                value: new DateTime(2023, 10, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("e6a2679c-79a3-4ef1-a478-6f4c91b405b6"),
                column: "Date",
                value: new DateTime(2023, 10, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6865));

            migrationBuilder.UpdateData(
                table: "Orders",
                keyColumn: "Id",
                keyValue: new Guid("f5a6a3a0-4227-4973-abb5-a63fbe725923"),
                column: "Date",
                value: new DateTime(2023, 10, 20, 14, 52, 16, 910, DateTimeKind.Local).AddTicks(6874));
        }
    }
}
