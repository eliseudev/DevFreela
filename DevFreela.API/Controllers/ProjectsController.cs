using DevFreela.API.Models;
using DevFreela.Application.InputModel;
using DevFreela.Application.Services.Implementations;
using DevFreela.Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DevFreela.API.Controllers
{
    [Route("api/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly IProjectServices _projectServices;

        public ProjectsController(IProjectServices projectServices)
        {
            _projectServices = projectServices;
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
        public IActionResult Post([FromBody] NewProjectInputModel inputModel)
        {
            if(inputModel.Title.Length > 50)
            {
                return BadRequest();
            }
            var id = _projectServices.Create(inputModel);
            return AcceptedAtAction(nameof(GetById), new { Id = id }, inputModel);
        }

        [HttpPut("{Id}")]
        public IActionResult Put(int Id, [FromBody]UpdateProjectInputModel model)
        {
            if(model.Description.Length > 200)
            {
                return BadRequest();
            }
            _projectServices.Update(model);
            return NoContent();
        }

        //api/projects/
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            _projectServices.Delete(Id);
            return NoContent();
        }

        //api/projects/1/comments
        [HttpPost("{Id}/comments")]
        public IActionResult PostComent(int Id, [FromBody] CreateCommentInputModel model)
        {
            _projectServices.CreateComment(model);
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
