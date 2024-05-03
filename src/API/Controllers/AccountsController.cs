using Application.InputModels;
using Application.OutputModels;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AccountsController(IAccountService service) : ControllerBase
{
    private readonly IAccountService _service = service;

    [HttpPost]
    public IActionResult Post(CreateAccountInputModel model)
    {
        ResultOutputModel<int> result = _service.Insert(model);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return CreatedAtAction(nameof(GetById), new { id = result.Data }, model);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(int id)
    {
        ResultOutputModel<AccountDetailsOutputModel?> result = _service.GetById(id);

        if (!result.IsSuccess)
        {
            return NotFound();
        }

        return Ok(result);
    }

    [HttpPut("login")]
    public IActionResult Login(LoginInputModel model)
    {
        ResultOutputModel<LoginOutputModel?> result = _service.Login(model);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }

    [HttpPut("{id}")]
    public IActionResult Update(int id, UpdateAccountInputModel model)
    {
        ResultOutputModel result = _service.Update(id, model);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }

    [HttpPut("{id}/password")]
    public IActionResult UpdatePassword(int id, UpdatePasswordInputModel model)
    {
        ResultOutputModel result = _service.UpdatePassword(id, model);

        if (!result.IsSuccess)
        {
            return BadRequest(result);
        }

        return NoContent();
    }
}
