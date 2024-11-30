using ExtensionsAI.Chat.Sample;
using Microsoft.Extensions.AI;
using System.Text;

public class Program
{
    public static async Task Main(string[] args)
    {
        Utils.Header();

        // get the OLLAMA model name
        string ollamaModelId =
                    Utils.TextPrompt("Enter your Ollama model name:");
        //ollama url
        var ollamaUrl = "http://localhost:11434/";


        // create the ollama chat client
        IChatClient chatClient = new OllamaChatClient(
             new Uri(ollamaUrl), ollamaModelId);

        //history of chat messages
        List<ChatMessage> conversation = [];


        // Adds a system message to the chat messages list. 
        // This is typically used to set the initial context or instructions for the chat.
        // string context =
        //  ConsoleUtils.TextPrompt("If you want enter your context:( instruct or set the behavior of the assistant)");
        //  conversation.Add(new ChatMessage(ChatRole.System, context));


        while (true)
        {
            // get the user message
            string userMessage = Utils.TextPrompt("Enter your message:");

            // add the user message to the chat messages
            conversation.Add(new ChatMessage(ChatRole.User, userMessage));

            Console.WriteLine();
            Console.WriteLine("Assistant:");


            // send the chat messages to the model and get response messages
            try
            {
                //asynchronously streams the completion of the chat messages using the chat client.

                StringBuilder response = new();
                await foreach (var update in chatClient.CompleteStreamingAsync(conversation).ConfigureAwait(false))
                {
                    response.Append(update);
                    Console.Write(update);
                }
                conversation.Add(new ChatMessage(ChatRole.Assistant, response.ToString()));
                // send the chat messages without streaming (user message and chat history) to the model 
                //var response = await chatClient.CompleteAsync(conversation);
                //Console.Write(response.Message.Text);
                //conversation.Add(new ChatMessage(ChatRole.Assistant, response.Message.Text));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
                Utils.ErrorMessage($"{ex.Message}");
            }

            Console.WriteLine();

        }
    }
}