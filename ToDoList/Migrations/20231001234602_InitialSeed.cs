using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ToDoList.Migrations
{
    /// <inheritdoc />
    public partial class InitialSeed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Items",
                columns: new[] { "TaskID", "Category", "CreatedBy", "Description", "DueDate", "Status", "Title" },
                values: new object[,]
                {
                    { "a1bCdEf2Gh", 0, "emily_wilson", "Finalize and submit the project proposal", new DateTime(2023, 9, 24, 9, 30, 0, 0, DateTimeKind.Unspecified), 0, "Complete Project Proposal" },
                    { "A9bBmCnDoE", 1, "admin_user", "Pay the monthly rent for the apartment", new DateTime(2023, 10, 12, 9, 0, 0, 0, DateTimeKind.Unspecified), 0, "Pay Rent" },
                    { "B0cDnEoFpG", 0, "admin_user", "Research and compare new tech gadgets", new DateTime(2023, 10, 13, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, "Research New Tech Gadgets" },
                    { "b2CkLmN3Op", 1, "john_doe", "Give Mom a call and catch up", new DateTime(2023, 9, 25, 14, 15, 0, 0, DateTimeKind.Unspecified), 1, "Call Mom" },
                    { "c3DnOpQ4Rs", 1, "jane_smith", "Pay the electricity and water bills", new DateTime(2023, 9, 26, 16, 0, 0, 0, DateTimeKind.Unspecified), 0, "Pay Utility Bills" },
                    { "d4EpQrS5Tu", 0, "alice_jones", "Update the resume with recent achievements", new DateTime(2023, 9, 27, 10, 45, 0, 0, DateTimeKind.Unspecified), 1, "Update Resume" },
                    { "e5FqRsT6Vw", 2, "bob_smith", "Attend the online webinar on artificial intelligence", new DateTime(2023, 9, 28, 13, 30, 0, 0, DateTimeKind.Unspecified), 2, "Attend Webinar on AI" },
                    { "f6GsTuV7Wx", 0, "sarah_davis", "Write a blog post about the latest tech trends", new DateTime(2023, 9, 29, 15, 45, 0, 0, DateTimeKind.Unspecified), 0, "Write Blog Post" },
                    { "g7HtUvW8Xy", 0, "mike_adams", "Review and provide feedback on the project code", new DateTime(2023, 9, 30, 12, 15, 0, 0, DateTimeKind.Unspecified), 1, "Review Code for Project" },
                    { "h8IuWxY9Zz", 3, "admin_user", "Plan a surprise anniversary celebration", new DateTime(2023, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), 2, "Plan Anniversary Celebration" },
                    { "i9JvXyZ1Aa", 1, "admin_user", "Schedule a dental checkup appointment", new DateTime(2023, 10, 2, 9, 30, 0, 0, DateTimeKind.Unspecified), 0, "Schedule Dentist Appointment" },
                    { "j0KwYz1BbC", 3, "admin_user", "Research potential vacation destinations", new DateTime(2023, 10, 3, 14, 45, 0, 0, DateTimeKind.Unspecified), 1, "Research Vacation Destinations" },
                    { "k1LxZ2CcDd", 0, "emily_wilson", "Prepare a presentation for an upcoming meeting", new DateTime(2023, 10, 4, 11, 0, 0, 0, DateTimeKind.Unspecified), 0, "Create Presentation for Meeting" },
                    { "k9vZpMt0Ki", 0, "admin_user", "Plan a company retreat for team building", new DateTime(2023, 9, 23, 15, 0, 0, 0, DateTimeKind.Unspecified), 2, "Plan Company Retreat" },
                    { "m2NyZ3OdPe", 1, "john_doe", "Buy groceries for the family", new DateTime(2023, 10, 5, 16, 30, 0, 0, DateTimeKind.Unspecified), 1, "Grocery Shopping" },
                    { "o3PzA4QeRf", 1, "jane_smith", "Make a payment for the credit card bill", new DateTime(2023, 10, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), 0, "Pay Credit Card Bill" },
                    { "p8qOsXe1Lf", 0, "admin_user", "Submit expense reports for reimbursement", new DateTime(2023, 9, 22, 13, 45, 0, 0, DateTimeKind.Unspecified), 1, "Submit Expense Reports" },
                    { "q1j9rEh2Xw", 1, "john_doe", "Buy groceries for the week", new DateTime(2023, 9, 15, 10, 0, 0, 0, DateTimeKind.Unspecified), 0, "Buy Groceries" },
                    { "q4RsT5UfSg", 0, "alice_jones", "Prepare a report on current market trends", new DateTime(2023, 10, 7, 12, 30, 0, 0, DateTimeKind.Unspecified), 1, "Write Report on Market Trends" },
                    { "s2kDfPz8Tm", 0, "jane_smith", "Finish the project report for the presentation", new DateTime(2023, 9, 16, 14, 30, 0, 0, DateTimeKind.Unspecified), 1, "Finish Project Report" },
                    { "s5TuV6WgXh", 1, "bob_smith", "Take the dog for a walk in the park", new DateTime(2023, 10, 8, 17, 0, 0, 0, DateTimeKind.Unspecified), 2, "Walk the Dog" },
                    { "t3mHxVz7Yn", 0, "alice_jones", "Attend the weekly team meeting", new DateTime(2023, 9, 17, 12, 0, 0, 0, DateTimeKind.Unspecified), 2, "Attend Team Meeting" },
                    { "u6VwXyZiAj", 3, "sarah_davis", "Book flight tickets for the upcoming vacation", new DateTime(2023, 10, 9, 8, 45, 0, 0, DateTimeKind.Unspecified), 0, "Book Flight Tickets" },
                    { "w4oPqRv5Au", 3, "bob_smith", "Plan a weekend getaway with friends", new DateTime(2023, 9, 18, 9, 45, 0, 0, DateTimeKind.Unspecified), 0, "Plan Weekend Getaway" },
                    { "w7XyZ1AkBl", 2, "mike_adams", "Attend the coding bootcamp workshop", new DateTime(2023, 10, 10, 13, 15, 0, 0, DateTimeKind.Unspecified), 1, "Attend Coding Bootcamp" },
                    { "x7tLrNm9Dz", 0, "admin_user", "Review the quarterly financial report", new DateTime(2023, 9, 21, 11, 30, 0, 0, DateTimeKind.Unspecified), 0, "Review Quarterly Report" },
                    { "y5uJwQb4Bv", 2, "sarah_davis", "Study and prepare for the upcoming exam", new DateTime(2023, 9, 19, 17, 15, 0, 0, DateTimeKind.Unspecified), 1, "Prepare for Exam" },
                    { "z6vKxUc3Cx", 1, "mike_adams", "Hit the gym for a workout session", new DateTime(2023, 9, 20, 8, 30, 0, 0, DateTimeKind.Unspecified), 2, "Workout at the Gym" },
                    { "z8Z1AaBmCn", 3, "admin_user", "Plan a surprise anniversary celebration", new DateTime(2023, 10, 11, 11, 45, 0, 0, DateTimeKind.Unspecified), 2, "Plan Anniversary Celebration" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "a1bCdEf2Gh");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "A9bBmCnDoE");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "B0cDnEoFpG");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "b2CkLmN3Op");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "c3DnOpQ4Rs");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "d4EpQrS5Tu");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "e5FqRsT6Vw");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "f6GsTuV7Wx");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "g7HtUvW8Xy");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "h8IuWxY9Zz");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "i9JvXyZ1Aa");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "j0KwYz1BbC");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "k1LxZ2CcDd");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "k9vZpMt0Ki");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "m2NyZ3OdPe");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "o3PzA4QeRf");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "p8qOsXe1Lf");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "q1j9rEh2Xw");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "q4RsT5UfSg");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "s2kDfPz8Tm");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "s5TuV6WgXh");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "t3mHxVz7Yn");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "u6VwXyZiAj");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "w4oPqRv5Au");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "w7XyZ1AkBl");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "x7tLrNm9Dz");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "y5uJwQb4Bv");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "z6vKxUc3Cx");

            migrationBuilder.DeleteData(
                table: "Items",
                keyColumn: "TaskID",
                keyValue: "z8Z1AaBmCn");
        }
    }
}
