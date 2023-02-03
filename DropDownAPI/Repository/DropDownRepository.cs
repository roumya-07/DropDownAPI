using Dapper;
using DropDownAPI.Models;
using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using DropDownAPI.Services;

namespace DropDownAPI.Repository
{
    public class DropDownRepository : BaseRepository, IDropDownRepository
    {
        public DropDownRepository(IConfiguration configuration) : base(configuration)
        {

        }
        public async Task<List<DDEntity>> GetAllCountry()
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@Action", "FillCountry");
                var lstste = await cn.QueryAsync<DDEntity>("SP_DropDown", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DDEntity>> GetAllState(int CountryID)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@CountryID", CountryID);
                param.Add("@Action", "FillState");
                var lstste = await cn.QueryAsync<DDEntity>("SP_DropDown", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<List<DDEntity>> GetAllDistrict(int StateID)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@StateID", StateID); 
                param.Add("@Action", "FillDistrict");
                var lstste = await cn.QueryAsync<DDEntity>("SP_DropDown", param, commandType: CommandType.StoredProcedure);
                return lstste.ToList();
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<int> Insert(DDEntity DD)
        {
            try
            {
                var cn = CreateConnection();
                if (cn.State == ConnectionState.Closed) cn.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@CountryID", DD.CountryID);
                param.Add("@StateID", DD.StateID);
                param.Add("@DistrictID", DD.DistrictID);
                param.Add("@Action", "Insert");
                int x = await cn.ExecuteAsync("SP_DropDown", param, commandType: CommandType.StoredProcedure);
                cn.Close();
                return x;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }
}
