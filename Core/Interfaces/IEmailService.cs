using Core.Entities;

namespace Core.Interfaces
{
    public interface IEmailService
    {    
        string EmailFromUsers(EmailUserData userData);
    }
}