using DevFreela.Application.InputModel;
using DevFreela.Application.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectServices
    {
        List<ProjectViewModel> GetAll(string query);
        ProjectDetailsViewModel GetById(int Id);
        void Delete(int Id);
        void Finish(int Id);
    }
}
