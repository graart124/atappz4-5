using Data.model;

namespace Domain
{
    public static class Mapper
    {
        public static HotelRoomDto DomainToDto(HotelRoom hotelRoom)
        {
            HotelRoomDto room;
            if (hotelRoom.StartReservDate != null)
                room = new HotelRoomDto(hotelRoom.Number, hotelRoom.Status, hotelRoom.Category, hotelRoom.StartReservDate, hotelRoom.EndReservDate);
            else
                room =  new HotelRoomDto(hotelRoom.Number, hotelRoom.Status, hotelRoom.Category);
            if (hotelRoom.Id != -1)
            {
                room.Id = hotelRoom.Id;
            }
            return room;
        }

        public static HotelRoom DtoToDomain(HotelRoomDto hotelRoomDto)
        {
            var hotelRoom = new HotelRoom(hotelRoomDto.Number, hotelRoomDto.Status, hotelRoomDto.Category);
            hotelRoom.Id = hotelRoomDto.Id;
            if (hotelRoomDto.StartReservDate != "" && hotelRoomDto.StartReservDate != null)
            {
                hotelRoom.StartReservDate = DateOnly.Parse(hotelRoomDto.StartReservDate);
                hotelRoom.EndReservDate = DateOnly.Parse(hotelRoomDto.EndReservDate!);
            }
            return hotelRoom;
        }

        public static List<HotelRoomDto> DomainToDto(List<HotelRoom> hotelRooms)
        {
            var hotelRoomsDto = new List<HotelRoomDto>();
            foreach (var room in hotelRooms)
            {
                hotelRoomsDto.Add(DomainToDto(room));
            }
            return hotelRoomsDto;
        }

        public static List<HotelRoom> DtoToDomain(List<HotelRoomDto> hotelRoomsDto)
        {
            var hotelRooms = new List<HotelRoom>();
            foreach (var room in hotelRoomsDto)
            {
                hotelRooms.Add(DtoToDomain(room));
            }
            return hotelRooms;
        }
    }
}
