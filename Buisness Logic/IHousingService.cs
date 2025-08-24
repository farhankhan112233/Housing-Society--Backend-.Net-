using Housing_Society.Models;

namespace Housing_Society.Buisness_Logic
{
    public interface IHousingService
    {
        Task<IEnumerable<House>> GetAll();
    }
}
