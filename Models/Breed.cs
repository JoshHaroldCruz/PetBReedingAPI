using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class Breed
{
    public int BreedId { get; set; }

    public string? BreedName { get; set; }

    public string? BreedDescription { get; set; }

    public int? SpeciesId { get; set; }
    public virtual Species? Species { get; set; } // Navigation Property

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
