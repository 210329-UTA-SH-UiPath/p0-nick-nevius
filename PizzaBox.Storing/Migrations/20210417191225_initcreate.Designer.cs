﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PizzaBox.Storing.Entities;

namespace PizzaBox.Storing.Migrations
{
    [DbContext(typeof(AnimalsDbContext))]
    [Migration("20210417191225_initcreate")]
    partial class initcreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.5")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("OrderPizza", b =>
                {
                    b.Property<int>("OrdersID")
                        .HasColumnType("int");

                    b.Property<int>("PizzasID")
                        .HasColumnType("int");

                    b.HasKey("OrdersID", "PizzasID");

                    b.HasIndex("PizzasID");

                    b.ToTable("OrderPizza");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Crust", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CrustType")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CrustType")
                        .IsUnique();

                    b.ToTable("Crusts");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerID")
                        .HasColumnType("int");

                    b.Property<int?>("StoreID")
                        .HasColumnType("int");

                    b.Property<DateTime>("TimePlaced")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("StoreID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Pizza", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CrustID")
                        .HasColumnType("int");

                    b.Property<int>("PizzaType")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int?>("SizeID")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("CrustID");

                    b.HasIndex("SizeID");

                    b.ToTable("Pizzas");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Size", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SizeType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("SizeType")
                        .IsUnique();

                    b.ToTable("Sizes");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Store", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("StoreType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("Name")
                        .IsUnique();

                    b.ToTable("Stores");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Topping", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ToppingType")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("ToppingType")
                        .IsUnique();

                    b.ToTable("Toppings");
                });

            modelBuilder.Entity("PizzaTopping", b =>
                {
                    b.Property<int>("PizzasID")
                        .HasColumnType("int");

                    b.Property<int>("ToppingsID")
                        .HasColumnType("int");

                    b.HasKey("PizzasID", "ToppingsID");

                    b.HasIndex("ToppingsID");

                    b.ToTable("PizzaTopping");
                });

            modelBuilder.Entity("OrderPizza", b =>
                {
                    b.HasOne("PizzaBox.Storing.Entities.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Storing.Entities.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Order", b =>
                {
                    b.HasOne("PizzaBox.Storing.Entities.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerID");

                    b.HasOne("PizzaBox.Storing.Entities.Store", "Store")
                        .WithMany()
                        .HasForeignKey("StoreID");

                    b.Navigation("Customer");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("PizzaBox.Storing.Entities.Pizza", b =>
                {
                    b.HasOne("PizzaBox.Storing.Entities.Crust", "Crust")
                        .WithMany()
                        .HasForeignKey("CrustID");

                    b.HasOne("PizzaBox.Storing.Entities.Size", "Size")
                        .WithMany()
                        .HasForeignKey("SizeID");

                    b.Navigation("Crust");

                    b.Navigation("Size");
                });

            modelBuilder.Entity("PizzaTopping", b =>
                {
                    b.HasOne("PizzaBox.Storing.Entities.Pizza", null)
                        .WithMany()
                        .HasForeignKey("PizzasID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PizzaBox.Storing.Entities.Topping", null)
                        .WithMany()
                        .HasForeignKey("ToppingsID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}