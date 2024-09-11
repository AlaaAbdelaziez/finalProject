using finalProject.Models;
using Microsoft.EntityFrameworkCore;


namespace finalProject.Context
{
    public class ShopContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-AI8IE2R;Database=FinalProject;Trusted_Connection=True;Encrypt=false");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Categories = new List<Category>
            {
                new Category{CategoryId=1,Name="Bags&Luggage",Description="Women bags,Wallets,Bag Accessories,Men Bag,Luggage and Travel Gear"},
                new Category{CategoryId=2,Name="Sports&Outdoor",Description="Women Activewear,Men Activewear,Sports & Outdoor Shoes"},
                new Category{CategoryId=3,Name="Office & School Supplies",Description="Notebooks & Writing Pads,Filing products,Calenders & Cards,Art Supplies"},
                new Category{CategoryId=4,Name="Jewelry &Accessories",Description="Women Accessories,Women Hair Accessories,Gender Neutral Accessories,Men Accessories"}
            };
            var _Products = new List<Product> {
                new Product{ProductId=1,Title="Women's vintage Saddle bag",Price=450,Description="Women Vintage Coffee Brown Saddle Bag,Wide Strap Crossbody Bag,PU leather shoulder purse",Quantity=4,ImagePath="~/Images/coffeebrownwomenbag.jpg",CategoryId=1},
                new Product{ProductId=2,Title="Portable Cosmetic Bag",Price=110,Description="Hand-Painted Mushroom Pattern Print Corduroy Zipper Pouch, Portable Cosmetic Bag With Lining, Multifunctional Toiletry Organizer, Polyester Material, Unscented, Unisex-Adult, Non-Waterproof",Quantity=10,ImagePath="~/Images/cosemeticbag.jpg",CategoryId=1},
                new Product{ProductId=3,Title="Book Backpack",Price=590,Description="Book Backpack Flap Backpack Waterproof Portable For Travel Vacation Work Office Sport Gym Outdoor Nylon Casual For Student Boys College Student Teens Senior High School Student Rucksack Fathers Day Gifts Summer College Bag Dad School Bag FreshmanFor Books Back To School Multi-Functional Dorm University Man Bag School Backpack Students School Supplies Book Bag Large Capacity School Pencil Case Teacher Halloween Christmas Gift For Men Bag For School",Quantity=6,ImagePath="~/Images/blackbookbackpack.jpg",CategoryId=1},
                new Product{ProductId=4,Title="Sports resistance band",Price=60,Description="3pcs Sports Resistance Band",Quantity=8,ImagePath="~/Images/resistanceband.jpg",CategoryId=2},
                new Product{ProductId=5,Title="Sports Snesker",Price=850,Description="1pair Women's Sports & Casual Chunky Sneakers, Versatile Chunky Sneakers",Quantity=3,ImagePath="~/Images/sportssneaker.jpg",CategoryId=2},
                new Product{ProductId=6,Title="Yoga mat",Price=740,Description="1pc 173*57*0.6cm TPE Yoga Mat For Beginners Exercise, Dancing, Non-Slip & Shock-Absorbing",Quantity=9,ImagePath="~/Images/yogamat.jpg",CategoryId=2},
                new Product{ProductId=7,Title="Pencil Case",Price=60,Description="1pc Floral Pattern Printed Corduroy Pencil Case, Stationery Storage Bag, Double-Sided Printed Pen Case, Portable Multifunctional Office Stationery Pencil Organizer",Quantity=7,ImagePath="~/Images/pencilcase.jpg",CategoryId=3},
                new Product{ProductId=8,Title="Notebook",Price=200,Description="Flower Patterned Artistic Notebook With Fabric Cover, High Aesthetic Value",Quantity=13,ImagePath="~/Images/notebook.jpg",CategoryId=3},
                new Product{ProductId=9,Title="Head band",Price=60,Description="Elegant 1pc Simple Alloy Headband With Pearl & Flower & Rhinestone Decor For Women",Quantity=8,ImagePath="~/Images/headband.jpg",CategoryId=4}
            };

            modelBuilder.Entity<Category>().HasData(_Categories);
            modelBuilder.Entity<Product>().HasData(_Products);
        }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
