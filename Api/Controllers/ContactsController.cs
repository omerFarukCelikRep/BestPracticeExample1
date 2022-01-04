using Api.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IContactService _contactService;

        public ContactsController(IConfiguration configuration, IContactService contactService)
        {
            _configuration = configuration;
            _contactService = contactService;
        }

        [HttpGet]
        public string Get()
        {
            return _configuration["ReadMe"].ToString();
        }

        [ResponseCache(Duration = 10)]
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return _contactService.GetContactById(id);
        }

        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contact)
        {
            //Create Contact on DB

            return contact;
        }
    }
}
