using ExampleWebApplication.Models.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace ExampleWebApplication.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ExampleController : ControllerBase
{
    [HttpPost]
    public Task<IActionResult> Post([FromBody] Pokemon pokemon)
    {
        return ModelState.IsValid ? Task.FromResult<IActionResult>(BadRequest(ModelState)) : Task.FromResult<IActionResult>(Ok(pokemon));
    }
}