using AutoMapper;
using Microsoft.Azure.Cosmos;

namespace CapitalPlacement;
public class ApplicationFormRepository : IApplicationFormRepository
{
    private readonly IProgramRepository _programRepository;
    private readonly Container _applicationFormContainer;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

public ApplicationFormRepository(CosmosClient cosmosClient, IConfiguration configuration, IMapper mapper, IProgramRepository programRepository)
{
    _configuration = configuration;
    _programRepository = programRepository;
    var databaseName = _configuration["CosmosDbSettings:DatabaseName"];
    var programContainerName = "ApplicationForms";
    _applicationFormContainer = cosmosClient.GetContainer(databaseName, programContainerName);
    _mapper = mapper;
}

public async Task<ApplicationForm> CreateApplication(ApplicationFormDto dto)
{
    var program = await _programRepository.GetProgramAsync(dto.ProgramId)
        ?? throw new HttpResponseException(404, $"Program with ID '{dto.ProgramId}' not found.");

    var additionalQuestions = dto.AdditonalQuestions
        .Select(dtoQuestion => 
        {
            var programQuestion = program.AdditonalQuestions.FirstOrDefault(q => q.Id == dtoQuestion.Id);
            if (programQuestion != null)
            {
                _mapper.Map(dtoQuestion, programQuestion);
                return programQuestion;
            }
            return null;
        })
        .Where(q => q != null)
        .ToList();

    var personDetailQuestions = _mapper.Map<PersonInformationQuestion>(dto.PersonDetailQuestions);

    var applicationForm = _mapper.Map<ApplicationForm>(dto);
    applicationForm.ProgramId = dto.ProgramId;
    applicationForm.AdditonalQuestions = additionalQuestions;
    applicationForm.PersonDetailQuestions = personDetailQuestions;

    var response = await _applicationFormContainer.CreateItemAsync(applicationForm);
    return response.Resource;
}
}
