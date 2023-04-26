using Data;
using Data.model;

namespace Domain
{
    public class HotelService
    {

        private UnitOfWork UoW;

        public HotelService()
        {
            UoW = new UnitOfWork(new HotelDbContext());
        }

        public List<HotelRoom> GetAllRooms()
        {
            return Mapper.DtoToDomain(UoW.Repository.GetAll().ToList());
        }

        public List<HotelRoom> GetRoomsByStatus(RoomStatus status)
        {
            return Mapper.DtoToDomain(UoW.Repository.GetAll().ToList())
                         .Where(room => room.Status == status)
                         .ToList();
        }

        public HotelRoom GetRoomById(int id)
        {
            return Mapper.DtoToDomain(UoW.Repository.GetById(id));
        }
        public int BookHotelRoom(HotelRoom hotelRoom,DateOnly startOfReserve,DateOnly endOfReserve)
        {
            int cost = hotelRoom.BookRoom(startOfReserve,endOfReserve);
            UoW.Repository.Update(Mapper.DomainToDto(hotelRoom));
            UoW.SaveChanges();
            return cost;
        }

        public void RentHotelRoom(HotelRoom hotelRoom)
        { 
            hotelRoom.RentHotelRoom();
            UoW.Repository.Update(Mapper.DomainToDto(hotelRoom));
            UoW.SaveChanges();
        }
                
        public void CancelReservation(HotelRoom hotelRoom)
        {
            hotelRoom.CancelReservation();
            UoW.Repository.Update(Mapper.DomainToDto(hotelRoom));
            UoW.SaveChanges();
        }

    }
}
