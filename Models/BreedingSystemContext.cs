using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace PetBreedingSystemAPI.Models;

public partial class BreedingSystemContext : DbContext
{
    public BreedingSystemContext()
    {
    }

    public BreedingSystemContext(DbContextOptions<BreedingSystemContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Breed> Breeds { get; set; }

    public virtual DbSet<Breeding> Breedings { get; set; }

    public virtual DbSet<Cage> Cages { get; set; }

    public virtual DbSet<Conception> Conceptions { get; set; }

    public virtual DbSet<HealthRecord> HealthRecords { get; set; }

    public virtual DbSet<Pet> Pets { get; set; }

    public virtual DbSet<PetFile> PetFiles { get; set; }

    public virtual DbSet<PetImage> PetImages { get; set; }

    public virtual DbSet<Species> Species { get; set; }

    public virtual DbSet<Vet> Vets { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-BHTIKKT\\SQLEXPRESS;Database=BreedingSystem2;User Id=sa;Password=12345;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Breed>(entity =>
        {
            entity.ToTable("Breed");

            entity.Property(e => e.BreedDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.BreedName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Breeding>(entity =>
        {
            entity.ToTable("Breeding");

            entity.Property(e => e.BreedingName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FemalePetId).HasColumnName("Female_PetId");
            entity.Property(e => e.MalePetId).HasColumnName("Male_PetId");
            entity.Property(e => e.SpeciesName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.FemalePet).WithMany(p => p.BreedingFemalePets)
                .HasForeignKey(d => d.FemalePetId)
                .HasConstraintName("FK_Breeding_Pet1");

            entity.HasOne(d => d.MalePet).WithMany(p => p.BreedingMalePets)
                .HasForeignKey(d => d.MalePetId)
                .HasConstraintName("FK_Breeding_Pet");
        });

        modelBuilder.Entity<Cage>(entity =>
        {
            entity.ToTable("Cage");

            entity.Property(e => e.CageNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Conception>(entity =>
        {
            entity.ToTable("Conception");

            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Pet).WithMany(p => p.Conceptions)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK_Conception_Pet");
        });

        modelBuilder.Entity<HealthRecord>(entity =>
        {
            entity.HasKey(e => e.RecordId);

            entity.ToTable("HealthRecord");

            entity.Property(e => e.Description)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Treatment)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Pet).WithMany(p => p.HealthRecords)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK_HealthRecord_Pet");

            entity.HasOne(d => d.Vet).WithMany(p => p.HealthRecords)
                .HasForeignKey(d => d.VetId)
                .HasConstraintName("FK_HealthRecord_Vet");
        });

        modelBuilder.Entity<Pet>(entity =>
        {
            entity.ToTable("Pet");

            entity.Property(e => e.FatherPetId).HasColumnName("Father_PetId");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.MotherPetId).HasColumnName("Mother_PetId");
            entity.Property(e => e.PetColor)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PetDescription)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.PetName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Breed).WithMany(p => p.Pets)
                .HasForeignKey(d => d.BreedId)
                .HasConstraintName("FK_Pet_Breed");

            entity.HasOne(d => d.Cage).WithMany(p => p.Pets)
                .HasForeignKey(d => d.CageId)
                .HasConstraintName("FK_Pet_Cage");
        });

        modelBuilder.Entity<PetFile>(entity =>
        {
            entity.HasKey(e => e.FileId).HasName("PK_File");

            entity.ToTable("PetFile");

            entity.Property(e => e.FileName).IsUnicode(false);
            entity.Property(e => e.FilePath).IsUnicode(false);

            entity.HasOne(d => d.Pet).WithMany(p => p.PetFiles)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK_File_Pet");
        });

        modelBuilder.Entity<PetImage>(entity =>
        {
            entity.ToTable("PetImage");

            entity.HasOne(d => d.Pet).WithMany(p => p.PetImages)
                .HasForeignKey(d => d.PetId)
                .HasConstraintName("FK_PetImage_Pet");
        });

        modelBuilder.Entity<Species>(entity =>
        {
            entity.Property(e => e.SpeciesDescription)
                .HasMaxLength(500)
                .IsFixedLength();
            entity.Property(e => e.SpeciesName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Vet>(entity =>
        {
            entity.ToTable("Vet");

            entity.Property(e => e.VetId).ValueGeneratedNever();
            entity.Property(e => e.VetName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
