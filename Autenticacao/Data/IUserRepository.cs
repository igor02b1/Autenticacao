using Autenticacao.Models;

namespace Autenticacao.Data
{
    public interface IUserRepository
    {
        User Create(User user);
    }
}
