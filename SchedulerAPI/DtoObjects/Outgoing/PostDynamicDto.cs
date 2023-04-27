using ProjectManagerAPI.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProjectManagerAPI.DtoObjects.Outgoing
{
    public class PostDynamicDto
    {
        public DateOnly Postdynamicstartdate { get; set; }

        public int Userid { get; set; }

        public int Postid { get; set; }

        
    }
}
