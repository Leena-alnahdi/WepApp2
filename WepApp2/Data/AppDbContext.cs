using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WepApp2.Models;

namespace WepApp2.Data;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<BookingDevice> BookingDevices { get; set; }

    public virtual DbSet<Consultation> Consultations { get; set; }

    public virtual DbSet<ConsultationMajor> ConsultationMajors { get; set; }

    public virtual DbSet<Course> Courses { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<DeviceLoan> DeviceLoans { get; set; }

    public virtual DbSet<LabVisit> LabVisits { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<Service> Services { get; set; }

    public virtual DbSet<Technology> Technologies { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VisitsDetail> VisitsDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Server=DESKTOP-6CDP97K;Database=DBGroup2;Trusted_Connection=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Arabic_CI_AI");

        modelBuilder.Entity<BookingDevice>(entity =>
        {
            entity.HasKey(e => e.BookingDevices).HasName("PK__BookingD__EDD3255410E4623A");

            entity.Property(e => e.BookingDevices).ValueGeneratedNever();
            entity.Property(e => e.Department).HasMaxLength(255);
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.Faculty).HasMaxLength(255);
            entity.Property(e => e.ProjectName).HasMaxLength(255);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Device).WithMany(p => p.BookingDevices)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("FK_BookingDevices_Devices");

            entity.HasOne(d => d.Request).WithMany(p => p.BookingDevices)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_BookingDevices_Request");

            entity.HasOne(d => d.Service).WithMany(p => p.BookingDevices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_BookingDevices_Services");
        });

        modelBuilder.Entity<Consultation>(entity =>
        {
            entity.HasKey(e => e.ConsultationId).HasName("PK__Consulta__5D014A7847927F7B");

            entity.Property(e => e.ConsultationId)
                .ValueGeneratedNever()
                .HasColumnName("ConsultationID");
            entity.Property(e => e.CommunicationMethod).HasMaxLength(255);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Request).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_Consultations_Request");

            entity.HasOne(d => d.Service).WithMany(p => p.Consultations)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Consultations_Services");
        });

        modelBuilder.Entity<ConsultationMajor>(entity =>
        {
            entity.HasKey(e => e.ConsultationMajorId).HasName("PK__Consulta__C757E54FCA8BDCBC");

            entity.Property(e => e.ConsultationMajorId)
                .ValueGeneratedNever()
                .HasColumnName("ConsultationMajorID");
            entity.Property(e => e.ConsultationId).HasColumnName("ConsultationID");
            entity.Property(e => e.Major).HasMaxLength(255);

            entity.HasOne(d => d.Consultation).WithMany(p => p.ConsultationMajors)
                .HasForeignKey(d => d.ConsultationId)
                .HasConstraintName("FK_ConsultationMajors_Consultations");
        });

        modelBuilder.Entity<Course>(entity =>
        {
            entity.HasKey(e => e.CourseId).HasName("PK__Courses__C92D718765CDAE24");

            entity.Property(e => e.CourseId)
                .ValueGeneratedNever()
                .HasColumnName("CourseID");
            entity.Property(e => e.CourseField).HasMaxLength(255);
            entity.Property(e => e.CourseName).HasMaxLength(255);
            entity.Property(e => e.PresenterName).HasMaxLength(255);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Request).WithMany(p => p.Courses)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_Courses_Request");

            entity.HasOne(d => d.Service).WithMany(p => p.Courses)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Courses_Services");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.DeviceId).HasName("PK__Devices__49E123315D92FBB2");

            entity.Property(e => e.DeviceId)
                .ValueGeneratedNever()
                .HasColumnName("DeviceID");
            entity.Property(e => e.BrandName).HasMaxLength(255);
            entity.Property(e => e.DeviceLocation).HasMaxLength(255);
            entity.Property(e => e.DeviceModel).HasMaxLength(255);
            entity.Property(e => e.DeviceName).HasMaxLength(255);
            entity.Property(e => e.DeviceStatus).HasMaxLength(255);
            entity.Property(e => e.DeviceType).HasMaxLength(255);
            entity.Property(e => e.LastMaintenance).HasColumnType("datetime");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.SerialNumber).HasMaxLength(255);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Service).WithMany(p => p.Devices)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Devices_Services");
        });

        modelBuilder.Entity<DeviceLoan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__DeviceLo__4F5AD4374F130F35");

            entity.Property(e => e.LoanId)
                .ValueGeneratedNever()
                .HasColumnName("LoanID");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.PreferredContactMethod).HasMaxLength(255);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Device).WithMany(p => p.DeviceLoans)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("FK_DeviceLoans_Devices");

            entity.HasOne(d => d.Request).WithMany(p => p.DeviceLoans)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_DeviceLoans_Request");

            entity.HasOne(d => d.Service).WithMany(p => p.DeviceLoans)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_DeviceLoans_Services");
        });

        modelBuilder.Entity<LabVisit>(entity =>
        {
            entity.HasKey(e => e.LabVisitId).HasName("PK__LabVisit__DDA1234232DDD84C");

            entity.Property(e => e.LabVisitId)
                .ValueGeneratedNever()
                .HasColumnName("LabVisitID");
            entity.Property(e => e.CommunicationMethod).HasMaxLength(255);
            entity.Property(e => e.NumberOfVisitors).HasDefaultValue(1);
            entity.Property(e => e.RequestId).HasColumnName("RequestID");
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

            entity.HasOne(d => d.Request).WithMany(p => p.LabVisits)
                .HasForeignKey(d => d.RequestId)
                .HasConstraintName("FK_LabVisits_Request");

            entity.HasOne(d => d.Service).WithMany(p => p.LabVisits)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_LabVisits_Services");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.RequestId).HasName("PK__Request__33A8519A6244A6D5");

            entity.ToTable("Request");

            entity.Property(e => e.RequestId)
                .ValueGeneratedNever()
                .HasColumnName("RequestID");
            entity.Property(e => e.AdminStatus).HasMaxLength(255);
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.RequestDate).HasColumnType("datetime");
            entity.Property(e => e.RequestType).HasMaxLength(255);
            entity.Property(e => e.ServiceId).HasColumnName("ServiceID");
            entity.Property(e => e.SupervisorStatus).HasMaxLength(255);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Device).WithMany(p => p.Requests)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("FK_Request_Devices");

            entity.HasOne(d => d.Service).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ServiceId)
                .HasConstraintName("FK_Request_Services");

            entity.HasOne(d => d.User).WithMany(p => p.Requests)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_Request_Users");

            entity.HasMany(d => d.CoursesNavigation).WithMany(p => p.Requests)
                .UsingEntity<Dictionary<string, object>>(
                    "CoursesRequest",
                    r => r.HasOne<Course>().WithMany()
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursesRe__Cours__6D0D32F4"),
                    l => l.HasOne<Request>().WithMany()
                        .HasForeignKey("RequestId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__CoursesRe__Reque__6C190EBB"),
                    j =>
                    {
                        j.HasKey("RequestId", "CourseId").HasName("PK__CoursesR__5F3A8682B362A6F7");
                        j.ToTable("CoursesRequests");
                        j.IndexerProperty<int>("RequestId").HasColumnName("RequestID");
                        j.IndexerProperty<int>("CourseId").HasColumnName("CourseID");
                    });
        });

        modelBuilder.Entity<Service>(entity =>
        {
            entity.HasKey(e => e.ServiceId).HasName("PK__Services__C51BB0EACFB7ECCB");

            entity.Property(e => e.ServiceId)
                .ValueGeneratedNever()
                .HasColumnName("ServiceID");
            entity.Property(e => e.ServiceName).HasMaxLength(255);
            entity.Property(e => e.TechnologyId).HasColumnName("TechnologyID");

            entity.HasOne(d => d.Technology).WithMany(p => p.Services)
                .HasForeignKey(d => d.TechnologyId)
                .HasConstraintName("FK_Services_Technologies");
        });

        modelBuilder.Entity<Technology>(entity =>
        {
            entity.HasKey(e => e.TechnologyId).HasName("PK__Technolo__705701784316E071");

            entity.Property(e => e.TechnologyId)
                .ValueGeneratedNever()
                .HasColumnName("TechnologyID");
            entity.Property(e => e.DeviceId).HasColumnName("DeviceID");
            entity.Property(e => e.TechnologyName).HasMaxLength(255);

            entity.HasOne(d => d.Device).WithMany(p => p.Technologies)
                .HasForeignKey(d => d.DeviceId)
                .HasConstraintName("FK_Technologies_Devices");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC48D148C7");

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnName("UserID");
            entity.Property(e => e.Department).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Faculty).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(255);
            entity.Property(e => e.IsActive).HasDefaultValue(true);
            entity.Property(e => e.LastLogIn).HasColumnType("datetime");
            entity.Property(e => e.LastName).HasMaxLength(255);
            entity.Property(e => e.PassWord).HasMaxLength(255);
            entity.Property(e => e.Role).HasMaxLength(255);
            entity.Property(e => e.UserName).HasMaxLength(255);
        });

        modelBuilder.Entity<VisitsDetail>(entity =>
        {
            entity.HasKey(e => e.VisitsDetailsId).HasName("PK__VisitsDe__746A09CF6F218A8C");

            entity.Property(e => e.VisitsDetailsId)
                .ValueGeneratedNever()
                .HasColumnName("VisitsDetailsID");
            entity.Property(e => e.LabVisitId).HasColumnName("LabVisitID");
            entity.Property(e => e.VisitType)
                .HasMaxLength(255)
                .HasColumnName("visitType");

            entity.HasOne(d => d.LabVisit).WithMany(p => p.VisitsDetails)
                .HasForeignKey(d => d.LabVisitId)
                .HasConstraintName("FK_VisitsDetails_LabVisits");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
