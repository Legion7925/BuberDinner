﻿// <auto-generated />
using System;
using BubberDinner.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BubberDinner.Infrastructure.Migrations
{
    [DbContext(typeof(BubberDinnerDbContext))]
    [Migration("20230731091708_host-conf")]
#pragma warning disable CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    partial class hostconf
#pragma warning restore CS8981 // The type name only contains lower-cased ascii characters. Such names may become reserved for the language.
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BubberDinner.Domain.Host.Host", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfileImage")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Hosts", (string)null);
                });

            modelBuilder.Entity("BubberDinner.Domain.Menu.Menu", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Menus", (string)null);
                });

            modelBuilder.Entity("BubberDinner.Domain.Host.Host", b =>
                {
                    b.OwnsOne("BubberDinner.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<float>("Value")
                                .HasColumnType("real");

                            b1.HasKey("HostId");

                            b1.ToTable("Hosts");

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("BubberDinner.Domain.Dinner.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("Hosts_DinnerIds");

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.OwnsMany("BubberDinner.Domain.Menu.ValueObjects.MenuId", "MenuIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<Guid>("HostId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("HostMenuId");

                            b1.HasKey("Id");

                            b1.HasIndex("HostId");

                            b1.ToTable("MenuId");

                            b1.WithOwner()
                                .HasForeignKey("HostId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuIds");
                });

            modelBuilder.Entity("BubberDinner.Domain.Menu.Menu", b =>
                {
                    b.OwnsMany("BubberDinner.Domain.Menu.Entities.MenuSection", "MenuSections", b1 =>
                        {
                            b1.Property<Guid>("Id")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuSectionId");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<string>("Description")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.Property<string>("Name")
                                .IsRequired()
                                .HasMaxLength(100)
                                .HasColumnType("nvarchar(100)");

                            b1.HasKey("Id", "MenuId");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuSections", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");

                            b1.OwnsMany("BubberDinner.Domain.Menu.Entities.MenuItem", "Items", b2 =>
                                {
                                    b2.Property<Guid>("Id")
                                        .HasColumnType("uniqueidentifier")
                                        .HasColumnName("MenuItemId");

                                    b2.Property<Guid>("MenuSectionId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<Guid>("MenuId")
                                        .HasColumnType("uniqueidentifier");

                                    b2.Property<string>("Description")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.Property<string>("Name")
                                        .IsRequired()
                                        .HasMaxLength(100)
                                        .HasColumnType("nvarchar(100)");

                                    b2.HasKey("Id", "MenuSectionId", "MenuId");

                                    b2.HasIndex("MenuSectionId", "MenuId");

                                    b2.ToTable("MenuItems", (string)null);

                                    b2.WithOwner()
                                        .HasForeignKey("MenuSectionId", "MenuId");
                                });

                            b1.Navigation("Items");
                        });

                    b.OwnsOne("BubberDinner.Domain.Common.ValueObjects.AverageRating", "AverageRating", b1 =>
                        {
                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<int>("NumRatings")
                                .HasColumnType("int");

                            b1.Property<float>("Value")
                                .HasColumnType("real");

                            b1.HasKey("MenuId");

                            b1.ToTable("Menus");

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BubberDinner.Domain.Dinner.ValueObjects.DinnerId", "DinnerIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("DinnerId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuDinnerIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.OwnsMany("BubberDinner.Domain.MenuReview.ValueObjects.MenuReviewId", "MenuReviewIds", b1 =>
                        {
                            b1.Property<int>("Id")
                                .HasColumnType("int");

                            b1.Property<Guid>("MenuId")
                                .HasColumnType("uniqueidentifier");

                            b1.Property<Guid>("Value")
                                .HasColumnType("uniqueidentifier")
                                .HasColumnName("MenuReviewId");

                            b1.HasKey("Id");

                            b1.HasIndex("MenuId");

                            b1.ToTable("MenuReviewIds", (string)null);

                            b1.WithOwner()
                                .HasForeignKey("MenuId");
                        });

                    b.Navigation("AverageRating")
                        .IsRequired();

                    b.Navigation("DinnerIds");

                    b.Navigation("MenuReviewIds");

                    b.Navigation("MenuSections");
                });
#pragma warning restore 612, 618
        }
    }
}
