using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ConnectionsController(IConnectionService service) : ControllerBase
{


}
