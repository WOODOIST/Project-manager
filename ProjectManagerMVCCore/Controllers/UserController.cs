using AutoMapper;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ProjectManagerAPI.DtoObjects.Outgoing;
using ProjectManagerAPI.Models;
using System.Text;

namespace ProjectManagerMVCCore.Controllers
{
    public class UserController : Controller
    {
        



        public async Task<IActionResult> GetUsers()
        {

            List<User>? users = new List<User>();
            
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(GlobalApiURL.BaseURL);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("GetAllUsers");

                if (Res.IsSuccessStatusCode)
                {
                    var Result =  Res.Content.ReadAsStringAsync().Result;
                    users = JsonConvert.DeserializeObject<List<User>>(Result);
                }
            }
            return View(users);
        }

        public IActionResult ExportToCSV()
        {
            
            List<User>? users = new List<User>();
            var builder = new StringBuilder();
            builder.AppendLine("Usersurname,Username,Userpatronymic,Useremail,Roleid");
            foreach(var user in users)
            {
                builder.AppendLine($"{user.Usersurname},{user.Username},{user.Userpatronymic},{user.Useremail},{user.Roleid}");
            }
            return File(Encoding.UTF8.GetBytes(builder.ToString()), "text/csv", "users.csv");
        }

        public IActionResult ExportToExcel()
        {
            List<User>? users = new List<User>();
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Users");
                var currentRow = 1;

                worksheet.Cell(currentRow, 1).Value= "Usersurname";
                worksheet.Cell(currentRow, 2).Value = "Username";
                worksheet.Cell(currentRow, 3).Value = "Userpatronymic";
                worksheet.Cell(currentRow, 4).Value = "Useremail";
                worksheet.Cell(currentRow, 5).Value = "Roleid";

                foreach(var user in users)
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = user.Usersurname;
                    worksheet.Cell(currentRow, 2).Value = user.Username;
                    worksheet.Cell(currentRow, 3).Value = user.Userpatronymic;
                    worksheet.Cell(currentRow, 4).Value = user.Useremail;
                    worksheet.Cell(currentRow, 5).Value = user.Roleid;

                }
                using(var stream=new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd-openxmlformats-officedocument.spreadsheetml.sheet", "users.xlsx");
                }

            }
        }
    }
}
