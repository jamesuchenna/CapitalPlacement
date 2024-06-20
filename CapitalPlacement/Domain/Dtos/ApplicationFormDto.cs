namespace CapitalPlacement;

public class ApplicationFormDto
{
    public string? ProgramId {get; set;}
    public PersonInformationQuestionApplicationFormDto PersonDetailQuestions { get; set; } = new PersonInformationQuestionApplicationFormDto();
    public List<QuestionApplicationFormDto> AdditonalQuestions { get; set; } = [];
}

public class PersonInformationQuestionApplicationFormDto
{
    public string FirstName { get; set; } 
    public string LastName { get; set; } 
    public string Email { get; set; } 
    public string Phone { get; set; } 
    public string Nationality { get; set; } 
    public string CurrnentResidence { get; set; } 
    public string IDNumber { get; set; } 
    public string DateOfBirth { get; set; } 
    public string Gender { get; set; } 
}

public class QuestionApplicationFormDto
{
    public string? Id {get; set;}
    public List<string>? Answer { get; set; }
}

