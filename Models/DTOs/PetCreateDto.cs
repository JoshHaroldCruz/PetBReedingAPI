namespace PetBreedingSystemAPI.Models.DTOs
{
    public class PetCreateDto
    {
        public string PetName { get; set; }
        public string Gender { get; set; }
        public DateTime? PetBirthdate { get; set; }
        public int BreedId { get; set; }
        public int CageId { get; set; }
    }
}
