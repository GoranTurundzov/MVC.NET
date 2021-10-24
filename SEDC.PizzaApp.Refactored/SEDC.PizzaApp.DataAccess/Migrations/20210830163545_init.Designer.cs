﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SEDC.PizzaApp.DataAccess;

namespace SEDC.PizzaApp.DataAccess.Migrations
{
    [DbContext(typeof(PizzaDbContext))]
    [Migration("20210830163545_init")]
    partial class init
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.18")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Delivered")
                        .HasColumnType("bit");

                    b.Property<int>("PaymentMethod")
                        .HasColumnType("int");

                    b.Property<string>("PizzaStore")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Orders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Delivered = true,
                            PaymentMethod = 2,
                            PizzaStore = "Pizza store Skopje",
                            UserId = 1
                        },
                        new
                        {
                            Id = 2,
                            Delivered = false,
                            PaymentMethod = 2,
                            PizzaStore = "Pizza store Skopje",
                            UserId = 1
                        },
                        new
                        {
                            Id = 3,
                            Delivered = true,
                            PaymentMethod = 1,
                            PizzaStore = "Pizza store Skopje",
                            UserId = 2
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Pizza", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsOnPromotion")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PizzaSize")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Pizzas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Image = "Kapri.png",
                            IsOnPromotion = false,
                            Name = "Kapri",
                            PizzaSize = 1,
                            Price = 7.0
                        },
                        new
                        {
                            Id = 2,
                            Image = "Kapri.png",
                            IsOnPromotion = false,
                            Name = "Kapri",
                            PizzaSize = 2,
                            Price = 7.0
                        },
                        new
                        {
                            Id = 3,
                            Image = "Kapri.png",
                            IsOnPromotion = false,
                            Name = "Kapri",
                            PizzaSize = 3,
                            Price = 7.0
                        },
                        new
                        {
                            Id = 4,
                            Image = "Peperoni.png",
                            IsOnPromotion = false,
                            Name = "Peperoni",
                            PizzaSize = 1,
                            Price = 9.0
                        },
                        new
                        {
                            Id = 5,
                            Image = "Peperoni.png",
                            IsOnPromotion = false,
                            Name = "Peperoni",
                            PizzaSize = 2,
                            Price = 8.0
                        },
                        new
                        {
                            Id = 6,
                            Image = "Peperoni.png",
                            IsOnPromotion = false,
                            Name = "Peperoni",
                            PizzaSize = 3,
                            Price = 8.0
                        },
                        new
                        {
                            Id = 7,
                            Image = "Margarita.png",
                            IsOnPromotion = false,
                            Name = "Margarita",
                            PizzaSize = 1,
                            Price = 10.5
                        },
                        new
                        {
                            Id = 8,
                            Image = "Margarita.png",
                            IsOnPromotion = false,
                            Name = "Margarita",
                            PizzaSize = 2,
                            Price = 10.5
                        },
                        new
                        {
                            Id = 9,
                            Image = "Margarita.png",
                            IsOnPromotion = false,
                            Name = "Margarita",
                            PizzaSize = 3,
                            Price = 10.5
                        },
                        new
                        {
                            Id = 10,
                            Image = "Siciliana.png",
                            IsOnPromotion = false,
                            Name = "Siciliana",
                            PizzaSize = 1,
                            Price = 6.5
                        },
                        new
                        {
                            Id = 11,
                            Image = "Siciliana.png",
                            IsOnPromotion = false,
                            Name = "Siciliana",
                            PizzaSize = 2,
                            Price = 9.5
                        },
                        new
                        {
                            Id = 12,
                            Image = "Siciliana.png",
                            IsOnPromotion = false,
                            Name = "Siciliana",
                            PizzaSize = 3,
                            Price = 9.5
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("PizzaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("PizzaId");

                    b.ToTable("PizzaOrder");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            OrderId = 1,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 2,
                            OrderId = 1,
                            PizzaId = 4
                        },
                        new
                        {
                            Id = 3,
                            OrderId = 2,
                            PizzaId = 1
                        },
                        new
                        {
                            Id = 4,
                            OrderId = 2,
                            PizzaId = 5
                        },
                        new
                        {
                            Id = 5,
                            OrderId = 2,
                            PizzaId = 7
                        },
                        new
                        {
                            Id = 6,
                            OrderId = 3,
                            PizzaId = 5
                        },
                        new
                        {
                            Id = 7,
                            OrderId = 3,
                            PizzaId = 9
                        },
                        new
                        {
                            Id = 8,
                            OrderId = 3,
                            PizzaId = 12
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Bob Street",
                            FirstName = "Bob",
                            LastName = "Bobsky",
                            Phone = 1231123123123L,
                            UserId = 0
                        },
                        new
                        {
                            Id = 2,
                            Address = "Jill Street",
                            FirstName = "Jill",
                            LastName = "Wayne",
                            Phone = 80044455123L,
                            UserId = 0
                        });
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.Order", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.User", "User")
                        .WithMany("Orders")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SEDC.PizzaApp.Domain.Models.PizzaOrder", b =>
                {
                    b.HasOne("SEDC.PizzaApp.Domain.Models.Order", "Order")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SEDC.PizzaApp.Domain.Models.Pizza", "Pizza")
                        .WithMany("PizzaOrders")
                        .HasForeignKey("PizzaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
