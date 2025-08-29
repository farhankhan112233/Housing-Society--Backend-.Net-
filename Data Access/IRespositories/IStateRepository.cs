using Housing_Society.Models;

namespace Housing_Society.Data_Access
{
    public interface IStateRepository
    {
        public Task<State> AddState(State state);
    }
}
