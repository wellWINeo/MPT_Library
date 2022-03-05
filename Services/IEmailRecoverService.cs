using System.Threading.Tasks;

namespace Library.Services;

public interface IEmailRecoverService
{
    Task<bool> Recover(string email);
}