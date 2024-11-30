# Simple Chat Application Using Ollama AI Model and .NET
This project demonstrates a console-based chat application that interacts with an Ollama AI model. Users can send messages to the AI assistant and receive responses in a conversational format.

## Prerequisites

Ollama AI: Install and configure the Ollama AI service locally. It should be running at the default URL: http://localhost:11434/.
and pull models (you can see some models in [Ollama](https://ollama.com/library) )

## Code Overview
Chat Client: An instance of OllamaChatClient from [Microsoft.Extensions.AI](https://www.nuget.org/packages/Microsoft.Extensions.AI) interacts with the AI model.

Conversation History: A List<ChatMessage> keeps track of the messages exchanged between the user and the assistant.

Streaming Responses: The CompleteStreamingAsync method streams the AI's responses in real-time.

``` chatClient.CompleteStreamingAsync(conversation) ```

Alternatively, you can use CompleteAsync for non-streaming responses:

```chatClient.CompleteAsync(conversation) ```

Customization: You can customize the AI assistant's behavior by adding a system message to the conversation. Uncomment and modify the following section in the code:

 ``` string context = conversation.Add(new ChatMessage(ChatRole.System, "instruct or set the behavior of the assistant")); ```
