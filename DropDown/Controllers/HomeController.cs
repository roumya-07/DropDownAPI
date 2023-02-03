using DropDown.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DropDown.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebHostEnvironment _environment;
        Uri baseAdd = new Uri("http://localhost:18677/api");

        HttpClient client;
        public HomeController(IWebHostEnvironment environment)
        {
            _environment = environment;
            client = new HttpClient();
            client.BaseAddress = baseAdd;
        }

        public async Task<IActionResult> Index()
        {
            return View();
        }
        public async Task<JsonResult> GetCountry()
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/Country/").Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }
        public async Task<JsonResult> GetState(int CountryID)
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/State/" + CountryID).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }

        public async Task<JsonResult> GetDistrict(int StateId)
        {
            string data = null;
            HttpResponseMessage response = client.GetAsync(client.BaseAddress + "/District/" + StateId).Result;
            if (response.IsSuccessStatusCode)
            {
                data = response.Content.ReadAsStringAsync().Result;
            }
            return Json(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(DDEntity DD)
        {
            string data = JsonConvert.SerializeObject(DD);
            HttpResponseMessage response;
            StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
            response = client.PutAsync(client.BaseAddress + "/DropDown/" , content).Result;
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
