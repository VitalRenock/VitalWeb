﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VitalWeb.DAL;

namespace VitalWeb.Migrations
{
    [DbContext(typeof(VitalDBContext))]
    partial class VitalDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("MyTagContainerTag", b =>
                {
                    b.Property<int>("AllTagsContainerMyTagContainerID")
                        .HasColumnType("INTEGER");

                    b.Property<int>("AllTagsTagID")
                        .HasColumnType("INTEGER");

                    b.HasKey("AllTagsContainerMyTagContainerID", "AllTagsTagID");

                    b.HasIndex("AllTagsTagID");

                    b.ToTable("MyTagContainerTag");
                });

            modelBuilder.Entity("VitalWeb.Models.MyTagContainer", b =>
                {
                    b.Property<int>("MyTagContainerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(55)
                        .HasColumnType("TEXT");

                    b.HasKey("MyTagContainerID");

                    b.ToTable("MyTagContainers");
                });

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

                    b.HasKey("TagID");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("MyTagContainerTag", b =>
                {
                    b.HasOne("VitalWeb.Models.MyTagContainer", null)
                        .WithMany()
                        .HasForeignKey("AllTagsContainerMyTagContainerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("VitalWeb.Models.Tag", null)
                        .WithMany()
                        .HasForeignKey("AllTagsTagID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
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
#pragma warning restore 612, 618
        }
    }
}
