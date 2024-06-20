using AutoMapper;

namespace CapitalPlacement;


public class ProgramMappings : Profile
{
    public ProgramMappings()
    {
        CreateMap<EmployerProgram, EmployerProgramDto>()
            .ReverseMap()
            .AfterMap((dto, model) =>
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                }
            });

        CreateMap<PersonInformationQuestion, PersonInformationQuestionDto>()
            .ReverseMap()
            .AfterMap((dto, model) =>
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                }
            });

        CreateMap<Question, QuestionDto>()
            .ReverseMap()
            .AfterMap((dto, model) =>
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                }
            });

        CreateMap<OptionalField, OptionalField>()
            .ReverseMap();
    }
}
