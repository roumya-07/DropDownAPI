using DropDownAPI.Models;
using DropDownAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropDownAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StateController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;
        public StateController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }
        [HttpGet("{CountryID}")]
        public async Task<ActionResult<List<DDEntity>>> GetAllState(int CountryID)
        {
            return await _dropDownService.GetAllState(CountryID);
        }
    }
}
