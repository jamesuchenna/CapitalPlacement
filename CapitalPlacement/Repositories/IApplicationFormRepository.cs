namespace CapitalPlacement;

public interface IApplicationFormRepository
{
    Task<ApplicationForm> CreateApplication(ApplicationFormDto dto);
}
