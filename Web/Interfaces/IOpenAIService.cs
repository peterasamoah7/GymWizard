using OpenAI.Chat;

namespace Web.Interfaces
{
    public interface IOpenAIService
    {
        Task<ChatCompletion> GetChatCompletionAsync(string prompt, Stream imageStream = null);
    }
}
