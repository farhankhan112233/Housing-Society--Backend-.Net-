using Housing_Society.Models;
using Housing_Society.DTOs;
using Microsoft.EntityFrameworkCore;

namespace Housing_Society.Data_Access
{
    public class HouseRepository: IHouseRepository
    {
        private readonly HousingSocietyContext dbContext;
        public HouseRepository(HousingSocietyContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<House> AddHouse(House house)
        {
            var existing = await dbContext.Houses
                .FirstOrDefaultAsync(x => x.Name == house.Name);
            if(existing != null)
            {
                return null;
            }
            await dbContext.Houses.AddAsync(house);
            return house;
        }
        public async Task<List<House>> GetAll()
        {
            var AllSocieties = await dbContext.Houses
                .Include(x => x.City)
                .ThenInclude(x=>x.State)
                .Include(x => x.Photos)
                .AsNoTracking()
                .ToListAsync();
            return AllSocieties;
        }
        public async Task<House> GetById(int id)
        {
            var existingHouse = await dbContext.Houses
                .Where(x => x.Id == id)
                .Include(x => x.City)
                .ThenInclude(x => x.State)
                .Include(x => x.Photos)
                .AsNoTracking()
                .FirstOrDefaultAsync();
            return existingHouse;
        }
    }
    
}
