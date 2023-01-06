﻿// <auto-generated />
using System;
using InterventionsApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterventionsApi.Migrations
{
    [DbContext(typeof(InterventionsApiContext))]
    [Migration("20230106170423_init25")]
    partial class init25
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("InterventionsApi.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("InterventionsApi.Models.Client", b =>
                {
                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ClientId");

                    b.ToTable("Client");
                });

            modelBuilder.Entity("InterventionsApi.Models.Intervention", b =>
                {
                    b.Property<int>("InterventionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("InterventionId"), 1L, 1);

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Gratuit")
                        .HasColumnType("bit");

                    b.Property<int?>("ReclamationId")
                        .HasColumnType("int");

                    b.HasKey("InterventionId");

                    b.HasIndex("ArticleId");

                    b.HasIndex("ReclamationId");

                    b.ToTable("Intervention");
                });

            modelBuilder.Entity("InterventionsApi.Models.Reclamation", b =>
                {
                    b.Property<int>("ReclamationId")
                        .HasColumnType("int");

                    b.Property<int?>("ClientId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ReclamationId");

                    b.HasIndex("ClientId");

                    b.ToTable("Reclamation");
                });

            modelBuilder.Entity("InterventionsApi.Models.Intervention", b =>
                {
                    b.HasOne("InterventionsApi.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("InterventionsApi.Models.Reclamation", "Reclamation")
                        .WithMany()
                        .HasForeignKey("ReclamationId");

                    b.Navigation("Article");

                    b.Navigation("Reclamation");
                });

            modelBuilder.Entity("InterventionsApi.Models.Reclamation", b =>
                {
                    b.HasOne("InterventionsApi.Models.Client", "Client")
                        .WithMany()
                        .HasForeignKey("ClientId");

                    b.Navigation("Client");
                });
#pragma warning restore 612, 618
        }
    }
}
