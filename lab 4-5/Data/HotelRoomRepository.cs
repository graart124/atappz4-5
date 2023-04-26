using Data.model;
using System.Data.Entity;

namespace Data
{
    public class HotelRoomRepository : IRepository<HotelRoomDto>
    {
        private readonly DbContext _dbContext;

        public HotelRoomRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<HotelRoomDto> GetAll()
        {
            return _dbContext.Set<HotelRoomDto>();
        }

        public HotelRoomDto GetById(int id)
        {
            return _dbContext.Set<HotelRoomDto>().Find(id);
        }

        public void Insert(HotelRoomDto entity)
        {
            _dbContext.Set<HotelRoomDto>().Add(entity);
        }

        public void Update(HotelRoomDto entity)
        {
            var existingEntity = _dbContext.Set<HotelRoomDto>().Find(entity.Id);

            if (existingEntity != null)
            {
                existingEntity.Category = entity.Category;
                existingEntity.Status = entity.Status;
                existingEntity.StartReservDate = entity.StartReservDate;
                existingEntity.EndReservDate = entity.EndReservDate;

                _dbContext.Entry(existingEntity).State = EntityState.Modified;
            }
        }

        public void Delete(int id)
        {
            var hotelRoom = _dbContext.Set<HotelRoomDto>().Find(id);
            _dbContext.Set<HotelRoomDto>().Remove(hotelRoom);
        }
    }
}
