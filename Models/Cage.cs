using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class Cage
{
    public int CageId { get; set; }

    public string? CageNumber { get; set; }

    public virtual ICollection<Pet> Pets { get; set; } = new List<Pet>();
}
