using Newtonsoft.Json;

namespace CapitalPlacement;

public class EmployerProgram
{
    [JsonProperty("id")]
    public string Id { get; set; }
    [JsonProperty("title")]
    public string? Title { get; set; }
    [JsonProperty("description")]
    public string? Description { get; set; }
    [JsonProperty("createdAt")]
    public string CreatedAt { get; set; } = DateTime.Now.ToString();
    [JsonProperty("personInformationQuestion")]
    public PersonInformationQuestion PersonDetailQuestions { get; set; } = new PersonInformationQuestion();
    [JsonProperty("additonalQuestions")]
    public List<Question> AdditonalQuestions { get; set; } = [];
}
