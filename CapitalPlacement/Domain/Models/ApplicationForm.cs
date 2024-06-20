using Newtonsoft.Json;

namespace CapitalPlacement;

public class ApplicationForm
{
    [JsonProperty("id")]
    public string Id {get; set;} = Guid.NewGuid().ToString();
    [JsonProperty("programId")]
    public string? ProgramId {get; set;}
    [JsonProperty("createdAt")]
    public string CreatedAt { get; set; } = DateTime.Now.ToString();
    [JsonProperty("personInformationQuestions")]
    public PersonInformationQuestion PersonDetailQuestions { get; set; } = new PersonInformationQuestion();
    [JsonProperty("additonalQuestions")]
    public List<Question> AdditonalQuestions { get; set; } = [];
}
