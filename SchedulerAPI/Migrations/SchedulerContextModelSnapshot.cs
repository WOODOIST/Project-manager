﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProjectManagerAPI.Models;

#nullable disable

namespace ProjectManagerAPI.Migrations
{
    [DbContext(typeof(SchedulerContext))]
    partial class SchedulerContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProjectManagerAPI.Models.Fact", b =>
                {
                    b.Property<int>("Factid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("factid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Factid"));

                    b.Property<string>("Factname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("factname");

                    b.HasKey("Factid")
                        .HasName("fact_pk");

                    b.ToTable("fact", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Laborcost", b =>
                {
                    b.Property<int>("Laborcostid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("laborcostid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Laborcostid"));

                    b.Property<string>("Laborcostname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("laborcostname");

                    b.HasKey("Laborcostid")
                        .HasName("laborcost_pk");

                    b.ToTable("laborcost", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Plannedlaborcost", b =>
                {
                    b.Property<int>("Plannedlaborcostid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("plannedlaborcostid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Plannedlaborcostid"));

                    b.Property<int?>("Factid")
                        .HasColumnType("integer")
                        .HasColumnName("factid");

                    b.Property<int?>("Laborcostid")
                        .HasColumnType("integer")
                        .HasColumnName("laborcostid");

                    b.Property<DateOnly?>("Plannedlaborcostfilldate")
                        .HasColumnType("date")
                        .HasColumnName("plannedlaborcostfilldate");

                    b.Property<decimal?>("Plannedlaborcostpercent")
                        .HasColumnType("numeric")
                        .HasColumnName("plannedlaborcostpercent");

                    b.Property<int?>("Projectid")
                        .HasColumnType("integer")
                        .HasColumnName("projectid");

                    b.Property<int?>("Scenarioid")
                        .HasColumnType("integer")
                        .HasColumnName("scenarioid");

                    b.Property<int?>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Plannedlaborcostid")
                        .HasName("plannedlaborcost_pk");

                    b.HasIndex("Factid");

                    b.HasIndex("Laborcostid");

                    b.HasIndex("Projectid");

                    b.HasIndex("Scenarioid");

                    b.HasIndex("Userid");

                    b.ToTable("plannedlaborcost", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Post", b =>
                {
                    b.Property<int>("Postid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("postid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Postid"));

                    b.Property<string>("Postname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("postname");

                    b.HasKey("Postid")
                        .HasName("post_pk");

                    b.ToTable("Post", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.PostDynamic", b =>
                {
                    b.Property<int>("Postdynamicid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("postdynamicid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Postdynamicid"));

                    b.Property<DateOnly>("Postdynamicstartdate")
                        .HasColumnType("date")
                        .HasColumnName("postdynamicstartdate");

                    b.Property<int>("Postid")
                        .HasColumnType("integer")
                        .HasColumnName("postid");

                    b.Property<int>("Userid")
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    b.HasKey("Postdynamicid")
                        .HasName("postdynamic_pk");

                    b.HasIndex("Postid");

                    b.HasIndex("Userid");

                    b.ToTable("PostDynamic", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Project", b =>
                {
                    b.Property<int>("Projectid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("projectid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Projectid"));

                    b.Property<DateOnly>("Projectcreationdate")
                        .HasColumnType("date")
                        .HasColumnName("projectcreationdate");

                    b.Property<DateOnly?>("Projectfinishdate")
                        .HasColumnType("date")
                        .HasColumnName("projectfinishdate");

                    b.Property<string>("Projectname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("projectname");

                    b.HasKey("Projectid")
                        .HasName("project_pk");

                    b.ToTable("project", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Role", b =>
                {
                    b.Property<int>("Roleid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("roleid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Roleid"));

                    b.Property<string>("Rolename")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("rolename");

                    b.HasKey("Roleid")
                        .HasName("role_pk");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Scenario", b =>
                {
                    b.Property<int>("Scenarioid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("scenarioid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Scenarioid"));

                    b.Property<string>("Scenarioname")
                        .IsRequired()
                        .HasColumnType("character varying")
                        .HasColumnName("scenarioname");

                    b.HasKey("Scenarioid")
                        .HasName("scenario_pk");

                    b.ToTable("scenario", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.User", b =>
                {
                    b.Property<int>("Userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasColumnName("userid");

                    NpgsqlPropertyBuilderExtensions.UseIdentityAlwaysColumn(b.Property<int>("Userid"));

                    b.Property<int?>("Roleid")
                        .HasColumnType("integer")
                        .HasColumnName("roleid");

                    b.Property<string>("Useremail")
                        .HasColumnType("character varying")
                        .HasColumnName("useremail");

                    b.Property<string>("Userlogin")
                        .HasColumnType("character varying")
                        .HasColumnName("userlogin");

                    b.Property<string>("Username")
                        .HasColumnType("character varying")
                        .HasColumnName("username");

                    b.Property<string>("Userpassword")
                        .HasColumnType("character varying")
                        .HasColumnName("userpassword");

                    b.Property<string>("Userpatronymic")
                        .HasColumnType("character varying")
                        .HasColumnName("userpatronymic");

                    b.Property<string>("Usersurname")
                        .HasColumnType("character varying")
                        .HasColumnName("usersurname");

                    b.HasKey("Userid")
                        .HasName("user_pk");

                    b.HasIndex("Roleid");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Plannedlaborcost", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Fact", "Fact")
                        .WithMany("Plannedlaborcosts")
                        .HasForeignKey("Factid")
                        .HasConstraintName("plannedlaborcost_fk_2");

                    b.HasOne("ProjectManagerAPI.Models.Laborcost", "Laborcost")
                        .WithMany("Plannedlaborcosts")
                        .HasForeignKey("Laborcostid")
                        .HasConstraintName("plannedlaborcost_fk_4");

                    b.HasOne("ProjectManagerAPI.Models.Project", "Project")
                        .WithMany("Plannedlaborcosts")
                        .HasForeignKey("Projectid")
                        .HasConstraintName("plannedlaborcost_fk_1");

                    b.HasOne("ProjectManagerAPI.Models.Scenario", "Scenario")
                        .WithMany("Plannedlaborcosts")
                        .HasForeignKey("Scenarioid")
                        .HasConstraintName("plannedlaborcost_fk_3");

                    b.HasOne("ProjectManagerAPI.Models.User", "User")
                        .WithMany("Plannedlaborcosts")
                        .HasForeignKey("Userid")
                        .HasConstraintName("plannedlaborcost_fk");

                    b.Navigation("Fact");

                    b.Navigation("Laborcost");

                    b.Navigation("Project");

                    b.Navigation("Scenario");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.PostDynamic", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Post", "Post")
                        .WithMany("PostDynamics")
                        .HasForeignKey("Postid")
                        .IsRequired()
                        .HasConstraintName("postdynamic_fk_1");

                    b.HasOne("ProjectManagerAPI.Models.User", "User")
                        .WithMany("PostDynamics")
                        .HasForeignKey("Userid")
                        .IsRequired()
                        .HasConstraintName("postdynamic_fk");

                    b.Navigation("Post");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.User", b =>
                {
                    b.HasOne("ProjectManagerAPI.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("Roleid")
                        .HasConstraintName("user_fk");

                    b.Navigation("Role");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Fact", b =>
                {
                    b.Navigation("Plannedlaborcosts");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Laborcost", b =>
                {
                    b.Navigation("Plannedlaborcosts");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Post", b =>
                {
                    b.Navigation("PostDynamics");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Project", b =>
                {
                    b.Navigation("Plannedlaborcosts");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.Scenario", b =>
                {
                    b.Navigation("Plannedlaborcosts");
                });

            modelBuilder.Entity("ProjectManagerAPI.Models.User", b =>
                {
                    b.Navigation("Plannedlaborcosts");

                    b.Navigation("PostDynamics");
                });
#pragma warning restore 612, 618
        }
    }
}
