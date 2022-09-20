using Dapper;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Core.Entities;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
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
        private string _connectionString;
        public ProjectServices(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _connectionString = configuration.GetConnectionString("DevFreelaCs");
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
            var project = _dbContext.Projects
                .Include(p => p.Cliente)
                .Include(p => p.Freelancer)
                .SingleOrDefault(p => p.Id == Id);

            var projectDetalilsViewModel = new ProjectDetailsViewModel(
                project.Id,
                project.Title,
                project.Description,
                project.TotalCost,
                project.StartdAt,
                project.FinishedAt,
                project.Cliente.FullName,
                project.Freelancer.FullName
                );

            return projectDetalilsViewModel;
        }

        public void Start(int Id)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == Id);
            project.Start();
            //_dbContext.SaveChanges();

            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var sql = "UPDATE Project SET = Status = @status, StartedAt = @startedat where Id = @id";
                sqlConnection.Execute(sql, new { status = project.Status, startedat = project.StartdAt, id = Id });
            }
        }

        public void Update(UpdateProjectInputModel updateModel)
        {
            var project = _dbContext.Projects.SingleOrDefault(p => p.Id == updateModel.Id);
            project.Update(project.Title, project.Description, project.TotalCost);
            _dbContext.SaveChanges();
        }
    }
}
