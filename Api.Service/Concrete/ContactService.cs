using Api.Data.Models;
using Api.Service.Abstract;
using AutoMapper;
using Models;
using System.Net.Http;

namespace Api.Service.Concrete
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactService(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }
        private Contact GetDummyContact()
        {
            return new Contact()
            {
                Id = 1,
                FirstName = "Ömer Faruk",
                LastName = "Çelik"
            };
        }

        public ContactDVO GetContactById(int id)
        {
            //Get the record from db

            Contact dbContact = GetDummyContact();

            var client = _httpClientFactory.CreateClient("garantiapi");

            //ContactDVO resultContact = new();

            //_mapper.Map(dbContact, resultContact);

            ContactDVO resultContact = _mapper.Map<ContactDVO>(dbContact);

            return new ContactDVO()
            {
                Id = dbContact.Id,
                FullName = $"{dbContact.FirstName} {dbContact.LastName}"
            };
        }
    }
}
