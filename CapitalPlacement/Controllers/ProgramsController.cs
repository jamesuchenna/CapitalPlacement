﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CapitalPlacement.Controllers;

[ApiController]
[Route("api/programs")]
public class ProgramsController : ControllerBase
{
    private readonly IProgramRepository _programRepository;

    public ProgramsController(IProgramRepository programRepository)
    {
        _programRepository = programRepository;
    }

    [HttpPost]
    public async Task<IActionResult> CreateProgram([FromBody] EmployerProgramDto employerProgram)
    {
        var program = await _programRepository.CreateProgramAsync(employerProgram);
        return Ok(program);
    }

    [HttpGet("{programId}")]
    public async Task<IActionResult> GetProgram(string programId)
    {
        var program = await _programRepository.GetProgramAsync(programId);
        return Ok(program);
    }

    [HttpPut("{programId}/questions/{questionId}")]
    public async Task<IActionResult> UpdateQuestion([FromBody] QuestionDto employerProgram, string programId, string questionId)
    {
        var program = await _programRepository.UpdateQuestionAsync(employerProgram, programId, questionId);
        return Ok(program);
    }
}

