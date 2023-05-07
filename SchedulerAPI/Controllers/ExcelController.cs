using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.EntityFrameworkCore;
using ProjectManagerAPI.Models;

namespace ProjectManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExcelController : ControllerBase
    {
        private readonly SchedulerContext _context;
        public ExcelController(SchedulerContext context) 
        { 
            _context = context;
        }
        //Excel экспорт
        [HttpGet]
        [Route("~/UserExcelExport")]

        public async Task<IActionResult> ExportToExcel()
        {
            var users = await _context.Users.ToListAsync();

            string templatepath = Path.Combine(Directory.GetCurrentDirectory(), "ExcelTemplate//UserReport.html");
            string htmldata = System.IO.File.ReadAllText(templatepath);

            string excelstring = "";

            foreach (User user in users)
            {
                excelstring += "<tr><td>" + user.Usersurname + "</td><td>" + user.Username +
                    "</td><td>" + user.Userpatronymic + "</td><td>" + user.Useremail +
                    "</td><td>" + user.Roleid + "</td></tr>";
            }

            htmldata = htmldata.Replace("@@ActualData", excelstring);

            string StoredFilePath = "ExcelFiles//users.xls";
            System.IO.File.AppendAllText(StoredFilePath, htmldata);

            var provider = new FileExtensionContentTypeProvider();

            if (!provider.TryGetContentType(StoredFilePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }

            var bytes = await System.IO.File.ReadAllBytesAsync(StoredFilePath);

            return File(bytes, contentType, Path.Combine(StoredFilePath));




        }
    }
}
