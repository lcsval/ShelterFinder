namespace ShelterFinder.Domain.Command.Shelter
{
    public class ShelterBaseCommand : BaseCommand
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public int Gender { get; set; }
        public long Latitude { get; set; }
        public long Longitude { get; set; }

        public ShelterFinder.Domain.Entities.Shelter Map()
        {
            var entity = new ShelterFinder.Domain.Entities.Shelter();
            entity.Id = this.Id;
            entity.Name = this.Name;
            entity.Address = this.Address;
            entity.Phone = this.Phone;
            entity.Gender = this.Gender;
            entity.Latitude = this.Latitude;
            entity.Longitude = this.Longitude;
            return entity;
        }
    }
}
