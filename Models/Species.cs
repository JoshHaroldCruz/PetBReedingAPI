using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class Species
{
    public int SpeciesId { get; set; }

    public string? SpeciesName { get; set; }

    public string? SpeciesDescription { get; set; }
    public virtual ICollection<Breed> Breeds { get; set; } = new List<Breed>(); // Inverse Navigation Property
}
