using System.Collections.Generic;

namespace CommunityProApp.Entities
{
    public class RoomType : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }

        public decimal Price { get; set; }

        public int MaxNumberOfAdult { get; set; }
        public ICollection<Room> Rooms { get; set; } = new List<Room>();
    }
}
