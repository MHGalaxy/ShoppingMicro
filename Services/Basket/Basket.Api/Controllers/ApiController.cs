using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.Controllers;

[ApiController]
[ApiVersion("1.0")]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class ApiController : ControllerBase;
