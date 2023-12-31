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
    [Migration("20211124175733_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyGolfHandicapAPI.Models.GolfCourse", b =>
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

            modelBuilder.Entity("MyGolfHandicapAPI.Models.HoleInfo", b =>
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

            modelBuilder.Entity("MyGolfHandicapAPI.Models.HoleScore", b =>
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

            modelBuilder.Entity("MyGolfHandicapAPI.Models.ScoreCard", b =>
                {
                    b.Property<int>("ScoreCardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CourseName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoundType")
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

            modelBuilder.Entity("MyGolfHandicapAPI.Models.ScoreDifferential", b =>
                {
                    b.Property<int>("ScoreDifferentialId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("CourseRating")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("GrossAdjustedScore")
                        .HasColumnType("int");

                    b.Property<int>("RoundType")
                        .HasColumnType("int");

                    b.Property<int>("SlopeRating")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("ScoreDifferentialId");

                    b.HasIndex("UserId");

                    b.ToTable("ScoreDifferentials");
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.Tee", b =>
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

            modelBuilder.Entity("MyGolfHandicapAPI.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.HoleInfo", b =>
                {
                    b.HasOne("MyGolfHandicapAPI.Models.Tee", null)
                        .WithMany("Holes")
                        .HasForeignKey("TeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.HoleScore", b =>
                {
                    b.HasOne("MyGolfHandicapAPI.Models.ScoreCard", null)
                        .WithMany("HoleScores")
                        .HasForeignKey("ScoreCardId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.ScoreCard", b =>
                {
                    b.HasOne("MyGolfHandicapAPI.Models.User", null)
                        .WithMany("ScoreCards")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.ScoreDifferential", b =>
                {
                    b.HasOne("MyGolfHandicapAPI.Models.User", null)
                        .WithMany("ScoreDifferentials")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.Tee", b =>
                {
                    b.HasOne("MyGolfHandicapAPI.Models.GolfCourse", null)
                        .WithMany("Tees")
                        .HasForeignKey("GolfCourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.GolfCourse", b =>
                {
                    b.Navigation("Tees");
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.ScoreCard", b =>
                {
                    b.Navigation("HoleScores");
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.Tee", b =>
                {
                    b.Navigation("Holes");
                });

            modelBuilder.Entity("MyGolfHandicapAPI.Models.User", b =>
                {
                    b.Navigation("ScoreCards");

                    b.Navigation("ScoreDifferentials");
                });
#pragma warning restore 612, 618
        }
    }
}
