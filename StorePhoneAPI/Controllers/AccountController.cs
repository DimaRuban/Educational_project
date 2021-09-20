using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Contracts;
using System.Collections.Generic;

namespace StorePhoneAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")] 
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }

        [HttpGet("GetUsers")]

        public IEnumerable<User> GetUsers()
        {
            return _accountService.GetUsers();
        }

        [HttpPost("Register")]
        public IActionResult Register(User user)
        {
            _accountService.Register(user);
            return Ok();
        }
    }
}