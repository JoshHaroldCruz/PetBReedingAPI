using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class Pet
{
    public int PetId { get; set; }

    public int? BreedId { get; set; }

    public string? Gender { get; set; }

    public string? PetName { get; set; }

    public DateTime PetBirthdate { get; set; }

    public string? PetColor { get; set; }

    public string? PetDescription { get; set; }

    public int? CageId { get; set; }

    public int? MotherPetId { get; set; }

    public int? FatherPetId { get; set; }

    public virtual Breed? Breed { get; set; }

    public virtual ICollection<Breeding> BreedingFemalePets { get; set; } = new List<Breeding>();

    public virtual ICollection<Breeding> BreedingMalePets { get; set; } = new List<Breeding>();

    public virtual Cage? Cage { get; set; }

    public virtual ICollection<Conception> Conceptions { get; set; } = new List<Conception>();

    public virtual ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();

    public virtual ICollection<PetFile> PetFiles { get; set; } = new List<PetFile>();

    public virtual ICollection<PetImage> PetImages { get; set; } = new List<PetImage>();
}
