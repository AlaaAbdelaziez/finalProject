using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace finalProject.Migrations
{
    /// <inheritdoc />
    public partial class first : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ProductId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ProductId);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CategoryId", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Women bags,Wallets,Bag Accessories,Men Bag,Luggage and Travel Gear", "Bags&Luggage" },
                    { 2, "Women Activewear,Men Activewear,Sports & Outdoor Shoes", "Sports&Outdoor" },
                    { 3, "Notebooks & Writing Pads,Filing products,Calenders & Cards,Art Supplies", "Office & School Supplies" },
                    { 4, "Women Accessories,Women Hair Accessories,Gender Neutral Accessories,Men Accessories", "Jewelry &Accessories" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "ProductId", "CategoryId", "Description", "ImagePath", "Price", "Quantity", "Title" },
                values: new object[,]
                {
                    { 1, 1, "Women Vintage Coffee Brown Saddle Bag,Wide Strap Crossbody Bag,PU leather shoulder purse", "~/Images/coffeebrownwomenbag.jpg", 450m, 4, "Women's vintage Saddle bag" },
                    { 2, 1, "Hand-Painted Mushroom Pattern Print Corduroy Zipper Pouch, Portable Cosmetic Bag With Lining, Multifunctional Toiletry Organizer, Polyester Material, Unscented, Unisex-Adult, Non-Waterproof", "~/Images/cosemeticbag.jpg", 110m, 10, "Portable Cosmetic Bag" },
                    { 3, 1, "Book Backpack Flap Backpack Waterproof Portable For Travel Vacation Work Office Sport Gym Outdoor Nylon Casual For Student Boys College Student Teens Senior High School Student Rucksack Fathers Day Gifts Summer College Bag Dad School Bag FreshmanFor Books Back To School Multi-Functional Dorm University Man Bag School Backpack Students School Supplies Book Bag Large Capacity School Pencil Case Teacher Halloween Christmas Gift For Men Bag For School", "~/Images/blackbookbackpack.jpg", 590m, 6, "Book Backpack" },
                    { 4, 2, "3pcs Sports Resistance Band", "~/Images/resistanceband.jpg", 60m, 8, "Sports resistance band" },
                    { 5, 2, "1pair Women's Sports & Casual Chunky Sneakers, Versatile Chunky Sneakers", "~/Images/sportssneaker.jpg", 850m, 3, "Sports Snesker" },
                    { 6, 2, "1pc 173*57*0.6cm TPE Yoga Mat For Beginners Exercise, Dancing, Non-Slip & Shock-Absorbing", "~/Images/yogamat.jpg", 740m, 9, "Yoga mat" },
                    { 7, 3, "1pc Floral Pattern Printed Corduroy Pencil Case, Stationery Storage Bag, Double-Sided Printed Pen Case, Portable Multifunctional Office Stationery Pencil Organizer", "~/Images/pencilcase.jpg", 60m, 7, "Pencil Case" },
                    { 8, 3, "Flower Patterned Artistic Notebook With Fabric Cover, High Aesthetic Value", "~/Images/notebook.jpg", 200m, 13, "Notebook" },
                    { 9, 4, "Elegant 1pc Simple Alloy Headband With Pearl & Flower & Rhinestone Decor For Women", "~/Images/headband.jpg", 60m, 8, "Head band" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
