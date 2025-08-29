using Housing_Society.DTOs;

namespace Housing_Society.Buisness_Logic
{
    public interface IHousingService
    {
        Task<HouseResponseDto> SaveSociety(HouseRequestDto dto);
        Task<IEnumerable<HouseDto>> GetAllSocieties();
        Task<HouseDto> GetHouseById(int id);
    }
}
