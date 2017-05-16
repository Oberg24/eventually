using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Eventually.Api.Models;

namespace Eventually.Api.Migrations
{
    [DbContext(typeof(EventuallyContext))]
    [Migration("20170516142305_eventtag")]
    partial class eventtag
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.2")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Eventually.Api.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreationDate");

                    b.Property<int?>("CreatorId");

                    b.Property<string>("Description");

                    b.Property<DateTime>("EndTime");

                    b.Property<DateTime>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Eventually.Api.Models.EventParticipant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("EventParticipants");
                });

            modelBuilder.Entity("Eventually.Api.Models.EventTag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<int?>("TagId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("TagId");

                    b.ToTable("EventTag");
                });

            modelBuilder.Entity("Eventually.Api.Models.Rating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<int>("Stars");

                    b.Property<int?>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.HasIndex("UserId");

                    b.ToTable("Ratings");
                });

            modelBuilder.Entity("Eventually.Api.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Eventually.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Eventually.Api.Models.Event", b =>
                {
                    b.HasOne("Eventually.Api.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
                });

            modelBuilder.Entity("Eventually.Api.Models.EventParticipant", b =>
                {
                    b.HasOne("Eventually.Api.Models.Event", "Event")
                        .WithMany("EventParticipants")
                        .HasForeignKey("EventId");

                    b.HasOne("Eventually.Api.Models.User", "User")
                        .WithMany("ParticipatedEvents")
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Eventually.Api.Models.EventTag", b =>
                {
                    b.HasOne("Eventually.Api.Models.Event", "Event")
                        .WithMany("EventTags")
                        .HasForeignKey("EventId");

                    b.HasOne("Eventually.Api.Models.Tag", "Tag")
                        .WithMany("TagEvents")
                        .HasForeignKey("TagId");
                });

            modelBuilder.Entity("Eventually.Api.Models.Rating", b =>
                {
                    b.HasOne("Eventually.Api.Models.Event", "Event")
                        .WithMany()
                        .HasForeignKey("EventId");

                    b.HasOne("Eventually.Api.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });
        }
    }
}
