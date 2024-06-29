using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class ValuesController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        var userInfo = new
        {
            Name = "William",
            Section = "32E3",
            Course = "BSIT",
            FunFacts = new[]
            {
                "I love Gaming",
                "I enjoy swimming.",
                "My favorite color is black.",
            }
        };
        return Ok(userInfo);
    }
}

