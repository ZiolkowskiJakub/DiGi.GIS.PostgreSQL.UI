namespace DiGi.GIS.PostgreSQL.UI
{
    public static partial class Query
    {
        /// <summary>
        /// Renders a Serilog message template with its positional values into the plain text the task row shows, the same text Serilog writes to the log, so the refusal reason on the row and in the log stay word-for-word identical.
        /// <para>The renderer is shared by every task that names a refusal on its row rather than kept per task: two copies of the token walk would be two places for the rendering rule to drift, and a drift costs nothing at compile time - only a row that no longer matches its own log line.</para>
        /// </summary>
        /// <param name="template">The Serilog message template, as it is handed to <c>Serilog.Modify.Log</c>.</param>
        /// <param name="values">The positional values, in the order the template's property tokens appear.</param>
        /// <returns>The rendered text.</returns>
        internal static string RenderRefusal(string template, params object[] values)
        {
            // global:: escapes the DiGi.Serilog namespace, which otherwise shadows the root Serilog namespace the
            // message template and its tokens live in. The property tokens are substituted in the order they appear,
            // the way Serilog's message formatter renders them - a string value as-is, without the quotes a standalone
            // value rendering adds - so the result is the log line word for word.
            global::Serilog.Events.MessageTemplate messageTemplate = new global::Serilog.Parsing.MessageTemplateParser().Parse(template);
            System.Text.StringBuilder result = new();
            int index = 0;
            foreach (global::Serilog.Parsing.MessageTemplateToken token in messageTemplate.Tokens)
            {
                if (token is global::Serilog.Parsing.PropertyToken)
                {
                    object? value = index < values.Length ? values[index] : null;
                    result.Append(value?.ToString() ?? string.Empty);
                    index++;
                }
                else if (token is global::Serilog.Parsing.TextToken textToken)
                {
                    result.Append(textToken.Text);
                }
            }

            return result.ToString();
        }
    }
}
