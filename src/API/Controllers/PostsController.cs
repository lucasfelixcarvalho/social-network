using Application.InputModels;
using Application.OutputModels;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostsController(IPostService service) : ControllerBase
{
    private readonly IPostService _service = service;

    [HttpPost]
    public IActionResult Post(CreatePostInputModel model)
    {
        ResultOutputModel<int> result = _service.Insert(model);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        ResultOutputModel result = _service.Delete(id);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }

    [HttpPut("{id}")]
    public IActionResult Post(int id, UpdatePostInputModel model)
    {
        ResultOutputModel result = _service.Update(id, model);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        ResultOutputModel<PostDetailsOutputModel> result = _service.GetByid(id);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
