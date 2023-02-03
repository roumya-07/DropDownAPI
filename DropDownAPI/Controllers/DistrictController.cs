using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DropDownAPI.Models;
using DropDownAPI.Services;

namespace DropDownAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DistrictController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;
        public DistrictController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }
        [HttpGet("{StateID}")]
        public async Task<ActionResult<List<DDEntity>>> GetAllDistrict(int StateID)
        {
            return await _dropDownService.GetAllDistrict(StateID);
        }
    }
}
