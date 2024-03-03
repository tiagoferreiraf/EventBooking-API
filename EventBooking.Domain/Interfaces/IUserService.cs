using EventBooking.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBooking.Domain.Interfaces
{
    public interface IUserService
    {
        public Task<UserModel> Add(UserModel usuario);
        public void Delete(int id);
        public Task<UserModel> Update(UserModel usuario);
    }
}
