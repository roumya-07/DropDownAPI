using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DropDownAPI.Models;
using DropDownAPI.Repository;
using DropDownAPI.Services;

namespace DropDownAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DropDownController : ControllerBase
    {
        private readonly IDropDownService _dropDownService;
        public DropDownController(IDropDownService dropDownService)
        {
            _dropDownService = dropDownService;
        }

        [HttpPut()]
        public async Task<ActionResult<DDEntity>> Insert(DDEntity DD)
        {
            try
            {
                await _dropDownService.Insert(DD);

                return CreatedAtAction("Insert", DD);
            }

            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
