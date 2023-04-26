namespace Data.model
{
    public class HotelRoomDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public RoomStatus Status { get; set; }
        public RoomCategory Category { get; set; }
        public string? StartReservDate { get; set; } //= new DateTime();
        public string? EndReservDate { get; set; } //= new DateTime();
        public HotelRoomDto()
        {

        }
        public HotelRoomDto(string number, RoomStatus roomStatus, RoomCategory roomCategory)
        {
            Number = number;
            Status = roomStatus;
            Category = roomCategory;
        }
        public HotelRoomDto(string number, RoomStatus roomStatus, RoomCategory roomCategory, DateOnly? startDate, DateOnly? endDate)
            : this(number, roomStatus, roomCategory)
        {
            StartReservDate = startDate.ToString();
            EndReservDate = endDate.ToString();
        }
    }
}