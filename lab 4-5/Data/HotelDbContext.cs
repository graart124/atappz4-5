using Data.model;
using System.Data.Entity;

namespace Data
{
    public class HotelDbContext : DbContext
    {
        public HotelDbContext():base("db")
        {

        }
        public DbSet<HotelRoomDto> HotelRooms { get; set; }
    }
}
