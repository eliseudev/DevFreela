using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUsersServices
    {
        List<UsersViewModel> GetAll();
        UsersViewModel GetById(int id);
        UsersViewModel GetByName(string name);
        int Create(UsersViewModel inputModel);
        void Delete(int Id);
    }
}
