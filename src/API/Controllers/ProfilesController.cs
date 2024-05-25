using Application.InputModels;
using Application.OutputModels;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController(IProfileService service, IPostService postService) : ControllerBase
{
    private readonly IProfileService _service = service;
    private readonly IPostService _postService = postService;

    [HttpPut("{id}")]
    [Authorize(Roles = "user")]
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
    [AllowAnonymous]
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
    [Authorize(Roles = "user")]
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
    [Authorize(Roles = "user")]
    public IActionResult Inactivate(int id)
    {
        ResultOutputModel result = _service.Inactivate(id);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }

    [HttpGet("{id}/posts")]
    [AllowAnonymous]
    public IActionResult GetPostsByProfileId(int id)
    {
        ResultOutputModel<List<PostListOutputModel>> result = _postService.GetByProfileId(id);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

}
