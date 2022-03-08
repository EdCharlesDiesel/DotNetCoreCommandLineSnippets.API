using Microsoft.AspNetCore.Mvc;

namespace DotNetCoreCommandLineSnippets.API.Controllers;

[ApiController]
[Route("[controller]")]
public class CommandsController : ControllerBase
{
    [HttpGet]
    public ActionResult <IEnumerable<string>> Get()
    {
        return new string[] {"this", "is", "hard", "coded"};
    }
}
