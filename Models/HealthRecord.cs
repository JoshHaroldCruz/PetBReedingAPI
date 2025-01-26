using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class HealthRecord
{
    public int RecordId { get; set; }

    public int? PetId { get; set; }

    public DateOnly? RecordDate { get; set; }

    public string? Description { get; set; }

    public string? Treatment { get; set; }

    public int? VetId { get; set; }

    public string? Notes { get; set; }

    public virtual Pet? Pet { get; set; }

    public virtual Vet? Vet { get; set; }
}
