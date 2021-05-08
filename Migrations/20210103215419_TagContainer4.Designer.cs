﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VitalWeb.DAL;

namespace VitalWeb.Migrations
{
    [DbContext(typeof(VitalDBContext))]
    [Migration("20210103215419_TagContainer4")]
    partial class TagContainer4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("VitalWeb.Models.Post", b =>
                {
                    b.Property<int>("PostID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("PostDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("TagID")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("TEXT");

                    b.HasKey("PostID");

                    b.HasIndex("TagID");

                    b.ToTable("Posts");
                });

            modelBuilder.Entity("VitalWeb.Models.Tag", b =>
                {
                    b.Property<int>("TagID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("TEXT");

                    b.Property<int?>("TagContainerID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagID");

                    b.HasIndex("TagContainerID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("VitalWeb.Models.TagContainer", b =>
                {
                    b.Property<int>("TagContainerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("TagID")
                        .HasColumnType("INTEGER");

                    b.HasKey("TagContainerID");

                    b.ToTable("TagsContainer");
                });

            modelBuilder.Entity("VitalWeb.Models.Post", b =>
                {
                    b.HasOne("VitalWeb.Models.Tag", "PostTag")
                        .WithMany()
                        .HasForeignKey("TagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PostTag");
                });

            modelBuilder.Entity("VitalWeb.Models.Tag", b =>
                {
                    b.HasOne("VitalWeb.Models.TagContainer", null)
                        .WithMany("AllTags")
                        .HasForeignKey("TagContainerID");
                });

            modelBuilder.Entity("VitalWeb.Models.TagContainer", b =>
                {
                    b.Navigation("AllTags");
                });
#pragma warning restore 612, 618
        }
    }
}
