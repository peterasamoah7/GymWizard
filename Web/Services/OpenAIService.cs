using OpenAI.Chat;
using Web.Interfaces;

namespace Web.Services
{
    public class OpenAIService(IConfiguration configuration) : IOpenAIService
    {
        public async Task<ChatCompletion> GetChatCompletionAsync(string prompt, Stream imageStream = null)
            => await GetChatClient().CompleteChatAsync(GetPromptMessages(prompt, imageStream));

        private List<ChatMessage> GetPromptMessages(string prompt, Stream imageStream = null)
        {
            try
            {
                var chatContentParts = new List<ChatMessageContentPart>
                {
                    ChatMessageContentPart.CreateTextMessageContentPart(prompt)
                };

                if (imageStream != null)
                {
                    imageStream.Seek(0, SeekOrigin.Begin);

                    BinaryData imageBytes = BinaryData.FromStream(imageStream);

                    chatContentParts.Add(ChatMessageContentPart.CreateImageMessageContentPart(imageBytes, "image/png"));
                }

                List<ChatMessage> messages =
                [
                    new UserChatMessage(chatContentParts.ToArray())
                ];

                return messages;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return [];
            }
        }

        private ChatClient GetChatClient()
            => new(configuration["GPTModel"]!, configuration["APIKey"]!);
    }
}


