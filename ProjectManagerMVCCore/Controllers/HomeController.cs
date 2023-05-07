using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProjectManagerAPI.Models;
using ProjectManagerMVCCore.Models;
using System.Collections.Generic;
using System.Diagnostics;
using ProjectManagerMVCCore;
using static System.Net.WebRequestMethods;

namespace ProjectManagerMVCCore.Controllers
{
    public class HomeController : Controller
    {



        public async Task<IActionResult> GetAllRoles()
        {
            List<Role>? roles = new List<Role>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalApiURL.BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("GetRolesWithId");

                if (Res.IsSuccessStatusCode)
                {
                    var Result = Res.Content.ReadAsStringAsync().Result;
                    roles = JsonConvert.DeserializeObject<List<Role>>(Result);
                }
            }
            return View(roles);

        }


        [HttpGet]
        public async Task<IActionResult> GetRole(string rolename)
        {
            Role? _role = new Role();
            List<Role> roles = new List<Role>();
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalApiURL.BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("GetRoleByName" + rolename);

                if (Res.IsSuccessStatusCode)
                {
                    var Result = Res.Content.ReadAsStringAsync().Result;
                    _role = JsonConvert.DeserializeObject<Role>(Result);
                }
            }
            return View(_role);
        }
    }
}