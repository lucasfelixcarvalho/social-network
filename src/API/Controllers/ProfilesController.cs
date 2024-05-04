using Application.InputModels;
using Application.OutputModels;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController(IProfileService service) : ControllerBase
{
    private readonly IProfileService _service = service;

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateProfileInputModel model)
    {
        ResultOutputModel result = _service.Update(id, model);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }

    [HttpGet("{id}")]
    public IActionResult Get(int id)
    {
        ResultOutputModel<ProfileDetailsOutputModel?> result = _service.GetProfileById(id);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpGet]
    public IActionResult GetByLocation(string city, string country)
    {
        ResultOutputModel<List<ProfileListOutputModel>> result = _service.GetProfilesByLocation(new LocationInputModel(city, country));

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut("{id}/inactivate")]
    public IActionResult Inactivate(int id)
    {
        ResultOutputModel result = _service.Inactivate(id);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }
}
