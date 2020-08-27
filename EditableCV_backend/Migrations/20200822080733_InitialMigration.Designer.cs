﻿// <auto-generated />
using System;
using EditableCV_backend.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace EditableCV_backend.Migrations
{
    [DbContext(typeof(ResumeContext))]
    [Migration("20200822080733_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EditableCV_backend.Models.WorkPlace", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("CompanyIcon")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("EndWorkingDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Experience")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(250)")
                        .HasMaxLength(250);

                    b.Property<DateTime>("StartWorkingDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("WorkPlaces");
                });
#pragma warning restore 612, 618
        }
    }
}
