using IndustrialTaskZooAPI.Models.Enums;

namespace IndustrialTaskZooAPI.Models
{
    public class Animal
    {
        public long Id { get; set; } 
        public string Name { get; set; }
        public string Species { get; set; } 
        public DietType DietType { get; set; }

        public bool IsGiraffe => Species.Equals("Giraffe", StringComparison.OrdinalIgnoreCase);
    }
}
