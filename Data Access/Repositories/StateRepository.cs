using Housing_Society.Models;
using Microsoft.EntityFrameworkCore;

namespace Housing_Society.Data_Access
{
    public class StateRepository : IStateRepository
    {
        private readonly HousingSocietyContext dbContext;
        public StateRepository(HousingSocietyContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<State> AddState(State state)
        {
            var existing = await dbContext.States
                .Where(x => x.StateName.ToLower() == state.StateName.ToLower())
                .FirstOrDefaultAsync();
            if (existing is not null)
            {
                return existing;
            }
            await dbContext.States.AddAsync(state);

            return state;
        }
    }
}


