using Data.model;

namespace Domain
{
    public class HotelRoom
    {
        public int Id { get; set; }
        public string Number { get; private set; }
        public RoomStatus Status { get; private set; }
        public RoomCategory Category { get; private set; }
        public DateOnly? StartReservDate { get; set; }
        public DateOnly? EndReservDate { get; set; }

        public int PricePerDay
        {
            get
            {
                switch (Category)
                {
                    case RoomCategory.Standard:
                        return 200;
                    case RoomCategory.Suite:
                        return 420;
                    default:
                        return 750;
                }
            }
        }

        public HotelRoom(string number, RoomStatus roomStatus, RoomCategory roomCategory)
        {
            Number = number;
            Status = roomStatus;
            Category = roomCategory;
        }
        public HotelRoom(string number, RoomStatus roomStatus, RoomCategory roomCategory, DateOnly startDate, DateOnly endDate)
            : this(number, roomStatus, roomCategory)
        {
            StartReservDate = startDate;
            EndReservDate = endDate;
        }
        public HotelRoom(string number, RoomStatus roomStatus, RoomCategory roomCategory, string startDate, string endDate)
            : this(number, roomStatus, roomCategory)
        {
            StartReservDate = DateOnly.Parse(startDate);
            EndReservDate = DateOnly.Parse(endDate);
        }

        public int BookRoom(DateOnly startOfReserve, DateOnly endOfReserve)
        {
            if (Status != RoomStatus.Free) throw new Exception("Room rented/booked now. U can`t book this room");
            if (endOfReserve <= startOfReserve) throw new Exception("Date for booking uncorrect");
            StartReservDate = startOfReserve;
            EndReservDate = endOfReserve;
            Status = RoomStatus.Booked;
            TimeSpan timeSpan = new DateTime(endOfReserve.Year, endOfReserve.Month, endOfReserve.Day) - new DateTime(startOfReserve.Year, startOfReserve.Month, startOfReserve.Day);

            int countOfDays = (int)timeSpan.Days;

            return countOfDays * PricePerDay;
        }

        public void RentHotelRoom()
        {
            if (Status != RoomStatus.Free) throw new Exception("Room rented/booked now. U can`t book this room");
            Status = RoomStatus.Rented;
        }

        public void CancelReservation()
        {
            if (Status == RoomStatus.Free) throw new Exception("Room is not reserved/booked");
            Status = RoomStatus.Free;
        }
    }
}
