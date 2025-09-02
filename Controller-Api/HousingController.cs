using Housing_Society.Buisness_Logic;
using Housing_Society.Data_Access;
using Housing_Society.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Housing_Society.Controller_Api
{
    [Route("api/[controller]")]
    [ApiController]
    
    public class HousingController : ControllerBase
    {
        private readonly IHousingService _service;
        public HousingController(IHousingService service)
        {
            _service = service;
        }
        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> SaveSociety([FromForm] HouseRequestDto dto)
        {
            var AddSociety = await _service.SaveSociety(dto);
            if (AddSociety is null)
            {
                return BadRequest("Society Already Exists");
            }
            return Ok(AddSociety);
        }
        [Authorize(Roles ="User,Admin")]
        [HttpGet("Get-Houses")]
        public async Task<IActionResult> GetAllSocieties()
        {
            var AllSocities = await _service.GetAllSocieties();
            return Ok(AllSocities);
        }

        [Authorize(Roles = "User,Admin")]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetHouseById(int id)
        {
            var HouseById = await _service.GetHouseById(id);
            if(HouseById is null)
            {
                return BadRequest("Not Found");
            }
            return Ok(HouseById);
        }

    }
}
