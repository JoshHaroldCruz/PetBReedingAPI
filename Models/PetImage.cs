using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class PetImage
{
    public int PetImageId { get; set; }

    public int? PetId { get; set; }

    public byte[]? FilePath { get; set; }

    public DateOnly? UploadDate { get; set; }

    public virtual Pet? Pet { get; set; }
}
