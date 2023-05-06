﻿// <auto-generated />
using System;
using ComitivaEsperanca.API.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace ComitivaEsperanca.API.Data.Migrations
{
    [DbContext(typeof(CoreContext))]
    [Migration("20230506024126_CreateTableClassifiedNews")]
    partial class CreateTableClassifiedNews
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ComitivaEsperanca.API.Domain.Entities.ClassifiedNews", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("NewsId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("ClassifiedNews");
                });

            modelBuilder.Entity("ComitivaEsperanca.API.Domain.Entities.News", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CommodityType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("FinalSentiment")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("NegativeSentiment")
                        .HasColumnType("double precision");

                    b.Property<double>("NeutralSentiment")
                        .HasColumnType("double precision");

                    b.Property<string>("NewsContent")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("PositiveSentiment")
                        .HasColumnType("double precision");

                    b.Property<DateTime>("PublicationDate")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Source")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("News");
                });

            modelBuilder.Entity("ComitivaEsperanca.API.Domain.Entities.ClassifiedNews", b =>
                {
                    b.HasOne("ComitivaEsperanca.API.Domain.Entities.News", "News")
                        .WithMany()
                        .HasForeignKey("NewsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("News");
                });
#pragma warning restore 612, 618
        }
    }
}
