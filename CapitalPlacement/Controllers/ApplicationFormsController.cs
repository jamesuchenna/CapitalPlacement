using Microsoft.AspNetCore.Mvc;

namespace CapitalPlacement.Controllers;

[ApiController]
[Route("api/applicationForms")]
public class ApplicationFormController : ControllerBase
{
    private readonly IApplicationFormRepository _applicationRepository;

    public ApplicationFormController(IApplicationFormRepository applicationRepository)
    {
        _applicationRepository = applicationRepository;
    }

    [HttpPost]
    public async Task<IActionResult> SubmitApplication([FromBody] ApplicationFormDto dto)
    {
        var application = await _applicationRepository.CreateApplication(dto);
        return Ok(application);
    }
}

