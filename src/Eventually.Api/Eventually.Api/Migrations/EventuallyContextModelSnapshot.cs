using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Eventually.Api.Models;

namespace Eventually.Api.Migrations
{
    [DbContext(typeof(EventuallyContext))]
    partial class EventuallyContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
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

                    b.Property<int?>("EventId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Eventually.Api.Models.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("EventId");

                    b.Property<string>("Password");

                    b.Property<string>("Username");

                    b.HasKey("Id");

                    b.HasIndex("EventId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Eventually.Api.Models.Event", b =>
                {
                    b.HasOne("Eventually.Api.Models.User", "Creator")
                        .WithMany()
                        .HasForeignKey("CreatorId");
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

            modelBuilder.Entity("Eventually.Api.Models.Tag", b =>
                {
                    b.HasOne("Eventually.Api.Models.Event")
                        .WithMany("Tags")
                        .HasForeignKey("EventId");
                });

            modelBuilder.Entity("Eventually.Api.Models.User", b =>
                {
                    b.HasOne("Eventually.Api.Models.Event")
                        .WithMany("Participants")
                        .HasForeignKey("EventId");
                });
        }
    }
}
