using Microsoft.AspNetCore.Mvc;

namespace Project.Controllers;

public abstract class BaseController : Controller
{
    protected IActionResult HandleResponse<T>(T result)
    {
        if (result == null)
            return NotFound();
        return Ok(result);
    }
}
