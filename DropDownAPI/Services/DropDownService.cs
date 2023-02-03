using DropDownAPI.Models;
using DropDownAPI.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DropDownAPI.Services
{
    public class DropDownService : IDropDownService
    {
        private readonly IDropDownRepository _dropDownRepository;
        public DropDownService(IDropDownRepository dropDownRepository)
        {
            _dropDownRepository = dropDownRepository;
        }
        public async Task<List<DDEntity>> GetAllCountry()
        {
            return await _dropDownRepository.GetAllCountry();
        }

        public async Task<List<DDEntity>> GetAllDistrict(int StateID)
        {
            return await _dropDownRepository.GetAllDistrict(StateID);
        }

        public async Task<List<DDEntity>> GetAllState(int CountryID)
        {
            return await _dropDownRepository.GetAllState(CountryID);
        }

        public async Task<int> Insert(DDEntity DD)
        {
            return await _dropDownRepository.Insert(DD);
        }
    }
}
