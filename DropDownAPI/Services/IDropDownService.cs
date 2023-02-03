using DropDownAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropDownAPI.Services
{
    public interface IDropDownService
    {
        public Task<List<DDEntity>> GetAllCountry();
        public Task<List<DDEntity>> GetAllState(int CountryID);
        public Task<List<DDEntity>> GetAllDistrict(int StateID);
        public Task<int> Insert(DDEntity DD);
    }
}
