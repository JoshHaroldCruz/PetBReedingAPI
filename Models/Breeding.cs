using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class Breeding
{
    public int BreedingId { get; set; }

    public string? SpeciesName { get; set; }

    public string? BreedingName { get; set; }

    public int? MalePetId { get; set; }

    public int? FemalePetId { get; set; }

    public DateOnly? BreedingDate { get; set; }

    public DateOnly? ExpectedDate { get; set; }

    public string? Status { get; set; }

    public virtual Pet? FemalePet { get; set; }

    public virtual Pet? MalePet { get; set; }
}
