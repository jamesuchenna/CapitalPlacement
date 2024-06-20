namespace CapitalPlacement;
using Newtonsoft.Json;
using System.Collections.Generic;

public class PersonInformationQuestion
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("firstName")]
    public string FirstName { get; set; }
    
    [JsonProperty("lastName")]
    public string LastName { get; set; }
    
    [JsonProperty("email")]
    public OptionalField Email { get; set; }
    
    [JsonProperty("phone")]
    public OptionalField Phone { get; set; }
    
    [JsonProperty("nationality")]
    public OptionalField Nationality { get; set; }
    
    [JsonProperty("currentResidence")]
    public OptionalField CurrentResidence { get; set; }
    
    [JsonProperty("idNumber")]
    public OptionalField IDNumber { get; set; }
    
    [JsonProperty("dateOfBirth")]
    public OptionalField DateOfBirth { get; set; }
    
    [JsonProperty("gender")]
    public OptionalField Gender { get; set; }
}

public class OptionalField
{
    [JsonProperty("data")]
    public string? Data { get; set; }
    
    [JsonProperty("isInternal")]
    public bool IsInternal { get; set; }
    
    [JsonProperty("isHide")]
    public bool IsHide { get; set; }
}

public class Question
{
    [JsonProperty("id")]
    public string Id { get; set; }
    
    [JsonProperty("text")]
    public string? Text { get; set; }
    
    [JsonProperty("type")]
    public int? Type { get; set; }
    
    [JsonProperty("options")]
    public List<string> Options { get; set; } = new List<string>();
    
    [JsonProperty("answer")]
    public List<string>? Answer { get; set; }
}
