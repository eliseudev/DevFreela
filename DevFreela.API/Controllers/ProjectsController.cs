using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComent;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectServices _projectServices;
        private readonly IMediator _mediator;

        public ProjectsController(IProjectServices projectServices, IMediator mediator)
        {
            _projectServices = projectServices;
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get(string query)
        {
            var project = _projectServices.GetAll(query);
            return Ok(project);
        }

        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            var project = _projectServices.GetById(Id);
            return Ok(project);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if (command.Title.Length > 50)
            {
                return BadRequest("O Titulo não pode conter mais de 50 caracteres");
            }
            //var id = _projectServices.Create(inputModel);
            var id = await _mediator.Send(command);
            return AcceptedAtAction(nameof(GetById), new { Id = id }, command);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody] UpdateProjectInputModel model)
        {
            if (model.Description.Length > 200)
            {
                return BadRequest();
            }
            _projectServices.Update(model);
            return NoContent();
        }

        //api/projects/
        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(int Id)
        {
            var command = new DeleteProjectCommand(Id);
            await _mediator.Send(command);
            return NoContent();
        }

        //api/projects/1/comments
        [HttpPost("{Id}/comments")]
        public async Task<IActionResult> PostComent(int Id, [FromBody] CreateComentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        //api/projects/1/start
        [HttpPut("{Id}/start")]
        public IActionResult Start(int Id)
        {
            _projectServices.Start(Id);
            return NoContent();
        }

        //api/projects/1/finish
        [HttpPut("{Id}/finish")]
        public IActionResult Finish(int Id)
        {
            _projectServices.Finish(Id);
            return NoContent();
        }

    }
}
