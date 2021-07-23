﻿// <auto-generated />
using System;
using ITVitaeSVS.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ITVitaeSVS.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataDbContext))]
    [Migration("20210723113046_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.8")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Certificate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ExamId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Certificates");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Curriculum", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Curriculum");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.CurriculumTopic", b =>
                {
                    b.Property<int>("CurriculumId")
                        .HasColumnType("int");

                    b.Property<int>("TopicId")
                        .HasColumnType("int");

                    b.Property<bool>("Approved")
                        .HasColumnType("bit");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Progress")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("CurriculumId", "TopicId");

                    b.HasIndex("TopicId");

                    b.ToTable("CurriculumTopic");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Level", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Levels");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Link", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.Property<string>("URL")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Requisite", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Requisites");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Student", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EnrolledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TopicId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Topic", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CertificateId")
                        .HasColumnType("int");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("Duration")
                        .HasColumnType("time");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<int?>("LevelId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Objective")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TopicId")
                        .HasColumnType("int");

                    b.Property<int?>("WorkMethodId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CertificateId");

                    b.HasIndex("LevelId");

                    b.HasIndex("TopicId");

                    b.HasIndex("WorkMethodId");

                    b.ToTable("Topic");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.WorkMethod", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("WorkMethods");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Curriculum", b =>
                {
                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Student", "Student")
                        .WithOne("Curriculum")
                        .HasForeignKey("ITVitaeSVS.Core.Domain.Entities.Curriculum", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Student");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.CurriculumTopic", b =>
                {
                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Curriculum", "Curriculum")
                        .WithMany("Topics")
                        .HasForeignKey("CurriculumId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Topic", "Topic")
                        .WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curriculum");

                    b.Navigation("Topic");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Link", b =>
                {
                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Topic", null)
                        .WithMany("Links")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Requisite", b =>
                {
                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Topic", null)
                        .WithMany("Requisites")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Tag", b =>
                {
                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Topic", null)
                        .WithMany("Tags")
                        .HasForeignKey("TopicId");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Topic", b =>
                {
                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Certificate", "Certificate")
                        .WithMany()
                        .HasForeignKey("CertificateId");

                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Level", "Level")
                        .WithMany()
                        .HasForeignKey("LevelId");

                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.Topic", null)
                        .WithMany("Prerequisites")
                        .HasForeignKey("TopicId");

                    b.HasOne("ITVitaeSVS.Core.Domain.Entities.WorkMethod", "WorkMethod")
                        .WithMany()
                        .HasForeignKey("WorkMethodId");

                    b.Navigation("Certificate");

                    b.Navigation("Level");

                    b.Navigation("WorkMethod");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Curriculum", b =>
                {
                    b.Navigation("Topics");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Student", b =>
                {
                    b.Navigation("Curriculum");
                });

            modelBuilder.Entity("ITVitaeSVS.Core.Domain.Entities.Topic", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("Prerequisites");

                    b.Navigation("Requisites");

                    b.Navigation("Tags");
                });
#pragma warning restore 612, 618
        }
    }
}
