using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Data.SqlClient;
using ScriptRunner.Core.Contracts;

namespace ScriptRunner.Core.Adapters;

public class SqlServerAdapter : IProviderAdapter
{
    public string ProviderName => "SqlServer";
    public bool SupportsTransactions => true;

    public DbConnection CreateConnection(string connectionString)
    {
        return new SqlConnection(connectionString);
    }

    public IEnumerable<string> SplitIntoBatches(string scriptText)
    {
        if (string.IsNullOrWhiteSpace(scriptText)) yield break;
        var parts = scriptText.Split(new[] { "\r\n", "\n" }, StringSplitOptions.None);
        var sb = new StringBuilder();
        foreach (var part in parts)
        {
            var trimmed = part.Trim();
            if (trimmed.Equals("GO", StringComparison.OrdinalIgnoreCase))
            {
                if (sb.Length > 0)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
                continue;
            }


            if (Regex.IsMatch(trimmed, @"^(CREATE|ALTER)\s+(PROC|PROCEDURE|VIEW|FUNCTION |TRIGGER)\b", RegexOptions.IgnoreCase))
            {
                if (sb.Length > 0)
                {
                    yield return sb.ToString();
                    sb.Clear();
                }
            }

            sb.AppendLine(part);
        }

        if (sb.Length > 0)
            yield return sb.ToString();
    }
}
