﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyGolfHandicapAPI.Data;

namespace MyGolfHandicapAPI.Migrations
{
    [DbContext(typeof(MyGolfHandicapContext))]
    [Migration("20230626141917_update_user_table")]
    partial class update_user_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyGolfHandicapCore.Models.GolfCourse", b =>
                {
                    b.Property<int>("GolfCourseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GolfCourseId");

                    b.ToTable("GolfCourses");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.HoleInfo", b =>
                {
                    b.Property<int>("HoleInfoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HoleNumber")
                        .HasColumnType("int");

                    b.Property<int>("Par")
                        .HasColumnType("int");

                    b.Property<int>("StrokeIndex")
                        .HasColumnType("int");

                    b.Property<int>("TeeId")
                        .HasColumnType("int");

                    b.Property<int>("Yards")
                        .HasColumnType("int");

                    b.HasKey("HoleInfoId");

                    b.HasIndex("TeeId");

                    b.ToTable("Holes");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.HoleScore", b =>
                {
                    b.Property<int>("HoleScoreId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("HoleNumber")
                        .HasColumnType("int");

                    b.Property<int>("HolePar")
                        .HasColumnType("int");

                    b.Property<int>("Score")
                        .HasColumnType("int");

                    b.Property<int>("ScoreCardId")
                        .HasColumnType("int");

                    b.Property<int>("StrokeIndex")
                        .HasColumnType("int");

                    b.Property<int>("Yards")
                        .HasColumnType("int");

                    b.HasKey("HoleScoreId");

                    b.HasIndex("ScoreCardId");

                    b.ToTable("HoleScores");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.ScoreCard", b =>
                {
                    b.Property<int>("ScoreCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("CourseRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrossScore")
                        .HasColumnType("int");

                    b.Property<decimal>("HandicapIndex")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("Par")
                        .HasColumnType("int");

                    b.Property<int>("RoundType")
                        .HasColumnType("int");

                    b.Property<decimal>("ScoreDiff")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("SlopeRating")
                        .HasColumnType("int");

                    b.Property<string>("TeeColour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ScoreCardId");

                    b.HasIndex("UserId");

                    b.ToTable("ScoreCards");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.Tee", b =>
                {
                    b.Property<int>("TeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CourseRating18")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CourseRatingBack9")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("CourseRatingFront9")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("GolfCourseId")
                        .HasColumnType("int");

                    b.Property<int>("SlopeRating18")
                        .HasColumnType("int");

                    b.Property<int>("SlopeRatingBack9")
                        .HasColumnType("int");

                    b.Property<int>("SlopeRatingFront9")
                        .HasColumnType("int");

                    b.Property<string>("TeeColour")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("TeeId");

                    b.HasIndex("GolfCourseId");

                    b.ToTable("Tees");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.HoleInfo", b =>
                {
                    b.HasOne("MyGolfHandicapCore.Models.Tee", null)
                        .WithMany("Holes")
                        .HasForeignKey("TeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.HoleScore", b =>
                {
                    b.HasOne("MyGolfHandicapCore.Models.ScoreCard", null)
                        .WithMany("HoleScores")
                        .HasForeignKey("ScoreCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.ScoreCard", b =>
                {
                    b.HasOne("MyGolfHandicapCore.Models.User", null)
                        .WithMany("ScoreCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.Tee", b =>
                {
                    b.HasOne("MyGolfHandicapCore.Models.GolfCourse", null)
                        .WithMany("Tees")
                        .HasForeignKey("GolfCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.GolfCourse", b =>
                {
                    b.Navigation("Tees");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.ScoreCard", b =>
                {
                    b.Navigation("HoleScores");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.Tee", b =>
                {
                    b.Navigation("Holes");
                });

            modelBuilder.Entity("MyGolfHandicapCore.Models.User", b =>
                {
                    b.Navigation("ScoreCards");
                });
#pragma warning restore 612, 618
        }
    }
}