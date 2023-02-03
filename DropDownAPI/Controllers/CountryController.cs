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
    public class CountryController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;
        public CountryController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }
        [HttpGet]
        public async Task<ActionResult<List<DDEntity>>> GetAllCountry()
        {
            return await _dropDownService.GetAllCountry();
        }
    }
}
