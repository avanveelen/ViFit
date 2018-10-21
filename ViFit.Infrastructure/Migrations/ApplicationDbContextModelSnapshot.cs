﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ViFit.Infrastructure.EF;

namespace ViFit.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("ViFit.Infrastructure.EF.EventLog", b =>
                {
                    b.Property<Guid>("AggregateId");

                    b.Property<int>("Version");

                    b.Property<string>("AggregateType");

                    b.Property<DateTime>("Created");

                    b.Property<string>("Data");

                    b.Property<string>("EventType");

                    b.HasKey("AggregateId", "Version");

                    b.ToTable("EventLogs");
                });
#pragma warning restore 612, 618
        }
    }
}
