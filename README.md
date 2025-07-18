# AIComply Blazor Chat

This is a blazor component that implements a chat conversation, consuming an IChatClient as defined in [Microsoft.Extensions.ai](https://learn.microsoft.com/en-us/dotnet/ai/ai-extensions).
It is based on the Chat code in [this example](https://devblogs.microsoft.com/dotnet/announcing-dotnet-ai-template-preview1/).
This component can display responses that are plain text, Markdown and Adaptive Cards.

There is also a debug facility that can record a series of responses and replay them.

### Usage
The component uses [Blazor FluentUI](https://www.fluentui-blazor.net/). 

You will need to follow the instructions here to add the FluentUI styles and scripts to your project: [FluentUI Blazor](https://www.fluentui-blazor.net/CodeSetup).

You will need to  follow the instructions [here to support dialogs](https://www.fluentui-blazor.net/DialogService) to add support for dialogs.

### Debug Mode

The component has a debug mode that can be enabled by setting the `DebugMode` property to true. In this mode, you can record a series of responses and replay them later. This is useful for testing and debugging your chat interactions.

In order to use it you can implement an interface of the following form:
```csharp

    public interface IDebugHistoryStore
    {
        
        Task SaveHistory(List<ChatMessage> history, string name);
        
        Task<List<string>> GetAllHistoryNames();
 
        void ClearHistory();

        Task<List<ChatMessage>> GetNamedHistory(string name);

        Task<List<ChatMessage>> GetCurrentHistory();

        Task SetCurrentHistory(List<ChatMessage>? history);

    }

```
An example implementation is provided in the `DebugHistoryStore` class. You can use this class to save and retrieve chat history from browser local storage.



