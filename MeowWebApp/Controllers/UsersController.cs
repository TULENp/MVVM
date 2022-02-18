using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using UsersLibrary;

namespace MeowWebApp.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        [HttpGet("GetUsers")]
        public List<User> GetUserList() => new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "firstpresident@ussr.ru",
                FirstName = "Boris",
                LastName = "Yeltsin",
                Avatar = new Uri("https://cs8.pikabu.ru/images/previews_comm/2016-11_6/1480513989132867198.jpg")
            },
            new User()
            {
                Id = 1,
                Email = "tobias.funke@reqres.in",
                FirstName = "Tobias",
                LastName = "Funke",
                Avatar = new Uri("https://reqres.in/img/faces/7-image.jpg")
            },new User()
            {
                Id = 1,
                Email = "byron.fields@reqres.in",
                FirstName = "Byron",
                LastName = "Fields",
                Avatar = new Uri("https://reqres.in/img/faces/9-image.jpg")
            },
        };
    }
}