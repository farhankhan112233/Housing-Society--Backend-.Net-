using Housing_Society.Models;

namespace Housing_Society.Data_Access
{
    public interface ICityRepository
    {
        public Task<City> AddCity(City city);
    }
}
