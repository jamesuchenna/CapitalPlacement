using AutoMapper;
using Microsoft.Azure.Cosmos;
using Microsoft.Azure.Cosmos.Linq;


namespace CapitalPlacement;
public class ProgramRepository : IProgramRepository
{
        private readonly Container _programContainer;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;

        public ProgramRepository(CosmosClient cosmosClient, IConfiguration configuration, IMapper mapper)
        {
            _configuration = configuration;
            var databaseName = _configuration["CosmosDbSettings:DatabaseName"];
            var programContainerName = "EmployerPrograms";
            _programContainer = cosmosClient.GetContainer(databaseName, programContainerName);
            _mapper = mapper;
        }

        public async Task<EmployerProgram> CreateProgramAsync(EmployerProgramDto dto)
        {
        var employerProgram = _mapper.Map<EmployerProgram>(dto);

        var response = await _programContainer.CreateItemAsync(employerProgram);
            return response.Resource;
        }

    public async Task<EmployerProgram> GetProgramAsync(string programId)
{
    var query = await _programContainer.GetItemLinqQueryable<EmployerProgram>()
        .Where(t => t.Id == programId)
        .ToFeedIterator().ReadNextAsync();

    var program = query.FirstOrDefault() ?? 
                  throw new HttpResponseException(404, $"Program with ID '{programId}' not found.");
        
        return program;
}


    public async Task<EmployerProgram> UpdateQuestionAsync(QuestionDto dto, string programId, string questionId)
{
    var query = await _programContainer.GetItemLinqQueryable<EmployerProgram>()
        .Where(t => t.Id == programId)
        .ToFeedIterator().ReadNextAsync();

    var program = query.FirstOrDefault() ?? 
                  throw new HttpResponseException(404, $"Program with ID '{programId}' not found.");

        var question = program.AdditonalQuestions.FirstOrDefault(s => s.Id == questionId) ?? 
                       throw new HttpResponseException(404, $"Question with ID '{questionId}' not found in the program '{programId}'.");
        
        _mapper.Map(dto, question);

    await _programContainer.ReplaceItemAsync(program, programId);

    return program;
}

}
