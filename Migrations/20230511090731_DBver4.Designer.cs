﻿// <auto-generated />
using System;
using CheeseBurger.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CheeseBurger.Migrations
{
    [DbContext(typeof(CheeseBurgerContext))]
    [Migration("20230511090731_DBver4")]
    partial class DBver4
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CheeseBurger.Model.Entities.Account", b =>
                {
                    b.Property<int>("AccountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("isStaff")
                        .HasColumnType("bit");

                    b.HasKey("AccountID");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Cart", b =>
                {
                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("CustomerID", "FoodID");

                    b.HasIndex("FoodID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CategoryID"));

                    b.Property<string>("CategoryName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("CategoryID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int?>("WardID")
                        .HasColumnType("int");

                    b.HasKey("CustomerID");

                    b.HasIndex("AccountID");

                    b.HasIndex("WardID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.District", b =>
                {
                    b.Property<int>("DistrictID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DistrictID"));

                    b.Property<string>("DistrictName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("DistrictID");

                    b.ToTable("Districts");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Food", b =>
                {
                    b.Property<int>("FoodID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FoodID"));

                    b.Property<int?>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FoodName")
                        .IsRequired()
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageFood")
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.HasKey("FoodID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Foods");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Food_Ingredients", b =>
                {
                    b.Property<int>("FoodID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("IngredientsId")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<int>("QuantityIG")
                        .HasColumnType("int");

                    b.HasKey("FoodID", "IngredientsId");

                    b.HasIndex("IngredientsId");

                    b.ToTable("Food_Ingredients");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.ImportOrder", b =>
                {
                    b.Property<int>("ImportOrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ImportOrderID"));

                    b.Property<DateTime>("DateIO")
                        .HasColumnType("datetime2");

                    b.Property<int>("PartnerID")
                        .HasColumnType("int");

                    b.Property<int>("StaffID")
                        .HasColumnType("int");

                    b.Property<float>("TMoneyIO")
                        .HasColumnType("real");

                    b.HasKey("ImportOrderID");

                    b.HasIndex("PartnerID");

                    b.HasIndex("StaffID");

                    b.ToTable("ImportOrders");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.ImportOrders_Ingredients", b =>
                {
                    b.Property<int>("ImportOrderID")
                        .HasColumnType("int");

                    b.Property<int>("IngredientsID")
                        .HasColumnType("int");

                    b.Property<float>("PriceIO")
                        .HasColumnType("real");

                    b.Property<int>("QuantityIO")
                        .HasColumnType("int");

                    b.HasKey("ImportOrderID", "IngredientsID");

                    b.HasIndex("IngredientsID");

                    b.ToTable("ImportOrders_Ingredients");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Ingredients", b =>
                {
                    b.Property<int>("IngredientsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IngredientsId"));

                    b.Property<string>("IngredientsName")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<float>("IngredientsPrice")
                        .HasColumnType("real");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int>("MeasureID")
                        .HasColumnType("int");

                    b.Property<int>("PartnerID")
                        .HasColumnType("int");

                    b.HasKey("IngredientsId");

                    b.HasIndex("MeasureID");

                    b.HasIndex("PartnerID");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Measure", b =>
                {
                    b.Property<int>("MeasureID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MeasureID"));

                    b.Property<string>("MeasureName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("MeasureID");

                    b.ToTable("Measures");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Order_Food", b =>
                {
                    b.Property<int>("OrderID")
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    b.Property<int>("FoodID")
                        .HasColumnType("int")
                        .HasColumnOrder(2);

                    b.Property<float>("PriceOF")
                        .HasColumnType("real");

                    b.Property<int>("QuantityOF")
                        .HasColumnType("int");

                    b.HasKey("OrderID", "FoodID");

                    b.HasIndex("FoodID");

                    b.ToTable("Order_Foods");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Orders", b =>
                {
                    b.Property<int>("OrderID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("OrderID"));

                    b.Property<DateTime?>("ArriveTime")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ChefID")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HourseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Note")
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SaleDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ShipperID")
                        .HasColumnType("int");

                    b.Property<float>("ShippingMoney")
                        .HasColumnType("real");

                    b.Property<int>("StatusOdr")
                        .HasColumnType("int");

                    b.Property<float>("TempMoney")
                        .HasColumnType("real");

                    b.Property<float>("TotalMoney")
                        .HasColumnType("real");

                    b.Property<int>("WardID")
                        .HasColumnType("int");

                    b.HasKey("OrderID");

                    b.HasIndex("ChefID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ShipperID");

                    b.HasIndex("WardID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Partner", b =>
                {
                    b.Property<int>("PartnerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PartnerID"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PartnerName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("isDeleted")
                        .HasColumnType("bit");

                    b.HasKey("PartnerID");

                    b.ToTable("Partners");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Revenues", b =>
                {
                    b.Property<DateTime>("DateReve")
                        .HasColumnType("datetime2");

                    b.Property<float>("Fund")
                        .HasColumnType("real");

                    b.Property<float>("Income")
                        .HasColumnType("real");

                    b.Property<int>("NumberIOrder")
                        .HasColumnType("int");

                    b.Property<int>("NumberOrder")
                        .HasColumnType("int");

                    b.ToTable("Revenues");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Review", b =>
                {
                    b.Property<int>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReviewID"));

                    b.Property<string>("Content")
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateReview")
                        .HasColumnType("datetime2");

                    b.Property<int>("FoodID")
                        .HasColumnType("int");

                    b.Property<string>("Img")
                        .HasMaxLength(2147483647)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderID")
                        .HasColumnType("int");

                    b.Property<int>("Star")
                        .HasColumnType("int");

                    b.HasKey("ReviewID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("FoodID");

                    b.HasIndex("OrderID");

                    b.ToTable("Reviews");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Role", b =>
                {
                    b.Property<int>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoleID"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("RoleID");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Staff", b =>
                {
                    b.Property<int>("StaffID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StaffID"));

                    b.Property<int>("AccountID")
                        .HasColumnType("int");

                    b.Property<bool?>("Gender")
                        .HasColumnType("bit");

                    b.Property<string>("HouseNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<int>("RoleID")
                        .HasColumnType("int");

                    b.Property<string>("StaffName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("WardID")
                        .HasColumnType("int");

                    b.HasKey("StaffID");

                    b.HasIndex("AccountID");

                    b.HasIndex("RoleID");

                    b.HasIndex("WardID");

                    b.ToTable("Staffs");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Ward", b =>
                {
                    b.Property<int>("WardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("WardId"));

                    b.Property<int>("DistrictID")
                        .HasColumnType("int");

                    b.Property<string>("WardName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("WardId");

                    b.HasIndex("DistrictID");

                    b.ToTable("Wards");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Cart", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Food");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Customer", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Account");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Food", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Category");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Food_Ingredients", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Ingredients", "Ingredients")
                        .WithMany()
                        .HasForeignKey("IngredientsId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.ImportOrder", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Staff", "Staff")
                        .WithMany()
                        .HasForeignKey("StaffID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Partner");

                    b.Navigation("Staff");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.ImportOrders_Ingredients", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.ImportOrder", "ImportOrder")
                        .WithMany()
                        .HasForeignKey("ImportOrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Ingredients", "Ingredients")
                        .WithMany()
                        .HasForeignKey("IngredientsID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ImportOrder");

                    b.Navigation("Ingredients");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Ingredients", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Measure", "Measure")
                        .WithMany()
                        .HasForeignKey("MeasureID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Partner", "Partner")
                        .WithMany()
                        .HasForeignKey("PartnerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Measure");

                    b.Navigation("Partner");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Order_Food", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Orders", "Orders")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Food");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Orders", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Staff", "ChefStaff")
                        .WithMany()
                        .HasForeignKey("ChefID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CheeseBurger.Model.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Staff", "ShipperStaff")
                        .WithMany()
                        .HasForeignKey("ShipperID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CheeseBurger.Model.Entities.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChefStaff");

                    b.Navigation("Customer");

                    b.Navigation("ShipperStaff");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Review", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Food", "Food")
                        .WithMany()
                        .HasForeignKey("FoodID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Orders", "Orders")
                        .WithMany()
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Food");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Staff", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CheeseBurger.Model.Entities.Ward", "Ward")
                        .WithMany()
                        .HasForeignKey("WardID")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Account");

                    b.Navigation("Role");

                    b.Navigation("Ward");
                });

            modelBuilder.Entity("CheeseBurger.Model.Entities.Ward", b =>
                {
                    b.HasOne("CheeseBurger.Model.Entities.District", "District")
                        .WithMany()
                        .HasForeignKey("DistrictID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("District");
                });
#pragma warning restore 612, 618
        }
    }
}