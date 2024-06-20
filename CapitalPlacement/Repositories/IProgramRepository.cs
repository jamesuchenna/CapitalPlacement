namespace CapitalPlacement;

public interface IProgramRepository
{
    Task<EmployerProgram> CreateProgramAsync(EmployerProgramDto dto);
    Task<EmployerProgram> GetProgramAsync(string programId);
    Task<EmployerProgram> UpdateQuestionAsync(QuestionDto dto, string programId, string questionId);
}

