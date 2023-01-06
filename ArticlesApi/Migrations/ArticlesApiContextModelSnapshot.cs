﻿// <auto-generated />
using System;
using ArticlesApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ArticlesApi.Migrations
{
    [DbContext(typeof(ArticlesApiContext))]
    partial class ArticlesApiContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ArticlesApi.Models.Article", b =>
                {
                    b.Property<int>("ArticleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ArticleId"), 1L, 1);

                    b.Property<bool>("Garantie")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ArticleId");

                    b.ToTable("Article");
                });

            modelBuilder.Entity("ArticlesApi.Models.Piece", b =>
                {
                    b.Property<int>("PieceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PieceId"), 1L, 1);

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Prix")
                        .HasColumnType("float");

                    b.HasKey("PieceId");

                    b.HasIndex("ArticleId");

                    b.ToTable("Piece");
                });

            modelBuilder.Entity("ArticlesApi.Models.Piece", b =>
                {
                    b.HasOne("ArticlesApi.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.Navigation("Article");
                });
#pragma warning restore 612, 618
        }
    }
}
