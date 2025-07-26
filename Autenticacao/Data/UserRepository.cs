using Autenticacao.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace Autenticacao.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly UserContext _context;
        public UserRepository(UserContext context)
        {
            _context = context;
        }
        public User Create(User user)
        {

            if (_context.Users.Any(u => u.Email == user.Email))
            {
                throw new InvalidOperationException("E-mail já cadastrado.");
            }

            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
        
        public User GetByEmail(string email)
        {
            return _context.Users.FirstOrDefault(u => u.Email == email);
        }
    }
}
