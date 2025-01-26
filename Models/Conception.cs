using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class Conception
{
    public int ConceptionId { get; set; }

    public int? PetId { get; set; }

    public string? Status { get; set; }

    public string? Notes { get; set; }

    public virtual Pet? Pet { get; set; }
}
