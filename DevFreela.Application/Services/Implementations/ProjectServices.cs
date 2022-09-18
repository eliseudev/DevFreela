using DevFreela.Application.InputModel;
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
    public class ProjectServices : IProjectServices
    {
        private readonly DevFreelaDbContext _dbContext;
        public ProjectServices(DevFreelaDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public int Create(NewProjectInputModel inputModel)
        {
            var project = new Project(inputModel.Title, inputModel.Description, inputModel.IdCliente, inputModel.IdFreelancer, inputModel.TotalCost);
            _dbContext.Projects.Add(project);
            _dbContext.SaveChanges();
            return project.Id;
        }

        public void CreateComment(CreateCommentInputModel comentInputModel)
        {
            var comment = new ProjectComment(comentInputModel.Content, comentInputModel.IdProject, comentInputModel.IdUser);
            _dbContext.ProjectComments.Add(comment);
            _dbContext.SaveChanges();
        }

        public void Delete(int Id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == Id);
            project.Cancel();
            _dbContext.SaveChanges();
        }

        public void Finish(int Id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == Id);
            project.Finish();
            _dbContext.SaveChanges();
        }

        public List<ProjectViewModel> GetAll(string query)
        {
            var project = _dbContext.Projects;
            var projectsViewModel = project.Select(p => new ProjectViewModel(p.Id, p.Title, p.CreateAt)).ToList();
            return projectsViewModel;
        }

        public ProjectDetailsViewModel GetById(int Id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == Id);
            var projectDetalilsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartdAt,
                project.FinishedAt
                );

            return projectDetalilsViewModel;
        }

        public void Start(int Id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == Id);
            project.Start();
        }

        public void Update(UpdateProjectInputModel updateModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == updateModel.Id);
            project.Update(project.Title, project.Description, project.TotalCost);
            _dbContext.SaveChanges();
        }
    }
}
