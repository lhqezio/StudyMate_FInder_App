﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Oracle.EntityFrameworkCore.Metadata;
using StudyMate;

#nullable disable

namespace src.Migrations
{
    [DbContext(typeof(StudyMateDbContext))]
    [Migration("20230429072756_InitialCreate13")]
    partial class InitialCreate13
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProfileEvent", b =>
                {
                    b.Property<string>("EventId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ProfileId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("EventId", "ProfileId");

                    b.HasIndex("ProfileId");

                    b.ToTable("ProfileEvent");
                });

            modelBuilder.Entity("StudyMate.Conversation", b =>
                {
                    b.Property<string>("ConversationId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("ConversationName")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("ConversationId");

                    b.ToTable("Conversations");
                });

            modelBuilder.Entity("StudyMate.Event", b =>
                {
                    b.Property<string>("EventId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Courses")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("CreatorId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("TIMESTAMP(7)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("StudyMate.Message", b =>
                {
                    b.Property<string>("MessageID")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ConversationID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("SenderID")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<bool>("Sent")
                        .HasColumnType("NUMBER(1)");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TIMESTAMP(7)");

                    b.HasKey("MessageID");

                    b.ToTable("Messages");
                });

            modelBuilder.Entity("StudyMate.Profile", b =>
                {
                    b.Property<string>("ProfileId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<int>("Age")
                        .HasColumnType("NUMBER(10)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Hobbies")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("NeedHelpCourses")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("PersonalDescription")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("ProfilePicture")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Program")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("School")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("TakenCourses")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId1")
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("ProfileId");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.HasIndex("UserId1")
                        .IsUnique()
                        .HasFilter("\"UserId1\" IS NOT NULL");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("StudyMate.User", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(2000)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("UserId");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("Username")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("UserConversation", b =>
                {
                    b.Property<string>("ConversationId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.Property<string>("UserId")
                        .HasColumnType("NVARCHAR2(450)");

                    b.HasKey("ConversationId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserConversation");
                });

            modelBuilder.Entity("ProfileEvent", b =>
                {
                    b.HasOne("StudyMate.Event", null)
                        .WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyMate.Profile", null)
                        .WithMany()
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyMate.Profile", b =>
                {
                    b.HasOne("StudyMate.User", null)
                        .WithOne()
                        .HasForeignKey("StudyMate.Profile", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyMate.User", null)
                        .WithOne("Profile")
                        .HasForeignKey("StudyMate.Profile", "UserId1");
                });

            modelBuilder.Entity("UserConversation", b =>
                {
                    b.HasOne("StudyMate.Conversation", null)
                        .WithMany()
                        .HasForeignKey("ConversationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("StudyMate.User", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("StudyMate.User", b =>
                {
                    b.Navigation("Profile");
                });
#pragma warning restore 612, 618
        }
    }
}
