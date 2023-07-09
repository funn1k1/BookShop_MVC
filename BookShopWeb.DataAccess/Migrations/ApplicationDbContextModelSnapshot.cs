﻿// <auto-generated />
using System;
using BookShopWeb.DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookShopWeb.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookShopWeb.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("AvailableQuantity")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("CoverImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountedPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("ISBN")
                        .IsRequired()
                        .HasMaxLength(13)
                        .HasColumnType("nvarchar(13)");

                    b.Property<decimal>("ListPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PublicationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Valerio De Sanctis",
                            AvailableQuantity = 100,
                            CategoryId = 2,
                            CoverImageUrl = "https://m.media-amazon.com/images/I/411LNpmcEnL._SX260_.jpg",
                            Description = "Building Web APIs with ASP.NET Core is a practical beginner’s guide to creating your first web APIs using ASP.NET Core. In it, you’ll develop an API that feeds web-based services, including websites and mobile apps, for a board games application. The book is cleverly structured to mirror a real-world development project, with each chapter introducing a new feature request. You’ll build your API with an ecosystem of ASP.NET Core tools that help simplify everything from setting up your data model to generating documentation",
                            ISBN = "9781633439481",
                            ListPrice = 47.50m,
                            PublicationDate = new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Building Web APIs with ASP.NET Core"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Jon Skeet",
                            AvailableQuantity = 100,
                            CategoryId = 2,
                            Description = "Building Web APIs with ASP.NET Core is a practical beginner’s guide to creating your first web APIs using ASP.NET Core. In it, you’ll develop an API that feeds web-based services, including websites and mobile apps, for a board games application. The book is cleverly structured to mirror a real-world development project, with each chapter introducing a new feature request. You’ll build your API with an ecosystem of ASP.NET Core tools that help simplify everything from setting up your data model to generating documentation",
                            ISBN = "9781617294532",
                            ListPrice = 38.99m,
                            PublicationDate = new DateTime(2023, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "C# in Depth"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Andrew Lock",
                            AvailableQuantity = 100,
                            CategoryId = 2,
                            CoverImageUrl = "https://d374oxlv7wyffd.cloudfront.net/B0977Z1DHC/f2ea5a9a/cover.jpeg",
                            Description = "ASP.NET Core in Action, Second Edition is a comprehensive guide to creating web applications with ASP.NET Core 5.0. Go from basic HTTP concepts to advanced framework customization. Illustrations and annotated code make learning visual and easy. Master logins, dependency injection, security, and more. This updated edition covers the latest features, including Razor Pages and the new hosting paradigm",
                            ISBN = "9781617298301",
                            ListPrice = 60.49m,
                            PublicationDate = new DateTime(2023, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "ASP.NET Core in Action, Second Edition"
                        },
                        new
                        {
                            Id = 4,
                            Author = "Evan Thomas",
                            AvailableQuantity = 100,
                            CategoryId = 3,
                            CoverImageUrl = "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg",
                            Description = "A riveting, immersive account of the agonizing decision to use nuclear weapons against Japan—a crucial turning point in World War II and geopolitical history—with you-are-there immediacy by the New York Times bestselling author of Ike's Bluff and Sea of Thunder.\r\n\r\n“A terrifying, heartbreaking account of three men under unimaginable pressure . . . I challenge you not to read this book in a single sitting.”—Nathaniel Philbrick, author of In the Heart of the Sea and Travels with George\r\n\r\nAt 9:20 a.m. on the morning of May 30, General Groves receives a message to report to the office of the secretary of war “at once.” Stimson is waiting for him. He wants to know: has Groves selected the targets yet?\r\n\r\nSo begins this suspenseful, impeccably researched history that draws on new access to diaries to tell the story of three men who were intimately involved with America’s decision to drop the atomic bomb—and Japan’s decision to surrender. They are Henry Stimson, the American Secretary of War, who had overall responsibility for decisions about the atom bomb; Gen. Carl “Tooey” Spaatz, head of strategic bombing in the Pacific, who supervised the planes that dropped the bombs; and Japanese Foreign Minister Shigenori Togo, the only one in Emperor Hirohito’s Supreme War Council who believed even before the bombs were dropped that Japan should surrender.\r\n\r\nHenry Stimson had served in the administrations of five presidents, but as the U.S. nuclear program progressed, he found himself tasked with the unimaginable decision of determining whether to deploy the bomb. The new president, Harry S. Truman, thus far a peripheral figure in the momentous decision, accepted Stimson’s recommendation to drop the bomb. Army Air Force Commander Gen. Spaatz ordered the planes to take off. Like Stimson, Spaatz agonized over the command even as he recognized it would end the war. After the bombs were dropped, Foreign Minister Togo was finally able to convince the emperor to surrender.\r\n\r\nTo bring these critical events to vivid life, bestselling author Evan Thomas draws on the diaries of Stimson, Togo and Spaatz, contemplating the immense weight of their historic decision. In Road to Surrender, an immersive, surprising, moving account, Thomas lays out the behind-the-scenes thoughts, feelings, motivations, and decision-making of three people who changed history",
                            ISBN = "9780399589256",
                            ListPrice = 20m,
                            PublicationDate = new DateTime(2023, 6, 16, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Road to Surrender: Three Men and the Countdown to the End of World War II"
                        },
                        new
                        {
                            Id = 5,
                            Author = "Nick Trenton",
                            AvailableQuantity = 100,
                            CategoryId = 1,
                            CoverImageUrl = "https://m.media-amazon.com/images/I/41LqtW3+6iL._SX327_BO1,204,203,200_.jpg",
                            Description = "Overcome negative thought patterns, reduce stress, and live a worry-free life.\r\nOverthinking is the biggest cause of unhappiness. Don't get stuck in a never-ending thought loop. Stay present and keep your mind off things that don't matter, and never will.\r\nBreak free of your self-imposed mental prison.\r\nStop Overthinking is a book that understands where you’ve been through,the exhausting situation you’ve put yourself into, and how you lose your mind in the trap of anxiety and stress. Acclaimed author Nick Trenton will walk you through the obstacles with detailed and proven techniques to help you rewire your brain, control your thoughts, and change your mental habits.What’s more, the book will provide you scientific approaches to completely change the way you think and feel about yourself by ending the vicious thought patterns.\r\nStop agonizing over the past and trying to predict the future.\r\nNick Trenton grew up in rural Illinois and is quite literally a farm boy. His best friend growing up was his trusty companion Leonard the dachshund. RIP Leonard. Eventually, he made it off the farm and obtained a BS in Economics, followed by an MA in Behavioral Psychology.\r\nPowerful ways to stop ruminating and dwelling on negative thoughts.\r\n-How to be aware of your negative spiral triggers-Identify and recognize your inner anxieties-How to keep the focus on relaxation and action-Proven methods to overcome stress attacks-Learn to declutter your mind and find focus\r\nUnleash your unlimited potential and start living.\r\nNo more self-deprecating talk. No more sleepless nights with racing thoughts. Free your mind from overthinking and achieve more, feel better, and unleash your potential. Finally be able to live in the present moment.\r\nLive a stress-free life and conquer overthinking",
                            ISBN = "9798715048394",
                            ListPrice = 10.64m,
                            PublicationDate = new DateTime(2021, 3, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Title = "Road to Surrender: Three Men and the Countdown to the End of World War II"
                        });
                });

            modelBuilder.Entity("BookShopWeb.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            DisplayOrder = 1,
                            Name = "Business"
                        },
                        new
                        {
                            Id = 2,
                            DisplayOrder = 2,
                            Name = "Technologies"
                        },
                        new
                        {
                            Id = 3,
                            DisplayOrder = 3,
                            Name = "History"
                        });
                });

            modelBuilder.Entity("BookShopWeb.Models.Company", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Companies");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "WA 98052",
                            City = "Redmond",
                            Country = "USA",
                            Name = "Microsoft"
                        },
                        new
                        {
                            Id = 2,
                            Address = "1600 Amphitheatre Parkway",
                            City = "Mountain View",
                            Country = "USA",
                            Name = "Google"
                        },
                        new
                        {
                            Id = 3,
                            Address = "1 New Orchard Rd",
                            City = "Armonk",
                            Country = "USA",
                            Name = "IBM"
                        },
                        new
                        {
                            Id = 4,
                            Address = "2300 Cloud Way",
                            City = "Austin",
                            Country = "USA",
                            Name = "Oracle"
                        });
                });

            modelBuilder.Entity("BookShopWeb.Models.ShoppingCart", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ApplicationUserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BookId");

                    b.ToTable("ShoppingCart");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("BookShopWeb.Models.ApplicationUser", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PostalCode")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("ApplicationUser");
                });

            modelBuilder.Entity("BookShopWeb.Models.Book", b =>
                {
                    b.HasOne("BookShopWeb.Models.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("BookShopWeb.Models.ShoppingCart", b =>
                {
                    b.HasOne("BookShopWeb.Models.ApplicationUser", "ApplicationUser")
                        .WithMany()
                        .HasForeignKey("ApplicationUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookShopWeb.Models.Book", "Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ApplicationUser");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
