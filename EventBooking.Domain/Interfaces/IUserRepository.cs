using EventBooking.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Interfaces
{
    public interface IUserRepository
    {
        public void Create(User usuario);
        void Delete(int id);
        User Update(User usuario);
        User GetUserById(int id);
    }
}
