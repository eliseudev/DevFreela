using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Dapper;
using DevFreela.Application.ViewModel;
using DevFreela.Infrastructure.Persistence;
using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkilsQueryHandler : IRequestHandler<GetAllSkilsQuery, List<SkillViewModel>>
    {
        private string _stringConnection;

        public GetAllSkilsQueryHandler(IConfiguration configuration)
        {
            _stringConnection = configuration.GetConnectionString("DevFreelaCs");
        }

        public async Task<List<SkillViewModel>> Handle(GetAllSkilsQuery request, CancellationToken cancellationToken)
        {
            using (var sqlConnection = new SqlConnection(_stringConnection))
            {
                sqlConnection.Open();
                var sql = "SELECT Id, Description FROM Skills";
                var skills =  await sqlConnection.QueryAsync<SkillViewModel>(sql);
                return skills.ToList();
            }
        }
    }
}

