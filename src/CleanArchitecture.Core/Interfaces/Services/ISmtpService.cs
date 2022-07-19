using System.Threading.Tasks;
using CleanArchitecture.Core.Entities;

namespace CleanArchitecture.Core.Interfaces.Services
{
    public interface ISmtpService
    {
        Task SendAsync(Mail mail);
    }
}

