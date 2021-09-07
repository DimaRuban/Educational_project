using EF_Store.Domain;
using Microsoft.AspNetCore.Mvc;
using StorePhone.Сontracts;
using System.Collections.Generic;

namespace StorePhoneAPI.Controllers
{
    [ApiController]
    [Route("[controller]")] 
    public class AccountController : ControllerBase
    {
        private readonly IAccountService _accountService;

        public AccountController(IAccountService accountService)
        {
            _accountService = accountService;
        }
        // GET: api/<AccountController>
        [HttpGet]
        public IEnumerable<User> GetUsers()
        {
            return _accountService.GetUsers();
        }

        [HttpPost]
        public void Register(User user)
        {
            _accountService.Register(user);
        }
    }
}