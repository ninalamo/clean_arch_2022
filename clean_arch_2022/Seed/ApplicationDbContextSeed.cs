namespace clean_arch_2022.Seed
{
    using clean_arch.domain.Aggregates.BankAccountTypes;
    using clean_arch.infrastructure;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.Data.SqlClient;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Polly;
    using Polly.Retry;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    public class ApplicationDbContextSeed
    {
        #region Private


        #region Private (Polly)
        private AsyncRetryPolicy CreatePolicy(ILogger<ApplicationDbContextSeed> logger, string prefix, int retries = 3)
        {
            return Policy.Handle<SqlException>().
                WaitAndRetryAsync(
                    retryCount: retries,
                    sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                    onRetry: (exception, timeSpan, retry, ctx) =>
                    {
                        logger.LogWarning(exception, "[{prefix}] Exception {ExceptionType} with message {Message} detected on attempt {retry} of {retries}", prefix, exception.GetType().Name, exception.Message, retry, retries);
                    }
                );
        }

        #endregion

        #endregion

        #region Public 

        public async Task SeedAsync(ApplicationDbContext context, IWebHostEnvironment env, IOptions<AppSettings> settings, ILogger<ApplicationDbContextSeed> logger)
        {
            var policy = CreatePolicy(logger, nameof(ApplicationDbContextSeed));

            await policy.ExecuteAsync(async () =>
            {
                using (context)
                {
                    context.Database.Migrate();

                    if (!context.Banks.Any())
                    {
                        context.Banks.Add(new clean_arch.domain.Aggregates.Banks.Bank("Sample Bank"));
                    }

                    if (!context.BankAccountTypes.Any())
                    {
                        context.BankAccountTypes.AddRange(new[]
                        {
                            new BankAccountType("Savings"),
                            new BankAccountType("Checking")
                        });
                    }

                    await context.SaveChangesAsync();
                }
            });
        }



        #endregion

    }
}