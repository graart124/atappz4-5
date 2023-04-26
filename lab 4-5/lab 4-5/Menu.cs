using Data.model;
using Domain;

namespace lab_4_5
{
    public static class Menu
    {
        static HotelService service = new HotelService();

        public static void Start()
        {
            try
            {
                Console.WriteLine("0 - show all rooms");
                Console.WriteLine("1 - show rooms by status");
                Console.WriteLine("2 - show detail info about room");
                Console.WriteLine("3 - reserv room");
                Console.WriteLine("4 - book room");
                Console.WriteLine("5 - cancel book/reserve");
                Console.WriteLine("6 - exit");
                switch (int.Parse(Console.ReadLine()))
                {
                    case 0:
                        ShowRooms(service.GetAllRooms());
                        break;
                    case 1:
                        Console.WriteLine("Choose status:");
                        Console.WriteLine("0 - free");
                        Console.WriteLine("1 - booked");
                        Console.WriteLine("2 - rented");
                        var status = (RoomStatus)int.Parse(Console.ReadLine());
                        ShowRooms(service.GetRoomsByStatus(status));
                        break;
                    case 2:
                        ShowRooms(service.GetAllRooms());
                        Console.Write("Choose id of room: ");
                        ShowDetailInfo(service.GetRoomById(int.Parse(Console.ReadLine())));
                        break;
                    case 3:
                        ShowRooms(service.GetAllRooms());
                        Console.Write("Choose id of room: ");
                        service.RentHotelRoom(service.GetRoomById(int.Parse(Console.ReadLine())));
                        break;
                    case 4:
                        ShowRooms(service.GetAllRooms());
                        Console.Write("Choose id of room: ");
                        var room = service.GetRoomById(int.Parse(Console.ReadLine()));
                        Console.WriteLine("Enter start date of reserve(example 01.12.2020)");
                        var startDate = DateOnly.Parse(Console.ReadLine());
                        Console.WriteLine("Enter start date of reserve");
                        var endDate = DateOnly.Parse(Console.ReadLine());
                        var price = service.BookHotelRoom(room, startDate, endDate);
                        Console.WriteLine("Booking success, price = " + price);
                        break;
                    case 5:
                        ShowRooms(service.GetAllRooms());
                        Console.Write("Choose id of room: ");
                        service.CancelReservation(service.GetRoomById(int.Parse(Console.ReadLine())));
                        break;
                    case 6:
                        return;
                    default:
                        Console.WriteLine("You entered unknown command");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
            Console.WriteLine();
            Start();
        }

        private static void ShowDetailInfo(HotelRoom room)
        {
            Console.WriteLine("Id - " + room.Id);
            Console.WriteLine("Number - " + room.Number);
            Console.WriteLine("Status - " + room.Status);
            Console.WriteLine("Category - " + room.Category);
            Console.WriteLine("Price per day - " + room.PricePerDay);
            if (room.Status == RoomStatus.Booked)
            {
                Console.WriteLine("Start of booking - " + room.StartReservDate);
                Console.WriteLine("End of booking - " + room.EndReservDate);
            }
        }

        private static void ShowRooms(List<HotelRoom> rooms)
        {
            Console.WriteLine("Id|Number|Status|Category");
            foreach (var room in rooms)
            {
                Console.WriteLine(room.Id + "|" + room.Number + "|" + room.Status.ToString() + "|" + room.Category.ToString());
            }
        }
    }
}
