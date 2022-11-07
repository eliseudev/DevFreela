using System;
using System.Collections.Generic;
using DevFreela.Application.ViewModel;
using MediatR;

namespace DevFreela.Application.Queries.GetAllSkills
{
    public class GetAllSkilsQuery : IRequest<List<SkillViewModel>>
    {
        
    }
}

