namespace Web.Interfaces
{
    public interface IGymWizardService
    {
        Task<string> FindMachineAsync(Stream imageStream);
        Task<string> GenerateWorkoutSession(string userPreference);
        Task<string> GenerateMealPlan(string userPreference);
    }
}
