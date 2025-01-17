﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using NetChallange.Infrastructure.Data;

#nullable disable

namespace NetChallange.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20250114182600_NetChallangeDBDesign")]
    partial class NetChallangeDBDesign
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.36")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("NetChallange.Core.Entities.CarrierConfigurations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<decimal>("CarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMaxDesi")
                        .HasColumnType("int");

                    b.Property<int>("CarrierMinDesi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarrierConfigurations");
                });

            modelBuilder.Entity("NetChallange.Core.Entities.Carriers", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarrierConfigurationId")
                        .HasColumnType("int");

                    b.Property<bool>("CarrierIsActive")
                        .HasColumnType("bit");

                    b.Property<string>("CarrierName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CarrierPlusDesiCost")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierConfigurationId")
                        .IsUnique();

                    b.ToTable("Carriers");
                });

            modelBuilder.Entity("NetChallange.Core.Entities.Orders", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CarrierId")
                        .HasColumnType("int");

                    b.Property<decimal>("OrderCarrierCost")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("OrderDesi")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CarrierId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("NetChallange.Core.Entities.Carriers", b =>
                {
                    b.HasOne("NetChallange.Core.Entities.CarrierConfigurations", "CarrierConfigurations")
                        .WithOne("Carrier")
                        .HasForeignKey("NetChallange.Core.Entities.Carriers", "CarrierConfigurationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CarrierConfigurations");
                });

            modelBuilder.Entity("NetChallange.Core.Entities.Orders", b =>
                {
                    b.HasOne("NetChallange.Core.Entities.Carriers", "Carriers")
                        .WithMany("Orders")
                        .HasForeignKey("CarrierId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Carriers");
                });

            modelBuilder.Entity("NetChallange.Core.Entities.CarrierConfigurations", b =>
                {
                    b.Navigation("Carrier")
                        .IsRequired();
                });

            modelBuilder.Entity("NetChallange.Core.Entities.Carriers", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
