namespace CapitalPlacement;

using AutoMapper;

public class ApplicationFormMappingProfile : Profile
{
    public ApplicationFormMappingProfile()
    {
        CreateMap<ApplicationForm, ApplicationFormDto>()
            .ReverseMap()
            .AfterMap((dto, model) =>
            {
                if (string.IsNullOrEmpty(model.Id))
                {
                    model.Id = Guid.NewGuid().ToString();
                }
            });

        CreateMap<PersonInformationQuestion, PersonInformationQuestionApplicationFormDto>()
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Data))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.Data))
            .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.Phone.Data))
            .ForMember(dest => dest.Nationality, opt => opt.MapFrom(src => src.Nationality.Data))
            .ForMember(dest => dest.CurrnentResidence, opt => opt.MapFrom(src => src.CurrentResidence.Data))
            .ForMember(dest => dest.IDNumber, opt => opt.MapFrom(src => src.IDNumber.Data))
            .ForMember(dest => dest.DateOfBirth, opt => opt.MapFrom(src => src.DateOfBirth.Data))
            .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender.Data))
            .ReverseMap()
            .ForPath(dest => dest.Email.Data, opt => opt.MapFrom(src => src.Email))
            .ForPath(dest => dest.Phone.Data, opt => opt.MapFrom(src => src.Phone))
            .ForPath(dest => dest.Nationality.Data, opt => opt.MapFrom(src => src.Nationality))
            .ForPath(dest => dest.CurrentResidence.Data, opt => opt.MapFrom(src => src.CurrnentResidence))
            .ForPath(dest => dest.IDNumber.Data, opt => opt.MapFrom(src => src.IDNumber))
            .ForPath(dest => dest.DateOfBirth.Data, opt => opt.MapFrom(src => src.DateOfBirth))
            .ForPath(dest => dest.Gender.Data, opt => opt.MapFrom(src => src.Gender))
            .ReverseMap();

        CreateMap<Question, QuestionApplicationFormDto>()
            .ForMember(dest => dest.Answer, opt => opt.MapFrom(src => src.Answer))
            .ReverseMap();
            
        CreateMap<Question, Question>()
            .ReverseMap();
    }
}

