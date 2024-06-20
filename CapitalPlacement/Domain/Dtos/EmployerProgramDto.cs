namespace CapitalPlacement;

public class EmployerProgramDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public PersonInformationQuestionDto PersonDetailQuestions { get; set; } = new PersonInformationQuestionDto();
    public List<QuestionDto> AdditonalQuestions { get; set; } = [];
}

public class PersonInformationQuestionDto
{
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public OptionalField Email { get; set; } 
    public OptionalField Phone { get; set; } 
    public OptionalField Nationality { get; set; } 
    public OptionalField CurrnentResidence { get; set; } 
    public OptionalField IDNumber { get; set; } 
    public OptionalField DateOfBirth { get; set; } 
    public OptionalField Gender { get; set; } 
}

public class QuestionDto
{
    public string? Text { get; set; }
    public QuestionType Type { get; set; }
    public List<string> Options { get; set; } = [];
    public List<string>? Answer { get; set; }
}