using Spectre.Console;

namespace ExtensionsAI.Chat.Sample;
 static class Utils
{
    /// <summary>
    /// Prompts the user for input.
    /// </summary>
    /// <param name="text"></param>
    /// <returns></returns>
    public static string TextPrompt(string text)
    {
        return AnsiConsole.Prompt(
            new TextPrompt<string>(text)
            .PromptStyle("white"));

    }
  
    /// <summary>
    /// Shows an error message in red.
    /// </summary>
    /// <param name="message"></param>
    public static void ErrorMessage(string message)
    {
         AnsiConsole.Markup($"[red][bold]{message}[/][/]");

    }
    /// <summary>
    /// Shows the header of the chat application.
    /// </summary>
    public static void Header()
    {
        AnsiConsole.Clear();
        // Create a table
        var table = new Table();
        table.Border(TableBorder.AsciiDoubleHead);
        // Add some columns

        table.AddColumn(new TableColumn(new FigletText("OLLAMA CHAT SAMPLE").Centered().Color(Color.Blue)).Centered());
        table.AddRow(Align.Left(new Markup("[red] Don't foget to run Ollama [/]")));
        AnsiConsole.Write(table);
        AnsiConsole.WriteLine();
    }
   

}
