using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using DotNetCoreCommandLineSnippets.API.Models;
using DotNetCoreCommandLineSnippets.API.Services;

namespace DotNetCoreCommandLineSnippets.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandAPIService _repository;
        private readonly IMapper _mapper;
        public CommandsController(ICommandAPIService repository,IMapper mapper)
        {
            _repository = repository;
            _mapper=mapper;
        }

        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable<CommandReadDto>>(commandItems));
        }

        [HttpGet("{id}")]
        public ActionResult<CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if (commandItem == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CommandReadDto>(commandItem));
        }
    }
}