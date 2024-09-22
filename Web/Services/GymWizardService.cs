using Web.Interfaces;

namespace Web.Services
{
    public class GymWizardService(IOpenAIService openAIService) : IGymWizardService
    {
        public async Task<string> FindMachineAsync(Stream imageStream)
        {
            string machineFinderPrompt = """   
            What gym machine or  gym equipment or gym device is this and what be used for ?
            What muscles that the gym machine help improve ?
            What advise can you provide to effectively use this machine ?
            If the machine is not a gym machine or gym equipment or gym device simply return: False
            If the machine is a gym machine or gym equipment or gym device,
            the answer should be structured as html, return only the body content 
            """;

            if (imageStream == null) return null;

            var chatCompletion = await openAIService.GetChatCompletionAsync(machineFinderPrompt, imageStream);

            if (chatCompletion == null || chatCompletion.Content[0].Text == "False") return "False";

            return chatCompletion.Content[0].Text;
        }

        public async Task<string> GenerateWorkoutSession(string userPreference)
        {
            string generateWorkoutPrompt = """
            Generate a gym work out for this scenario:
            {0}
            If you can not generate a workout session simply return: False
            If you can generate a work session, 
            the answer should be structured as html, return only the body content 
            """;

            var prompt = string.Format(generateWorkoutPrompt, userPreference);

            var chatCompletion = await openAIService.GetChatCompletionAsync(prompt);

            if (chatCompletion == null || chatCompletion.Content[0].Text == "False") return "False";

            return chatCompletion.Content[0].Text;
        }

        public async Task<string> GenerateMealPlan(string userPreference)
        {
            string generateMealPlanPrompt = """
            {0}
            If you can not generate a workout session simply return: False
            If you can generate a work session, 
            the answer should be structured as html, return only the body content 
            """;

            var prompt = string.Format(generateMealPlanPrompt, userPreference);

            var chatCompletion = await openAIService.GetChatCompletionAsync(prompt);

            if (chatCompletion == null || chatCompletion.Content[0].Text == "False") return "False";

            return chatCompletion.Content[0].Text;
        }
    }
}
