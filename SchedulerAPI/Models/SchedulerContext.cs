using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SchedulerAPI.Models;

public partial class SchedulerContext : DbContext
{
    public SchedulerContext()
    {
    }

    public SchedulerContext(DbContextOptions<SchedulerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Fact> Facts { get; set; }

    public virtual DbSet<Laborcost> Laborcosts { get; set; }

    public virtual DbSet<Plannedlaborcost> Plannedlaborcosts { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<PostDynamic> PostDynamics { get; set; }

    public virtual DbSet<Project> Projects { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Scenario> Scenarios { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Scheduler;Username=postgres;Password=1");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Fact>(entity =>
        {
            entity.HasKey(e => e.Factid).HasName("fact_pk");

            entity.ToTable("fact");

            entity.Property(e => e.Factid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("factid");
            entity.Property(e => e.Factname)
                .HasColumnType("character varying")
                .HasColumnName("factname");
        });

        modelBuilder.Entity<Laborcost>(entity =>
        {
            entity.HasKey(e => e.Laborcostid).HasName("laborcost_pk");

            entity.ToTable("laborcost");

            entity.Property(e => e.Laborcostid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("laborcostid");
            entity.Property(e => e.Laborcostname)
                .HasColumnType("character varying")
                .HasColumnName("laborcostname");
        });

        modelBuilder.Entity<Plannedlaborcost>(entity =>
        {
            entity.HasKey(e => e.Plannedlaborcostid).HasName("plannedlaborcost_pk");

            entity.ToTable("plannedlaborcost");

            entity.Property(e => e.Plannedlaborcostid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("plannedlaborcostid");
            entity.Property(e => e.Factid).HasColumnName("factid");
            entity.Property(e => e.Laborcostid).HasColumnName("laborcostid");
            entity.Property(e => e.Plannedlaborcostfilldate).HasColumnName("plannedlaborcostfilldate");
            entity.Property(e => e.Plannedlaborcostpercent).HasColumnName("plannedlaborcostpercent");
            entity.Property(e => e.Projectid).HasColumnName("projectid");
            entity.Property(e => e.Scenarioid).HasColumnName("scenarioid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Fact).WithMany(p => p.Plannedlaborcosts)
                .HasForeignKey(d => d.Factid)
                .HasConstraintName("plannedlaborcost_fk_2");

            entity.HasOne(d => d.Laborcost).WithMany(p => p.Plannedlaborcosts)
                .HasForeignKey(d => d.Laborcostid)
                .HasConstraintName("plannedlaborcost_fk_4");

            entity.HasOne(d => d.Project).WithMany(p => p.Plannedlaborcosts)
                .HasForeignKey(d => d.Projectid)
                .HasConstraintName("plannedlaborcost_fk_1");

            entity.HasOne(d => d.Scenario).WithMany(p => p.Plannedlaborcosts)
                .HasForeignKey(d => d.Scenarioid)
                .HasConstraintName("plannedlaborcost_fk_3");

            entity.HasOne(d => d.User).WithMany(p => p.Plannedlaborcosts)
                .HasForeignKey(d => d.Userid)
                .HasConstraintName("plannedlaborcost_fk");
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.Postid).HasName("post_pk");

            entity.ToTable("Post");

            entity.Property(e => e.Postid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("postid");
            entity.Property(e => e.Postname)
                .HasColumnType("character varying")
                .HasColumnName("postname");
        });

        modelBuilder.Entity<PostDynamic>(entity =>
        {
            entity.HasKey(e => e.Postdynamicid).HasName("postdynamic_pk");

            entity.ToTable("PostDynamic");

            entity.Property(e => e.Postdynamicid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("postdynamicid");
            entity.Property(e => e.Postdynamicstartdate).HasColumnName("postdynamicstartdate");
            entity.Property(e => e.Postid).HasColumnName("postid");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.Post).WithMany(p => p.PostDynamics)
                .HasForeignKey(d => d.Postid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("postdynamic_fk_1");

            entity.HasOne(d => d.User).WithMany(p => p.PostDynamics)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("postdynamic_fk");
        });

        modelBuilder.Entity<Project>(entity =>
        {
            entity.HasKey(e => e.Projectid).HasName("project_pk");

            entity.ToTable("project");

            entity.Property(e => e.Projectid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("projectid");
            entity.Property(e => e.Projectcreationdate).HasColumnName("projectcreationdate");
            entity.Property(e => e.Projectfinishdate).HasColumnName("projectfinishdate");
            entity.Property(e => e.Projectname)
                .HasColumnType("character varying")
                .HasColumnName("projectname");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Roleid).HasName("role_pk");

            entity.ToTable("Role");

            entity.Property(e => e.Roleid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("roleid");
            entity.Property(e => e.Rolename)
                .HasColumnType("character varying")
                .HasColumnName("rolename");
        });

        modelBuilder.Entity<Scenario>(entity =>
        {
            entity.HasKey(e => e.Scenarioid).HasName("scenario_pk");

            entity.ToTable("scenario");

            entity.Property(e => e.Scenarioid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("scenarioid");
            entity.Property(e => e.Scenarioname)
                .HasColumnType("character varying")
                .HasColumnName("scenarioname");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("user_pk");

            entity.ToTable("User");

            entity.Property(e => e.Userid)
                .UseIdentityAlwaysColumn()
                .HasColumnName("userid");
            entity.Property(e => e.Roleid).HasColumnName("roleid");
            entity.Property(e => e.Useremail)
                .HasColumnType("character varying")
                .HasColumnName("useremail");
            entity.Property(e => e.Userlogin)
                .HasColumnType("character varying")
                .HasColumnName("userlogin");
            entity.Property(e => e.Username)
                .HasColumnType("character varying")
                .HasColumnName("username");
            entity.Property(e => e.Userpassword)
                .HasColumnType("character varying")
                .HasColumnName("userpassword");
            entity.Property(e => e.Userpatronymic)
                .HasColumnType("character varying")
                .HasColumnName("userpatronymic");
            entity.Property(e => e.Usersurname)
                .HasColumnType("character varying")
                .HasColumnName("usersurname");

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.Roleid)
                .HasConstraintName("user_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
