using System.Data.Common;
using System.Text;
using System.Text.RegularExpressions;
using ScriptRunner.Core.Contracts;
using ScriptRunner.Core.DTOS;
namespace ScriptRunner.Core;



public class ScriptRunner
{
    private readonly IDictionary<string, IProviderAdapter> _adapters;


    public ScriptRunner(IEnumerable<IProviderAdapter> adapters)
    {
        _adapters = adapters.ToDictionary(a => a.ProviderName, StringComparer.OrdinalIgnoreCase);

    }

    public async Task<ScriptExecutionResult> RunAsync(ScriptRunnerInputs scriptRunInput)
    {
        if (!_adapters.TryGetValue(scriptRunInput.Provider, out var adapter))
            throw new InvalidOperationException($"No adapter for provider {scriptRunInput.Provider}");

        string connnectionString = scriptRunInput.EncryptedConnectionString.Trim();

        if (string.IsNullOrWhiteSpace(connnectionString))
            throw new InvalidOperationException("Connection string is empty");

        await using var conn = adapter.CreateConnection(connnectionString);

        await conn.OpenAsync(scriptRunInput.ct);

        var batches = adapter.SplitIntoBatches(scriptRunInput.scriptText).ToList();

        var output = new StringBuilder();
        DbTransaction? tx = null;

        try
        {
            var containddl = batches.Any(checkscript);

            if (adapter.SupportsTransactions && !containddl)
            {
                tx = await conn.BeginTransactionAsync(scriptRunInput.ct);
            }

            foreach (var batch in batches)
            {
                scriptRunInput.ct.ThrowIfCancellationRequested();

                await using var cmd = conn.CreateCommand();

                cmd.CommandText = batch;

                if (tx != null) cmd.Transaction = tx;

                var affected = await cmd.ExecuteNonQueryAsync(scriptRunInput.ct);

                output.AppendLine(affected >= 0 ?
                    $"Batch Executed, Query returned rows: {affected}"
                    : "Batch Executed Successfully");
            }

            if (tx != null)
                await tx.CommitAsync(scriptRunInput.ct);

            return new ScriptExecutionResult
            {
                Success = true,
                Output = output.ToString()
            };
        }
        catch (Exception ex)
        {
            if (tx != null)
            {
                try { await tx.RollbackAsync(CancellationToken.None); }
                catch { }
            }
            return new ScriptExecutionResult
            {
                Success = false,
                Error = ex,
                Output = output.ToString()
            };
        }
        finally
        {
            await conn.CloseAsync();
        }

    }

    public bool checkscript(string b)
    {
        var sql = removeComments(b).ToUpperInvariant();
        return Regex.IsMatch(sql, "DROP | DELETE | TRUNCATE | ALTER | CREATE", RegexOptions.IgnoreCase);
    }

    public static string removeComments(string sql)
    {
        sql = Regex.Replace(sql, @"/\*.*?\*/", "", RegexOptions.Singleline);
        sql = Regex.Replace(sql, @"--.*?$", "", RegexOptions.Multiline);

        return sql;
    }


}
