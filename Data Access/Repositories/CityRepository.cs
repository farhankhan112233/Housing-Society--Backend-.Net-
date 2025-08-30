using Housing_Society.Models;
using Microsoft.EntityFrameworkCore;

namespace Housing_Society.Data_Access
{
    public class CityRepository : ICityRepository
    {
        private readonly HousingSocietyContext dbContext;
        public CityRepository(HousingSocietyContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<City> AddCity(City city)
        {
            var existing = await dbContext.Cities
               .FirstOrDefaultAsync(x => x.CityName.ToLower() == city.CityName.ToLower());
            if (existing != null)
            {
                return existing;
            }
            await dbContext.Cities.AddAsync(city);
            return city;
        }
    }
}
