using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class UsersServices : IUsersServices
    {
        private readonly DevFreelaDbContext _dbContext;

        public UsersServices(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public int Create(UsersViewModel inputModel)
        {
            var users = new User(inputModel.FullName, inputModel.Email, inputModel.BirthDate);
            _dbContext.Users.Add(users);
            return users.Id;

        }

        public void Delete(int Id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == Id);
            user.Active = false;
        }

        public List<UsersViewModel> GetAll()
        {
            var user = _dbContext.Users;
            var users = user.Select(u => new UsersViewModel(u.FullName, u.Email, u.BirthDate)).ToList();
            return users;
        }

        public UsersViewModel GetById(int id)
        {
            var user = _dbContext.Users.SingleOrDefault(u => u.Id == id);
            var userDetails = new UsersViewModel(user.FullName, user.Email, user.BirthDate);
            return userDetails;
        }

        public UsersViewModel GetByName(string name)
        {
            var user = _dbContext.Users.FirstOrDefault(p => p.FullName.Equals(name));
            var userDetails = new UsersViewModel(user.FullName, user.Email, user.BirthDate);
            return userDetails;
        }
    }
}
