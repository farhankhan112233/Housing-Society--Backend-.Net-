using Housing_Society.Models;

namespace Housing_Society.Data_Access
{
    public interface IHouseRepository
    {
        public Task<House> AddHouse(House house);
        public Task<List<House>> GetAll();
        public Task<House> GetById(int id);
    }
}
