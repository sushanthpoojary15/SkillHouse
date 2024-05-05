using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EduSync.DataAccess.Entities;

public partial class EduSyncContext : DbContext
{
    public EduSyncContext()
    {
    }

    public EduSyncContext(DbContextOptions<EduSyncContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Session> Sessions { get; set; }

    public virtual DbSet<SessionAttendance> SessionAttendances { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Xyz> Xyzs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=EduSync;Trusted_Connection=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3AC24041CC");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Session>(entity =>
        {
            entity.HasKey(e => e.SessionId).HasName("PK__Session__C9F492702E8B2E7D");

            entity.ToTable("Session");

            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");

            entity.HasOne(d => d.Staff).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK__Session__StaffID__4316F928");

            entity.HasOne(d => d.Subject).WithMany(p => p.Sessions)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("FK__Session__Subject__440B1D61");
        });

        modelBuilder.Entity<SessionAttendance>(entity =>
        {
            entity.HasKey(e => e.AttendanceId).HasName("PK__SessionA__8B69263CB42FBC11");

            entity.ToTable("SessionAttendance");

            entity.Property(e => e.AttendanceId).HasColumnName("AttendanceID");
            entity.Property(e => e.SessionId).HasColumnName("SessionID");
            entity.Property(e => e.StudentId).HasColumnName("StudentID");

            entity.HasOne(d => d.Session).WithMany(p => p.SessionAttendances)
                .HasForeignKey(d => d.SessionId)
                .HasConstraintName("FK__SessionAt__Sessi__46E78A0C");

            entity.HasOne(d => d.Student).WithMany(p => p.SessionAttendances)
                .HasForeignKey(d => d.StudentId)
                .HasConstraintName("FK__SessionAt__Stude__47DBAE45");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AAF79751556B");

            entity.Property(e => e.StaffId).HasColumnName("StaffID");
            entity.Property(e => e.Department).HasMaxLength(100);
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.StudentId).HasName("PK__Student__32C52A7968568181");

            entity.ToTable("Student");

            entity.Property(e => e.StudentId).HasColumnName("StudentID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("PK__Subject__AC1BA3888C9ADE19");

            entity.ToTable("Subject");

            entity.Property(e => e.SubjectId).HasColumnName("SubjectID");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC6EE879BC");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastLogin).HasColumnType("datetime");
            entity.Property(e => e.LastName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Xyz>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__XYZ__3214EC27FB4A63C6");

            entity.ToTable("XYZ");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Column1)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Column2)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    

}
