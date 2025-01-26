using System;
using System.Collections.Generic;

namespace PetBreedingSystemAPI.Models;

public partial class PetFile
{
    public int FileId { get; set; }

    public int? PetId { get; set; }

    public string? FileName { get; set; }

    public string? FilePath { get; set; }

    public DateOnly? UploadDate { get; set; }

    public virtual Pet? Pet { get; set; }
}
