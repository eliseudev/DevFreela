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
        int Create(NewProjectInputModel inputModel);
        void Update(UpdateProjectInputModel updateModel);
        void Delete(int Id);
        void CreateComment(CreateCommentInputModel comentInputModel);
        void Start(int Id);
        void Finish(int Id);
    }
}
