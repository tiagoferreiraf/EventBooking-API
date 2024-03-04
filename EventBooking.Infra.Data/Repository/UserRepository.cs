using EventBooking.Domain.Entities;
using EventBooking.Domain.Interfaces;
using EventBooking.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Infra.Data.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _dbContext;

        public UserRepository(ApplicationContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(User user)
        {
            try
            {
                _dbContext.User.Add(user);
                _dbContext.SaveChanges();
            }
            catch (Exception)
            {
                throw new("Ocorreu um problema ao tentar inserir o Usuário");
            }
            
        }
    }
}
