using Housing_Society.Buisness_Logic;
using Housing_Society.Data_Access;
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
        //[HttpPost]
        //public Task<IActionResult> GetAllHouses()
        //{

        //}

    }
}
