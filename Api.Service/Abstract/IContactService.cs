using Models;

namespace Api.Service.Abstract
{
    public interface IContactService
    {
        public ContactDVO GetContactById(int id);
    }
}
