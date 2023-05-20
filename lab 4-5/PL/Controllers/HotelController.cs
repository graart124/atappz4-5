using Data.model;
using Domain;
using Microsoft.AspNetCore.Mvc;
using System.Web.Http;
using HttpGetAttribute = Microsoft.AspNetCore.Mvc.HttpGetAttribute;
using HttpPostAttribute = Microsoft.AspNetCore.Mvc.HttpPostAttribute;

namespace PL.Controllers
{
    [ApiController]
    [System.Web.Http.Route("[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly HotelService _hotelService;

        public HotelController()
        {
            _hotelService = new HotelService();
        }

        [Microsoft.AspNetCore.Mvc.HttpGet("all")]
        public IEnumerable<HotelRoomDto> GetAllRooms()
        {

            return Mapper.DomainToDto(_hotelService.GetAllRooms());
        }

        [HttpGet("status/{status}")]
        public IEnumerable<HotelRoomDto> GetRoomsByStatus(RoomStatus status)
        {
            return Mapper.DomainToDto(_hotelService.GetRoomsByStatus(status));
        }

        [HttpGet("{id}")]
        public HotelRoomDto GetRoomById(int id)
        {
            return Mapper.DomainToDto(_hotelService.GetRoomById(id));
        }

        [HttpPost("book/{id}")]
        public IActionResult BookHotelRoom(int id, [FromQuery] String startOfReserve, [FromQuery] String endOfReserve)
        {
            try
            {
                var hotelRoom = _hotelService.GetRoomById(id);
                if (hotelRoom == null)
                {
                    return NotFound();
                }

                DateOnly startDate = DateOnly.Parse(startOfReserve);
                DateOnly endDate = DateOnly.Parse(endOfReserve);

                int cost = _hotelService.BookHotelRoom(hotelRoom, startDate, endDate);
                return Ok(cost);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("rent/{id}")]
        public IActionResult RentHotelRoom(int id)
        {
            try
            {
                var hotelRoom = _hotelService.GetRoomById(id);
                if (hotelRoom == null)
                {
                    return NotFound();
                }

                _hotelService.RentHotelRoom(hotelRoom);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("cancel/{id}")]
        public IActionResult CancelReservation(int id)
        {
            try
            {
                var hotelRoom = _hotelService.GetRoomById(id);
                if (hotelRoom == null)
                {
                    return NotFound();
                }

                _hotelService.CancelReservation(hotelRoom);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}