using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace demo_entity_framework_core.Migrations
{
    /// <inheritdoc />
    public partial class seedingData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
            table: "categories",
	        columns: new[] {"Id", "Name" },
	        values: new object[] { "EFD2AB19-BD45-48E0-DA90-08DB9FB57EB7" , "Category A" }
            );
			migrationBuilder.InsertData(
			table: "categories",
			columns: new[] { "Id", "Name" },
			values: new object[] { "D48B2247-0F86-4CAA-5784-08DB9FE27B9B", "Category B" }
			);
			migrationBuilder.InsertData(
			table: "categories",
			columns: new[] { "Id", "Name" },
			values: new object[] { "1739F48C-2E6D-4DD4-1529-08DBC0BF125E", "Category C" }
			);


			migrationBuilder.InsertData(
			table: "products",
			columns: new[] { "Id", "Name" , "Description" , "Price" , "CategoryId"},
			values: new object[] { "1739F48C-2E7D-4DD4-1529-08DBC0CD125E", "Product A" , "Description Product A" , 50.5 , "EFD2AB19-BD45-48E0-DA90-08DB9FB57EB7" }
			);

			migrationBuilder.InsertData(
			table: "products",
			columns: new[] {"Id", "Name", "Description", "Price", "CategoryId" },
			values: new object[] { "1839F48C-2E7D-4DD5-1529-08DBC0CD125E", "Product B", "Description Product B", 125.4, "1739F48C-2E6D-4DD4-1529-08DBC0BF125E" }
			);
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

		}
    }
}
