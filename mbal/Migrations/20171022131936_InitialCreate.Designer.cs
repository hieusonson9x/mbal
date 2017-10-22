﻿// <auto-generated />
using mbal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace mbal.Migrations
{
    [DbContext(typeof(UserContext))]
    [Migration("20171022131936_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("mbal.Models.Agency", b =>
                {
                    b.Property<long>("AgencyID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("ConsultantName");

                    b.Property<string>("Name");

                    b.Property<string>("Phonenumber");

                    b.HasKey("AgencyID");

                    b.ToTable("agencies");
                });

            modelBuilder.Entity("mbal.Models.Customer", b =>
                {
                    b.Property<long>("CustomerID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Cmtnd");

                    b.Property<DateTime>("Dob");

                    b.Property<string>("FullName");

                    b.Property<string>("Phonenumber");

                    b.Property<string>("Sex");

                    b.HasKey("CustomerID");

                    b.ToTable("customers");
                });

            modelBuilder.Entity("mbal.Models.Insurrance", b =>
                {
                    b.Property<long>("InsurranceID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BanhchCode");

                    b.Property<string>("ContractNumber");

                    b.Property<string>("CoverageRate");

                    b.Property<DateTime>("Create_at");

                    b.Property<string>("Create_by");

                    b.Property<long?>("CustomerID");

                    b.Property<int>("DurationOfInsurrance");

                    b.Property<int>("FormOfPayment");

                    b.Property<long?>("ProductId");

                    b.Property<string>("StatusContract");

                    b.Property<string>("StatusFee");

                    b.HasKey("InsurranceID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("ProductId");

                    b.ToTable("insurrances");
                });

            modelBuilder.Entity("mbal.Models.Product", b =>
                {
                    b.Property<long>("ProductId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Money");

                    b.Property<int>("PayMethod");

                    b.Property<string>("ProductCode");

                    b.Property<string>("ProductName");

                    b.Property<string>("ProductStatus");

                    b.HasKey("ProductId");

                    b.ToTable("products");
                });

            modelBuilder.Entity("mbal.Models.User", b =>
                {
                    b.Property<long>("id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("fullname");

                    b.Property<string>("password");

                    b.Property<string>("username");

                    b.HasKey("id");

                    b.ToTable("users");
                });

            modelBuilder.Entity("mbal.Models.Insurrance", b =>
                {
                    b.HasOne("mbal.Models.Customer", "Customer")
                        .WithMany("Insurrances")
                        .HasForeignKey("CustomerID");

                    b.HasOne("mbal.Models.Product", "Product")
                        .WithMany("Insurrances")
                        .HasForeignKey("ProductId");
                });
#pragma warning restore 612, 618
        }
    }
}
