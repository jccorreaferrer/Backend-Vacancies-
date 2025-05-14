using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace vacancyApiNET8.Models;

public partial class VacancyTrackerContext : DbContext
{
    public VacancyTrackerContext()
    {
    }

    public VacancyTrackerContext(DbContextOptions<VacancyTrackerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CatColor> CatColors { get; set; }

    public virtual DbSet<CatContractType> CatContractTypes { get; set; }

    public virtual DbSet<CatCurrency> CatCurrencies { get; set; }

    public virtual DbSet<CatLanguage> CatLanguages { get; set; }

    public virtual DbSet<CatStatus> CatStatuses { get; set; }

    public virtual DbSet<Note> Notes { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vacancy> Vacancies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CatColor>(entity =>
        {
            entity.HasKey(e => e.IdCatColor).HasName("PK__CatColor__F613EF8EE6176E51");

            entity.ToTable("CatColor");

            entity.Property(e => e.Notation)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CatContractType>(entity =>
        {
            entity.HasKey(e => e.IdCatContractType).HasName("PK__CatContr__52A34B2B83F81C2D");

            entity.ToTable("CatContractType");

            entity.Property(e => e.Notation)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CatCurrency>(entity =>
        {
            entity.HasKey(e => e.IdCatCurrency).HasName("PK__CatCurre__A3BC75B9666A3CBE");

            entity.ToTable("CatCurrency");

            entity.Property(e => e.Notation)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CatLanguage>(entity =>
        {
            entity.HasKey(e => e.IdCatLanguage).HasName("PK__CatLangu__57694F18DCB0E3C1");

            entity.ToTable("CatLanguage");

            entity.Property(e => e.Notation)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<CatStatus>(entity =>
        {
            entity.HasKey(e => e.IdCatStatus).HasName("PK__CatStatu__8342856ED1EE3E5E");

            entity.ToTable("CatStatus");

            entity.Property(e => e.Notation)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Note>(static entity =>
        {
            entity.HasKey(e => e.IdNote).HasName("PK__Note__4B2ACFF60C7B6EEF");

            entity.ToTable("Note");

            entity.Property(e => e.Notation)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdVacancyNavigation).WithMany(p => p.Notes)
                .HasForeignKey(d => d.IdVacancy)
                .HasConstraintName("FK_Note_Vacancy");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.IdStatus).HasName("PK__Status__B450643A015C716F");

            entity.ToTable("Status");

            entity.HasOne(d => d.IdCatStatusNavigation).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.IdCatStatus)
                .HasConstraintName("FK__Status__IdCatSta__35BCFE0A");

            entity.HasOne(d => d.IdNoteNavigation).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.IdNote)
                .HasConstraintName("FK__Status__IdNote__36B12243");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__User__B7C92638D67766C8");

            entity.ToTable("User");

            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FirstName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.LastName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(15)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vacancy>(entity =>
        {
            entity.HasKey(e => e.IdVacancy).HasName("PK__Vacancy__A58A0669271CD192");

            entity.ToTable("Vacancy");

            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.JobDescription)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.JobPositionName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.RequiredSkill)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Salary)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.VacancyLink)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.IdCatColorNavigation).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.IdCatColor)
                .HasConstraintName("FK__Vacancy__IdCatCo__3F466844");

            entity.HasOne(d => d.IdCatContractTypeNavigation).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.IdCatContractType)
                .HasConstraintName("FK__Vacancy__IdCatCo__3A81B327");

            entity.HasOne(d => d.IdCatCurrencyNavigation).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.IdCatCurrency)
                .HasConstraintName("FK__Vacancy__IdCatCu__3D5E1FD2");

            entity.HasOne(d => d.IdCatLanguageNavigation).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.IdCatLanguage)
                .HasConstraintName("FK__Vacancy__IdCatLa__3B75D760");

            entity.HasOne(d => d.IdStatusNavigation).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.IdStatus)
                .HasConstraintName("FK__Vacancy__IdStatu__403A8C7D");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Vacancies)
                .HasForeignKey(d => d.IdUsuario)
                .HasConstraintName("FK__Vacancy__IdUsuar__398D8EEE");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
