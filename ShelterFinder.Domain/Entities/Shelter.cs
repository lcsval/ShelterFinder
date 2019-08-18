namespace ShelterFinder.Domain.Entities
{
    public class Shelter
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }
    }
}
