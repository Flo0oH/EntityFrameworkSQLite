﻿// <auto-generated />
using EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace entiframe.Migrations
{
    [DbContext(typeof(PersonContext))]
    [Migration("20221026181448_InitialCreate13")]
    partial class InitialCreate13
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.30");

            modelBuilder.Entity("EF.FluentApiTable", b =>
                {
                    b.Property<int>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("MyName")
                        .HasColumnType("TEXT");

                    b.HasKey("Identifier");

                    b.ToTable("FluentApiTable");
                });

            modelBuilder.Entity("EF.Logins", b =>
                {
                    b.Property<int>("Identifier")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("date");

                    b.Property<string>("LoginName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.HasKey("Identifier");

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("EF.Sensors", b =>
                {
                    b.Property<int>("SensorsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasMaxLength(30);

                    b.Property<string>("Room")
                        .HasColumnType("TEXT");

                    b.Property<int>("RoomNr")
                        .HasColumnType("INTEGER");

                    b.HasKey("SensorsId");

                    b.ToTable("Sensors");
                });

            modelBuilder.Entity("EF.TempSensor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("Sensornr")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SensorsId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<float>("Temperature")
                        .HasColumnType("REAL");

                    b.Property<string>("Temperaturedate")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("TempSensors");
                });
#pragma warning restore 612, 618
        }
    }
}
