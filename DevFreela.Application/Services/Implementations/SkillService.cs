using Dapper;
using DevFreela.Application.Services.Interfaces;
using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistence;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Implementations
{
    public class SkillService : ISkillServices
    {

        private readonly DevFreelaDbContext _dbContext;
        private string _stringConnection;

        public SkillService(DevFreelaDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _stringConnection = configuration.GetConnectionString("DevFreelaCs");
        }

        public List<SkillViewModel> GetAll()
        {
            using(var sqlConnection = new SqlConnection(_stringConnection))
            {
                var sql = "SELECT Id, Description FROM Skills";
                return sqlConnection.Query<SkillViewModel>(sql).ToList();
            }
            //var skills = _dbContext.Skills;
            //var skillViewModel = skills.Select(s => new SkillViewModel()).ToList();
            //return skillViewModel;
        }
    }
}
