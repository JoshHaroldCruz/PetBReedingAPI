using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class Vet
{
    public int VetId { get; set; }

    public string? VetName { get; set; }

    public virtual ICollection<HealthRecord> HealthRecords { get; set; } = new List<HealthRecord>();
}
