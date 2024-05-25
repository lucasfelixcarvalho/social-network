using Application.InputModels;
using Application.OutputModels;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProfilesController(IProfileService service, IPostService postService, IConnectionService connectionService) : ControllerBase
{
    private readonly IProfileService _service = service;
    private readonly IPostService _postService = postService;
    private readonly IConnectionService _connectionService = connectionService;

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

    [HttpPost("{id}/follow/{id_to_follow}")]
    [Authorize(Roles = "user")]
    public IActionResult Follow(int id, int id_to_follow)
    {
        ResultOutputModel result = _connectionService.Follow(new FollowProfileInputModel(id, id_to_follow));

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }

    [HttpPost("{id}/unfollow/{id_to_unfollow}")]
    [Authorize(Roles = "user")]
    public IActionResult Unfollow(int id, int id_to_unfollow)
    {
        ResultOutputModel result = _connectionService.Unfollow(new UnfollowProfileInputModel(id, id_to_unfollow));

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }
}
